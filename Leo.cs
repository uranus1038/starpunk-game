using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : MonoBehaviour
{
    private Animator action;
    private bool actor;
    private bool actor2;
    private bool actor3;
    private bool actor4;
    private bool isGrounded;
    private CharacterController character;
    private GameObject cameraTransform;
    public float delay ;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private float groundCheckRadius = 0.2f;
    private Vector3 playerVelocity;
    private Vector3 previousPosition;
    public LayerMask groundLayer;
    private void Awake()
    {
        this.actor = false;
        this.actor2 = false;
        this.actor3 = false;
        this.actor4 = false;
        this.delay = 0f;
        this.character = (CharacterController)this.GetComponent(typeof(CharacterController));
        this.action = GetComponent<Animator>();
        this.cameraTransform = GameObject.Find("Camera");
        this.previousPosition = this.character.transform.position;
    }
    void Update()
    {
        this.playerControl();
    }
    private void playerControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Direction camera
        Vector3 cameraForward = Vector3.Scale(cameraTransform.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = cameraForward * verticalInput + cameraTransform.transform.right * horizontalInput;
        this.character.Move(moveDirection * moveSpeed * Time.deltaTime);
        // Check if the player is on the ground
        this.isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -1f * Physics.gravity.y);
            if(!this.actor3)
            {
                this.actor3 = true; 
            }else
            {
                this.actor3 = false; 
            }
        }
        // Apply Gravity
        this.playerVelocity.y += -15.0f * Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);
        //Add Animation
        this.PlayerAnimationEvent();

        // Apply rotation
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
    private void PlayerAnimationEvent()
    {

        Vector3 currentPosition = character.transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        if(displacement.magnitude > 0.001f)
        {
            this.delay = Time.time;
        }
        if (displacement.magnitude < 0.001f)
        {
            this.actor = false;
            this.PlayAnimation(AddAnimation((int)Anim.idel), 0.2f);
            if(Time.time - 0.2f > this.delay)
            {
                this.PlayAnimation(AddAnimation((int)Anim.idel), 0f);
            }
        }
        else
        {
            if (!this.actor)
            {
                this.actor = true;
                this.PlayAnimation(AddAnimation((int)Anim.move), 0f, 1.2f);
            }
            if (!this.character.isGrounded && this.actor)
            {   
                this.actor2 = true;
                if(!this.actor3)
                {
                    this.PlayAnimation(AddAnimation((int)Anim.jumpL), 0f , 1.5f);
                }else
                {
                    this.PlayAnimation(AddAnimation((int)Anim.jumpR), 0f, 1.5f);
                }
            }
            if (this.actor2 && this.character.isGrounded)
            {
                this.actor2 = false; this.actor = false; 
            }
        }
        this.previousPosition = currentPosition;
    }
    private void PlayAnimation(string nAnimationName, float nCrossFadeTime)
    {
        if (nCrossFadeTime <= 0f)
        {
            this.action.Play(nAnimationName);
        }
        else
        {
            this.action.CrossFade(nAnimationName, nCrossFadeTime);
        }
    }
    private void PlayAnimation(string nAnimationName, float nCrossFadeTime, float nSpeed)
    {
        if (nCrossFadeTime <= 0f)
        {
            this.action.Play(nAnimationName);
        }
        else
        {
            this.action.CrossFade(nAnimationName, nCrossFadeTime);
        }
        this.action.speed = nSpeed;
    }
    private string AddAnimation(int nAnimationName)
    {
        string animation = string.Empty;
        switch (nAnimationName)
        {
            case 0:
                animation = "root|a_leo";
                break;
            case 1:
                animation = "root|leo_idel";
                break;
            case 2:
                animation = "root|leo_move";
                break;
            case 3:
                animation = "root|leo_jump_R";
                break;
            case 4:
                animation = "root|leo_jump_L";
                break;
        }

        return animation;
    }
    private void ActionEvent()
    {

    }

}
