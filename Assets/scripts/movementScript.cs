using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	public GameObject Player;
	public Vector3 movementSpeed;
	public float speed;
	public bool teleUp = false;
	public bool teleDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton (1)) {
			Player.GetComponent<CharacterController>().SimpleMove(new Vector3(speed*Mathf.Sin((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f),0.0f,speed*Mathf.Cos((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f)));
			Debug.Log("angle" + Player.transform.rotation.eulerAngles.y.ToString());
			Debug.Log("sin" + Mathf.Sin((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f).ToString());
			Debug.Log("cos" + Mathf.Cos((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f).ToString());
			this.gameObject.GetComponent<AudioSource>().Play();
		} else {
			Player.GetComponent<CharacterController>().Move(Vector3.zero);
			this.gameObject.GetComponent<AudioSource>().Stop();
		}
	}
}
