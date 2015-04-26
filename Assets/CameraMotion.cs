using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {

	public GameObject boat;

	private float camBoatYDifference;

	void Start () {
		camBoatYDifference = this.transform.position.y - boat.transform.position.y;
	}
	
	void Update () {
		Vector3 pos = this.transform.position;
		pos.y = boat.transform.position.y + camBoatYDifference;
		this.transform.position = pos;
	}
}
