using UnityEngine;
using System.Collections;

public class shedDoorExit : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider obj)
	{
		if (obj.gameObject == player.gameObject && !player.GetComponent<movementScript>().teleDown) {
			player.GetComponent<movementScript>().teleUp = true;
			player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 100, player.transform.position.z);
		}
	}
	void OnTriggerExit(Collider obj)
	{
		if (obj.gameObject == player.gameObject) {
			player.GetComponent<movementScript> ().teleDown = false;
		}
	}
}
