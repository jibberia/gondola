using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {
	
	public GameObject detritusPrefab;
	public GameObject detritusParent;

	void Start () {
		const int n = 400;
		const float h = 1000f;
		const float w = 2f;
		const float sv = .2f; // scale variance

		for (int i=0; i<n; i++) {
			Vector3 pos = new Vector3(Random.Range(-w, w), Random.Range(0, h));
			Quaternion rot = new Quaternion(0, 1, 0, Random.Range(0, 90));

			GameObject detritus = (GameObject)Instantiate(detritusPrefab, pos, rot);

			Vector3 scale = detritus.transform.localScale;
			float rsv = Random.Range(-sv, sv);
			scale.x += rsv;
			scale.y += rsv;
			scale.z += rsv;
			detritus.transform.localScale = scale;

			detritus.transform.SetParent(detritusParent.transform);
		}
	}
}
