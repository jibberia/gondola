using UnityEngine;
using UnityEditor;
using System.Collections;

public class WaterInput : MonoBehaviour {

	public GameObject boat;
	public float paddleEnergyScalar = 50f;

	private Rigidbody boatrb;

	void Start () {
		boatrb = boat.GetComponentInChildren<Rigidbody>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log("hit " + hit.transform.gameObject.name + " at " + hit.point.ToString());

				Vector3 direction = hit.point - boat.transform.position;

				boatrb.AddForceAtPosition(-direction * paddleEnergyScalar, hit.point);

				Debug.DrawRay(hit.point, direction, Color.green, 5f);
//				EditorApplication.isPaused = true;
			}
		}
	}
}
