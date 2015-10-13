using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast (this.transform.position, fwd, out hit, 10)) {
			if(hit.rigidbody.gameObject.tag == "plots")
			{
				Debug.Log("found a plot");
			}
		}

	}
}
