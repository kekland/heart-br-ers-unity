using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ExportObjectData : MonoBehaviour {
	public int objectIndex;
	public int objectPrefabIndex;

	public GameObject hingedObject;

	public bool canBeElectricallyConnected = false;
	public bool isMotorPort = false;
	public bool isSensorPort = false;
	public int connectedPort = -1;
	public float motorSpeed = 100f;

	public override string ToString() {
		List<NonPhysicalJoint> joints = new List<NonPhysicalJoint>(GetComponents<NonPhysicalJoint>());

		string builder = string.Format("{0}|{1}|{2}|{3}|", objectIndex, objectPrefabIndex, Utils.DeserializeVector2(transform.position), Utils.DeserializeQuaternion(transform.rotation));

		foreach(NonPhysicalJoint joint in joints) {
			builder += joint.connectedObject.GetComponent<ExportObjectData>().objectIndex + "." + (joint.IsHingedJoint? "h":"f") + ",";
		}

		builder = builder.Remove(builder.Length - 1);

		return builder;
	}
}
