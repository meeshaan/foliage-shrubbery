using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	public GameObject Player;
	public Vector3 movementSpeed;
	public float speed;
	public Animator arms;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton (1)) {
			arms.SetBool("ToolWalking",true);
			Player.GetComponent<CharacterController>().SimpleMove(new Vector3(speed*Mathf.Sin((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f),0.0f,speed*Mathf.Cos((Player.transform.rotation.eulerAngles.y)*Mathf.PI/180f)));
			this.gameObject.GetComponent<AudioSource>().Play();
		} else {
			arms.SetBool("ToolWalking",false);
			Player.GetComponent<CharacterController>().Move(Vector3.zero);
			this.gameObject.GetComponent<AudioSource>().Stop();
		}
	}
}
