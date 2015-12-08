using UnityEngine;
using System.Collections;

public class shedDoorEnter : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject == player.gameObject) {
			//player.GetComponent<movementScript>().teleDown=true;
			player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y - 100, player.transform.position.z);
			//Debug.Log ("teledown true");
		}
	}
	void OnTriggerExit(Collider obj)
	{
		if (obj.gameObject == player.gameObject) {
			//player.GetComponent<movementScript> ().teleUp = false;
			//Debug.Log ("teledown false");
		}
	}
}
