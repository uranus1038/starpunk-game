using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class PlayerCameraControl : MonoBehaviour
{
	public PlayerCameraControl()
	{
		this.distance = 6f;
		this.zoom = 5f;
		this.float_7 = 1f;
	}
    public virtual void Awake()
	{
		this.float_0 = 0.2f;
		this.float_1 = 10f;
		this.float_2 = 0.3f;
		this.layerMask_0 = 65286;
		this.vector3_0 = Vector3.zero;
		this.vector3_1 = Vector3.zero;
		this.float_3 = 0f;
		this.vector3_2 = Vector3.zero;
		this.vector3_3 = Vector3.zero;
		this.float_4 = 0f;
		this.transform_0 = base.transform;
		if (PlayerPrefs.GetInt("lowAngle", 0) != 0)
		{
			this.lowAngle = true;
		}
	}

    // Token: 0x06003CB2 RID: 15538 RVA: 0x004DF670 File Offset: 0x004DD870
    private void Update()
    {
		this.cameraControl();
    }
	private void cameraControl()
	{
		if(Input.GetMouseButtonDown(1))
        {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}			
		if (Input.GetMouseButtonUp(1))
        {
			Cursor.visible = true;
			Cursor.lockState = 0;
		}
		//Mouse Scroll
		if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
		{
			this.zoom++; 
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
		{
			this.zoom--;
		}


		//RightClick
		if (Input.GetAxis("Mouse X") < 0 && Input.GetMouseButton(1))
			this.rotation=this.rotation -4f;
		if (Input.GetAxis("Mouse X") > 0 && Input.GetMouseButton(1))
			this.rotation=this.rotation +4f;

	}
    public virtual void LateUpdate()
	{
		if (this.target)
		{
			this.characterController_0 = (CharacterController)this.target.GetComponent(typeof(CharacterController));
			Vector3 center = this.characterController_0.bounds.center;
			this.float_4 = this.characterController_0.height - 1.5f;
			if (this.float_4 < 0f)
			{
				this.float_4 = 0f;
			}
			this.vector3_0.y = 0.2f * this.characterController_0.height;
			this.distance += this.zoom;
			if (this.distance < 2f)
			{
				this.distance = 2f;
			}
			if (this.distance > 12f)
			{
				this.distance = 12f;
			}
			this.zoom = 0f;
			int num = 4;
			if (this.lowAngle)
			{
				num = 16;
			}
			if (this.lockedTarget && this.isLocked)
			{
				Quaternion to = Quaternion.LookRotation(this.lockedTarget.transform.position - this.transform_0.position);
				this.transform_0.rotation = Quaternion.Slerp(this.transform_0.rotation, to, Time.deltaTime * 3f);
				float x2 = Mathf.SmoothDampAngle(this.transform_0.eulerAngles.x, 4f * this.distance - (float)num, ref this.float_3, 0.3f);
				Vector3 eulerAngles = this.transform_0.eulerAngles;
				eulerAngles.x = x2;
				this.transform_0.eulerAngles = eulerAngles;
			}
			else
			{
				this.transform_0.RotateAround(this.target.transform.position, Vector3.up, this.rotation);
				this.rotation = 0f;
				float x3 = Mathf.SmoothDampAngle(this.transform_0.eulerAngles.x, 4f * this.distance - (float)num, ref this.float_3, 0.3f);
				Vector3 eulerAngles2 = this.transform_0.eulerAngles;
				eulerAngles2.x = x3;
				this.transform_0.eulerAngles = eulerAngles2;
				Vector3 eulerAngles3 = this.transform_0.eulerAngles;
				eulerAngles3.z = 0f;
				this.transform_0.eulerAngles = eulerAngles3;
			}
			this.ApplyPositionDamping(center + this.vector3_0);
			this.ApplyCameraShake();
		}
	}
	public virtual void ApplyPositionDamping(Vector3 targetCenter)
	{
		float num = Mathf.Clamp(this.distance, 2f, 12f);
		Vector3 position = this.transform_0.position;
		float f = this.transform_0.eulerAngles.x * 0.017453292f;
		float f2 = this.transform_0.eulerAngles.y * 0.017453292f;
		float num2 = Mathf.Cos(f) * (num + this.float_4);
		float num3 = Mathf.Sin(f) * (num + this.float_4);
		Vector3 to = default(Vector3);
		to.x = -1f * Mathf.Sin(f2) * num2 + targetCenter.x;
		to.y = num3 + targetCenter.y;
		to.z = -1f * Mathf.Cos(f2) * num2 + targetCenter.z;
		Vector3 vector = Vector3.Lerp(position - this.vector3_2, to, Time.deltaTime * 4f);
		this.transform_0.position = vector + this.vector3_2;
	}

	public virtual void ApplyCameraShake()
	{
		if (this.ShakeMagnitude > 0f)
		{
			this.float_7 *= -1f;
			this.transform_0.position = this.transform_0.position + Vector3.up * Mathf.Clamp(this.ShakeMagnitude / 5f, 0f, 0.5f) * this.float_7;
			this.ShakeMagnitude = Mathf.Lerp(this.ShakeMagnitude, 0f, Time.deltaTime * 4f);
			if (this.ShakeMagnitude < 0.1f)
			{
				this.ShakeMagnitude = 0f;
			}
		}
	}
	public virtual float AngleDistance(float a, float b)
	{
		a = Mathf.Repeat(a, 360f);
		b = Mathf.Repeat(b, 360f);
		return Mathf.Abs(b - a);
	}
	private Vector2 previousCursorPosition;
	private Vector2 mousePosition;
	private Vector3 mousePositionWorld; 
	public GameObject target;
	private GameObject lockedTarget;
	private bool isLocked;
	public bool lowAngle;
	public float distance;
	public float rotation;
	public float zoom;
	private float float_0;
	private float float_1;
	private float float_2;
	private LayerMask layerMask_0;
	private CharacterController characterController_0;
	private Vector3 vector3_0;
	private Vector3 vector3_1;
	private float float_3;
	private Vector3 vector3_2;
	private Vector3 vector3_3;
	private float float_4;
	private float float_5;
	private float float_6;
	private Transform transform_0;
	public float ShakeMagnitude;
	private float float_7;
	private bool bool_0;
	private float float_8;
	private float float_9;
	private float float_10;
	private Vector3 vector3_4;
	private Quaternion quaternion_0;
	private DateTime stime;
}