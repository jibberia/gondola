using UnityEngine;
using UnityEditor;
using System.Collections;

public class WaterInput : MonoBehaviour {

	public GameObject boat;
	public Transform poleTransform;
	public float paddleEnergyScalar = 50f;

	private Rigidbody boatRigidbody;

	void Start () {
		boatRigidbody = boat.GetComponentInChildren<Rigidbody>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit waterHit;
			if (Physics.Raycast(ray, out waterHit)) {
//				Debug.Log("hit " + waterHit.transform.gameObject.name + " at " + waterHit.point.ToString());

				Vector3 direction = boat.transform.position - waterHit.point;
				Debug.DrawRay(waterHit.point, direction, Color.green, 5f);

				// now raycast from water hit point to boat to find position we hit it
				Ray boatRay = new Ray(waterHit.point, direction);
				RaycastHit boatHit;
				if (Physics.Raycast(boatRay, out boatHit)) {
					Debug.DrawRay(boatHit.point, waterHit.point - boatHit.point, Color.red, 5f);
					boatRigidbody.AddForceAtPosition(direction * paddleEnergyScalar, boatHit.point);
				}

//				EditorApplication.isPaused = true;
			}
		}
	}

//	void OnCollisionEnter(Collision c) {
//		Debug.Log("water collided with " + c.gameObject.name);
//	}
//	void OnCollisionStay(Collision c) {
//		Debug.Log("water stayed colliding with " + c.gameObject.name);
//	}
//	void OnTriggerEnter(Collider c) {
//		Debug.Log("water trigger enter with " + c.gameObject.name);
//	}
}
