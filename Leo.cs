using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : MonoBehaviour
{
    private Animator actor;
    private bool action;
    private CharacterController character;
    private GameObject cameraTransform;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Vector3 playerVelocity;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private void Awake()
    {
        this.action = false; 
        this.character = (CharacterController)this.GetComponent(typeof(CharacterController));
        this.actor = GetComponent<Animator>();
        this.cameraTransform = GameObject.Find("Camera");
    }
    void Update()
    {
        this.playerControl();
        this.PlayeAnimation();
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
        this.playerVelocity.y += -15.0f* Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);
        // Apply rotation
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y, 0f);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 180f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y +90f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, cameraTransform.transform.eulerAngles.y - 90f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            actor.Play("Root|move_leo", 0);
            this.action = true; 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            actor.Play("Root|move_leo", 0);
            this.action = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            actor.Play("Root|move_leo", 0);
            this.action = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            actor.Play("Root|move_leo", 0);
            this.action = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            actor.Play("Root|idel_leo", 0);
        }if(Input.GetKeyUp(KeyCode.S))
        {
            actor.Play("Root|idel_leo", 0);
        }if(Input.GetKeyUp(KeyCode.D))
        {
            actor.Play("Root|idel_leo", 0);
        }if(Input.GetKeyUp(KeyCode.A))
        {
            actor.Play("Root|idel_leo", 0);
        }
    }

    private void PlayeAnimation()
    {
        if(!this.action)
        {
            actor.Play("Root|idel_leo", 0);
        }
    }
    private void AddAnimation()
    {

    }
    private void ActionEvent()
    {

    }

}
