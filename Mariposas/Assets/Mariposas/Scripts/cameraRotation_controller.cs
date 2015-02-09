using UnityEngine;
using System.Collections;

public class cameraRotation_controller : MonoBehaviour {

	float gyroX, gyroY;
	float rotationX, rotationY;
	public float gyroSensitivity=3;
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		gyroX = Input.gyro.rotationRate.x;
		gyroY = Input.gyro.rotationRate.y;
			
			//transform.RotateAround(transform.position , transform.right, Time.deltaTime * gyroSensitivity);
			//transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * gyroSensitivity);
		rotationX = gyroX * Time.deltaTime * gyroSensitivity;
		rotationY = gyroY * Time.deltaTime * gyroSensitivity;
		transform.RotateAround(transform.position, Vector3.up, -rotationY);
		transform.RotateAround(transform.position, transform.right, -rotationX);
			//transform.Rotate (new Vector3 (rotationX, rotationY, 0));
			//Quaternion target = Quaternion.Euler(, 0, tiltAroundZ);

	}


}
