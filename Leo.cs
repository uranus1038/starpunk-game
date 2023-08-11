using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : MonoBehaviour
{
    private Animator action;
    private bool actor;
    private bool actor2;
    private CharacterController character;
    private GameObject cameraTransform;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private float groundCheckRadius = 0.2f;
    private Vector3 playerVelocity;
    private Vector3 previousPosition;
    public LayerMask groundLayer;
    private bool isGrounded;
    private void Awake()
    {
        this.actor = false;
        this.actor2 = false;
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
        }
        // Apply Gravity
        this.playerVelocity.y += -15.0f * Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);

        Vector3 currentPosition = character.transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        if (displacement.magnitude < 0.001f)
        {
            this.actor = false;
            this.PlayeAnimation(AddAnimation((int)Anim.idel), 0.1f);
        }
        else
        {
            if (!this.actor)
            {
                this.actor = true;
                this.PlayeAnimation(AddAnimation((int)Anim.move), 0.1f, 1.2f);
            }
            if (!this.character.isGrounded && this.actor)
            {
                this.actor2 = true;
                this.PlayeAnimation(AddAnimation((int)Anim.normal), 1f);
            }
            if(this.actor2 && this.character.isGrounded)
            {
                this.actor2 = false; this.actor = false;
            }
        }
        this.previousPosition = currentPosition;
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
    private void PlayeAnimation(string nAnimationName, float nCrossFadeTime)
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
    private void PlayeAnimation(string nAnimationName, float nCrossFadeTime, float nSpeed)
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
                animation = "Root|a_leo";
                break;
            case 1:
                animation = "Root|idel_leo";
                break;
            case 2:
                animation = "Root|move_leo";
                break;
        }

        return animation;
    }
    private void ActionEvent()
    {

    }

}
