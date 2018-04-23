using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPhysicalJoint : MonoBehaviour {

	public GameObject connectedObject;
	public bool IsHingedJoint;
	Vector3 prevConnectedObjectPosition;
	Vector3 prevCurrentObjectPosition;
	Vector2 delta;
	public void SetConnectedObject(GameObject connectTo) {
		connectedObject = connectTo;
		delta = connectTo.transform.position - transform.position;
	}

	bool isPaused = false;

	public void Pause() {
		isPaused = true;
	}

	public void Unpause() {
		isPaused = false;
		SetConnectedObject(connectedObject);
	}

	void Update() {
		if(isPaused) {
			return;
		}

		if(transform.position != prevCurrentObjectPosition) {
			connectedObject.transform.position = transform.position + (Vector3)delta;
		}
		else if(connectedObject.transform.position != prevConnectedObjectPosition)
		{
			transform.position = connectedObject.transform.position + -(Vector3)delta;
		}

		prevConnectedObjectPosition = connectedObject.transform.position;
		prevCurrentObjectPosition = transform.position;
	}
}
