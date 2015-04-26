using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {
	
	public GameObject detritusPrefab;
	public GameObject detritusParent;

	void Start () {
		const int n = 400;
		const float h = 1000f;
		const float w = 2f;

		for (int i=0; i<n; i++) {
			Vector3 pos = new Vector3(Random.Range(-w, w), Random.Range(0, h));
			Quaternion rot = new Quaternion(0, 1, 0, Random.Range(0, 90));
			GameObject detritus = (GameObject)Instantiate(detritusPrefab, pos, rot);
			detritus.transform.SetParent(detritusParent.transform);
		}
	}
}
