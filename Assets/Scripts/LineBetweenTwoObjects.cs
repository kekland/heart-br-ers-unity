using UnityEngine;
using UnityEngine.UI;
public class LineBetweenTwoObjects : MonoBehaviour {
	LineRenderer attachedRenderer;
	GameObject canvasChild;
	public Material materialToSet;

	public NonPhysicalJoint attachedJoint;

	public int connectedPort = -1;
	public bool isMotorConnected;

	public GameObject object1, object2;
	void Start() {
		attachedRenderer = gameObject.AddComponent<LineRenderer>();
		canvasChild = transform.GetChild(0).gameObject;
		attachedRenderer.startWidth = 0.03f;
		attachedRenderer.endWidth = 0.03f;
		attachedRenderer.material = materialToSet;
		attachedRenderer.sortingOrder = -1;
		canvasChild.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = materialToSet.color;
		attachedRenderer.SetPositions(new Vector3[] { object1.transform.position, object2.transform.position });
	}

	public void DestroyJoint() {
		if(connectedPort != -1) {
			if(isMotorConnected) {
				GameObject.Find("Brain").GetComponent<BrainData>().connectedMotors[connectedPort] = null;
			}
			else
			{
				GameObject.Find("Brain").GetComponent<BrainData>().connectedSensors[connectedPort] = null;
			}
			object2.GetComponent<ExportObjectData>().connectedPort = -1;
		}
		if (attachedJoint != null)
		{
			Destroy(attachedJoint);
		}
		Destroy(gameObject);
	}

	void Update() {
		if(object1 == null || object2 == null) {
			Destroy(gameObject);
		}
		else
		{
			attachedRenderer.SetPosition(0, object1.transform.position);
			attachedRenderer.SetPosition(1, object2.transform.position);
			canvasChild.transform.position = (object1.transform.position + object2.transform.position) / 2f;
		}
	}
}