using UnityEngine;
using UnityEditor;
using System.Collections;

public class WaterInput : MonoBehaviour {

	public GameObject boat;
	// position of pole on gondola (somewhere near rear)
	public Transform poleTransform;
	public float poleEnergyScalar = 50f;

	private Rigidbody boatRigidbody;

	void Start () {
		boatRigidbody = boat.GetComponentInChildren<Rigidbody>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			// get water coordinates of screen click/tap
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit waterHit;
			Physics.Raycast(ray, out waterHit); // assume success

			// get direction of pointer/finger to gondola pole
			Vector3 direction = poleTransform.position - waterHit.point;
			Debug.DrawRay(waterHit.point, direction, Color.green, 5f);

			// now raycast from water hit point to boat to find hull position of hit
			Ray boatRay = new Ray(waterHit.point, direction);
			RaycastHit boatHit;
			Physics.Raycast(boatRay, out boatHit); // assume success

			// add force at the point we hit
			boatRigidbody.AddForceAtPosition(direction * poleEnergyScalar, boatHit.point);
			Debug.DrawRay(boatHit.point, waterHit.point - boatHit.point, Color.red, 5f);
		}
	}
}
