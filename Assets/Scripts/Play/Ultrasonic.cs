using UnityEngine;
public class Ultrasonic : Sensor {
	public override float GetSensorValue() {
		RaycastHit2D hit2D = Physics2D.Raycast(transform.position + transform.right * 0.2f, transform.right, 10f);
		if(hit2D) {
			return Vector2.Distance(hit2D.point, transform.position);
		}
		else {
			return -1;
		}
	}
}