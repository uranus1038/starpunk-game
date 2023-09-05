using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI;
public class Wolf : CharacterControl
{
    public static Wolf mChar;
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
        this.InitGui();
        this.character = (CharacterController)this.GetComponent(typeof(CharacterController));
        this.animate = GetComponent<AnimationControl>();
        this.cameraTransform = GameObject.Find("Camera");
        this.previousPosition = this.character.transform.position;
        this.animate.next = new float[5];
    }
    private void InitGui()
    {

    }
    private void Start()
    {
        ((WolfEquipment)GetComponent(typeof(WolfEquipment))).EquipWeapon("SwordStandard");
        this.isMine = true;
        this.groundCheckRadius = 0.2f;
        this.animate.next[1] = Time.time;
        this.animate.next[2] = Time.time;
    }
    void Update()
    {
        if (this.isMine)
        {
            this.playerControl();
            this.GameControl();
        }
        else
        {
            this.EventAction();
        }
    }
    private void EventAction()
    {
        this.animate.actionState = "rig|wlf_run";
        this.animate.PlayAnimation(this.animate.actionState);
    }
    private void EventAction(string nPos, Vector3 tDir)
    {
        this.animate.actionState = "rig|wlf_run";
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
            //level hight
            playerVelocity.y = Mathf.Sqrt(this.jumpForce * -1f * Physics.gravity.y);
            if (this.animate.count == 0)
            {
                this.animate.count = 1;
            }
            else
            {
                this.animate.count = 0;
            }
        }
        // Apply Gravity (Fall gravity)
        this.playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);
        //Add Animation
        this.Addanimation();

        // Apply rotation
        this.PlayerRotation(this.cameraTransform);

    }
    
    private void Addanimation()
    {
        Vector3 currentPosition = character.transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        if (displacement.magnitude > 0.001f && this.character.isGrounded)
        {
            // move
            this.animate.next[1] = Time.time;
            this.animate.actionState = "rig|wlf_run";
            if (this.runSpeed < 12f)
            {
                this.animate.PlayAnimation(this.animate.actionState, 0.1f, 1f);
                if (Time.time - 0.2f > this.animate.next[2])
                {
                    this.animate.PlayAnimation(this.animate.actionState, 0f, 1f);
                }

            }
            else
            {
                this.animate.PlayAnimation(this.animate.actionState, 0.1f, 1f);
                if (Time.time - 0.2f > this.animate.next[2])
                {
                    this.animate.PlayAnimation(this.animate.actionState, 0f, 1.5f);
                }

            }
        }
        if (displacement.magnitude < 0.001f && this.character.isGrounded)
        {
            this.animate.next[2] = Time.time;
            this.animate.actionState = "rig|wlf_idel";
            this.animate.PlayAnimation(this.animate.actionState, 0.2f);
            if (Time.time - 0.3f > this.animate.next[1])
            {
                this.animate.PlayAnimation(this.animate.actionState);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.animate.count == 0)
            {
                // jump
                this.animate.actionState = "rig|wlf_jump_L";
                this.animate.PlayAnimation(this.animate.actionState, 0f, 1f);
            }
            else
            {
                this.animate.actionState = "rig|wlf_jump_R";
                this.animate.PlayAnimation(this.animate.actionState, 0f, 1f);
            }
        }
        this.previousPosition = currentPosition;
    }

    protected override void PlayerRotation(GameObject mCam)
    {
        base.PlayerRotation(mCam);
    }
    protected override void GameControl()
    {
        base.GameControl();
    }

}
