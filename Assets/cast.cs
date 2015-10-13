using UnityEngine;
using System.Collections;

public class cast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			if (Physics.Raycast (this.transform.position, fwd, out hit, 10)) {
				Debug.Log(hit.rigidbody.gameObject.tag.ToString());
				if (hit.rigidbody.gameObject.tag == "plots") {
					hit.collider.gameObject.GetComponent<plot>().change();

				}
			}
		}

	}
}
