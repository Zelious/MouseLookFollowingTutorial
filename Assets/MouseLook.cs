using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour 
{
	public enum RotationAxes
	{
		MouseXAndY = 0,
		//MouseX = 1,
		//MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;

	//public float minX = -360.0f;
	//public float maxX = 360.0f;

	public float minY = -60.0f;
	public float maxY = 60.0f;

	private Transform myTransform;

	float rotationY = 0.0f;
	float lookSpeed;

	void Start () 
    {
		myTransform = transform;
		if(rigidbody)
			rigidbody.freezeRotation = true;
		lookSpeed = 30f;
	}

	void Update () 
    {
		if(axes == RotationAxes.MouseXAndY)
		{
			float rotationX = myTransform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime * lookSpeed;
			//Debug.Log(rotationX);

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime * lookSpeed;

			Mathf.Clamp(rotationY, minY, maxY);
			myTransform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		/*
		else if(axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else if(axes == RotationAxes.MouseY)
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minY, maxY);
			myTransform.localEulerAngles = new Vector3(-rotationY, myTransform.localEulerAngles.y, 0);
		}
		*/
	}
    
}
