using UnityEngine;
using System.Collections;

public class MouseLook2 : MonoBehaviour 
{
	public enum RotationAxis
	{
		MouseX = 1,
		MouseY = 2
	}
 
	public RotationAxis RotXY = RotationAxis.MouseX | RotationAxis.MouseY;

	// X Axis
	public float SensitivityX = 1000f;
	public float MinX = -360f;
	public float MaxX = 360f;
	private float RotationX = 0f;

	// Y Axis
	public float SensitivityY = 1000f;
	public float MinY = -50f;
	public float MaxY = 50f;
	private float RotationY = 0f;

	public Quaternion originalRotation;

	void Start () 
    {
		originalRotation = transform.localRotation; 
	}

	void Update () 
    {
		if(RotXY == RotationAxis.MouseX)
		{
			RotationX += Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime;

			RotationX = ClampAngle(RotationX, MinX, MaxX);

			Quaternion XQuaternion = Quaternion.AngleAxis(RotationX, Vector3.up);

			transform.localRotation = originalRotation * XQuaternion;
		}

		if(RotXY == RotationAxis.MouseY)
		{
			RotationY -= Input.GetAxis("Mouse Y") * SensitivityY * Time.deltaTime;

			RotationX = ClampAngle(RotationY, MinY, MaxY);

			Quaternion YQuaternion = Quaternion.AngleAxis(RotationY, Vector3.right);

			transform.localRotation = originalRotation * YQuaternion;


		}
	}

	private static float ClampAngle(float Angle, float Min, float Max)
	{
		if(Angle < -360)
		{
			Angle += 360;
		}

		if(Angle > 360)
		{
			Angle -= 360;
		}

		return Mathf.Clamp(Angle, Min, Max);
	}



}


