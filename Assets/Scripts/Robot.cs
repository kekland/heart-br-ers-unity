using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	[SerializeField]
	HingeJoint2D joint1;

	[SerializeField]
	HingeJoint2D joint2;

	void Update () {
		float speed = Input.GetAxis("Horizontal") * 255f;
		Debug.Log(speed);

		JointMotor2D motor1 = joint1.motor;
		JointMotor2D motor2 = joint2.motor;

		motor1.motorSpeed = speed;
		motor2.motorSpeed = speed;

		joint1.motor = motor1;
		joint2.motor = motor2;
	}
}
