using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	void Start() {

	}

	[SerializeField]
	float movingSensitivity = 0.166f;

	[SerializeField]
	float orthoZoomSpeed;
	[SerializeField]
	float maxOrthoZoom;

	float minimumY = -4.5f;
	public void UpdateCamera() {
		HandleMovement();
		HandleZoom();
	}

	void HandleMovement() {
		if (Input.touchCount >= 1)
		{
			Vector3 delta = (Vector3)Input.GetTouch(0).deltaPosition;
			delta *= -movingSensitivity * 2f * Camera.main.orthographicSize / Camera.main.pixelHeight;
			if(transform.position.y + delta.y - Camera.main.orthographicSize < minimumY) {
				delta.y = 0f;
			}
			transform.position += delta;
		}
	}


	void HandleZoom() {
		if (Input.touchCount >= 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			float prevOrthoSize = Camera.main.orthographicSize;
			// ... change the orthographic size based on the change in distance between the touches.
			Camera.main.orthographicSize += deltaMagnitudeDiff * 2f * Camera.main.orthographicSize / Camera.main.pixelHeight;

			if(Camera.main.transform.position.y - Camera.main.orthographicSize < minimumY) {
				Vector3 pos = Camera.main.transform.position;
				pos.y += minimumY - (Camera.main.transform.position.y - Camera.main.orthographicSize);
				Camera.main.transform.position = pos;
			}
			// Make sure the orthographic size never drops below zero.
			Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
			// Make sure the orthographic size is always below maximum value.
			Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, maxOrthoZoom);
		}
	}
}
