using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : MonoBehaviour
{
    private CharacterController character;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    private Vector3 playerVelocity;
    private void Awake()
    {
        this.character = (CharacterController)this.GetComponent(typeof(CharacterController));
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
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = cameraForward * verticalInput + cameraTransform.right * horizontalInput;
        this.character.Move(moveDirection * moveSpeed * Time.deltaTime);
        this.playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        this.character.Move(playerVelocity * Time.deltaTime);
    }
}
