using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	public GameObject Player;
	public Vector3 movementSpeed;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton (1)) {
			Player.transform.Translate (Vector3.forward * speed);
		} else {
			Player.transform.Translate(Vector3.zero);
		}
	}
}
