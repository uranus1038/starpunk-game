using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMod : MonoBehaviour
{
    private Transform camearaMod;
    public float smooth ;
    private void Awake()
    {
        this.smooth = 1f; 
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0f, 3f, -8f), Time.deltaTime* this.smooth);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.Euler(5f, 0f, 0f) , Time.deltaTime * this.smooth);
    }
    private void LateUpdate()
    {
        
    }
}
