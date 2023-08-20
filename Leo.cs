using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI;
public class Leo : ChracterControl
{
    public static Leo mChar; 
    private AnimationControl animate;
    private bool isGrounded;
    private bool isCheck1;
    private bool isCheck2;
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
        this.isCheck1 = false;
        this.isCheck2 = false;
        this.groundCheckRadius = 0.2f;
        this.jumpForce = 8f;
        this.animate.actionState = "standby";
    }
    void Update()
    {
        this.playerControl();
        this.hit(50,50);
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
            if(this.animate.count == 0)
            {
                this.animate.count = 1;
            }
            else
            {
                this.animate.count = 0; 
            }
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

        Vector3 currentPosition = character.transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        if(displacement.magnitude > 0.001f)
        {
            this.animate.delay = Time.time;
        }
        if (displacement.magnitude < 0.001f)
        {
            this.isCheck1 = false;
            this.animate.actionState = "root|leo_idel";
            this.animate.PlayAnimation(this.animate.actionState,0.2f);
            if (Time.time - 0.2f > this.animate.delay)
            {
                this.animate.actionState = "root|leo_idel";
                this.animate.PlayAnimation(this.animate.actionState);
            }
        }
        else
        {
            if (!this.isCheck1)
            {
                this.isCheck1 = true;
                this.animate.actionState = "root|leo_move";
                if(this.runSpeed < 12f)
                {
                  this.animate.PlayAnimation(this.animate.actionState,0,1f);
                }else 
                {
                    this.animate.PlayAnimation(this.animate.actionState, 0, 1.2f);
                }            
            }
            if (!this.character.isGrounded && this.isCheck1)
            {   
                this.isCheck2 = true;
                if(this.animate.count == 0)
                {
                    this.animate.actionState = "root|leo_jump_L";
                    this.animate.PlayAnimation(this.animate.actionState,0f,1.5f);
                }
                else
                {
                    this.animate.actionState = "root|leo_jump_R";   
                    this.animate.PlayAnimation(this.animate.actionState, 0f, 1.5f);
                }
            }
            if (this.isCheck2 && this.character.isGrounded)
            {
                this.isCheck2 = false; 
                this.isCheck1 = false; 
            }
        }
        this.previousPosition = currentPosition;
    }

    public static void ActionEvent()
    {

    }

}
