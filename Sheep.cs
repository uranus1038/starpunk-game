using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI;
public class Sheep : CharacterControl
{
    public static Sheep mChar;
    private AnimationControl animate;
    private bool isGrounded;
    private CharacterController character;
    private GameObject cameraTransform;
    private float groundCheckRadius;
    private Vector3 playerVelocity;
    private Vector3 previousPosition;
    public LayerMask groundLayer;
    private void Awake()
    {
        this.character = (CharacterController)this.GetComponent(typeof(CharacterController));
        this.animate = GetComponent<AnimationControl>();
        this.cameraTransform = GameObject.Find("Camera");
        this.previousPosition = this.character.transform.position;


    }
    private void Start()
    {
        this.isMine = true; 

        this.groundCheckRadius = 0.2f;
    }
    void Update()
    {
        if (this.isMine)
        {
            this.playerControl();
        }else
        {
            this.EventAction();
        }
    }
    private void EventAction()
    {
        this.animate.actionState = "root|ari_idel";
        this.animate.PlayAnimation(this.animate.actionState);
    }
    private void EventAction(string nPos, Vector3 tDir)
    {
        this.animate.actionState = "root|ari_idel";
        this.animate.PlayAnimation(this.animate.actionState);
    }
    private void playerControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Direction camera
        Vector3 cameraForward = Vector3.Scale(cameraTransform.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = cameraForward * verticalInput + cameraTransform.transform.right * horizontalInput;
        this.character.Move(moveDirection * this.runSpeed * Time.deltaTime);
        // Check if the player is on the ground
        this.isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(this.jumpForce * -1f * Physics.gravity.y);
        }
        // Apply Gravity
        this.playerVelocity.y += -15.0f * Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);
        //Add Animation
        this.Addanimation();    

        // Apply rotation
        this.PlayerRotation();

    }
    private void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y, 0f);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 180f, 0f);

        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y + 90f, 0f);

        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 90f, 0f);

        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y + 45f, 0f);

        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 45f, 0f);


        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y + 135f, 0f);

        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 135f, 0f);


        }


        if (Input.GetKey(KeyCode.E))
        {

        }
    }
    private void Addanimation()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.animate.actionState = "root|ari_jump";
            this.animate.PlayAnimation(this.animate.actionState, 0f, 1.5f);
        }
        Vector3 currentPosition = character.transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        if (displacement.magnitude > 0.001f && this.character.isGrounded)
        {
            this.animate.actionState = "root|ari_move";
            if (this.runSpeed < 12f)
            {
                this.animate.PlayAnimation(this.animate.actionState, 0, 1f);
            }
            else
            {
                this.animate.PlayAnimation(this.animate.actionState, 0, 1.5f);
            }
            this.animate.delay = Time.time;
        }
        if (displacement.magnitude < 0.001f && this.character.isGrounded)
        {
            this.animate.actionState = "root|ari_idel";
            this.animate.PlayAnimation(this.animate.actionState, 0.2f);
            if (Time.time - 0.3f > this.animate.delay)
            {
                this.animate.actionState = "root|ari_idel";
                this.animate.PlayAnimation(this.animate.actionState);
            }
        }
      
        this.previousPosition = currentPosition;
    }

   

}
