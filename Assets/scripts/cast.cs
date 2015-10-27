using UnityEngine;
using System.Collections;

public class cast : MonoBehaviour {

	public bool useShovel = false;
	public bool useSeed = false;
	public bool useWater = false;
	public bool useHoe = false;
	public GameObject item;
	public GameObject shovel;
	public GameObject pail;
	public GameObject hoe;
	public sounds sound;
	// Use this for initialization
	void Start () {
		shovel.SetActive (false);
		pail.SetActive (false);
		hoe.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		constant ();

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			if (Physics.Raycast (this.transform.position, fwd, out hit, 4)) {
				Debug.Log(hit.rigidbody.gameObject.tag.ToString());
				if (hit.rigidbody.gameObject.tag == "plots") {
					if(useShovel && hit.collider.gameObject.GetComponent<plot>().getState() == 0)
					{
						hit.collider.gameObject.GetComponent<plot>().change(1);
						sound.play(2);
					}
					if(useSeed && hit.collider.gameObject.GetComponent<plot>().getState() == 1)
					{
						hit.collider.gameObject.GetComponent<plot>().change(2);
						sound.play(3);
					}
					if(useHoe && hit.collider.gameObject.GetComponent<plot>().getState() == 2)
					{
						hit.collider.gameObject.GetComponent<plot>().change(3);
						sound.play(2);
					}
					if(useWater && hit.collider.gameObject.GetComponent<plot>().getState() == 3)
					{
						hit.collider.gameObject.GetComponent<plot>().change(4);
						sound.play(4);
					}

				}
				if (hit.rigidbody.gameObject.tag == "shovel") {
					updateTool(1);
					
				}
				if (hit.rigidbody.gameObject.tag == "seed") {
					updateTool(2);
					
				}
				if (hit.rigidbody.gameObject.tag == "waterPail") {
					updateTool(3);
					
				}
				if (hit.rigidbody.gameObject.tag == "hoe") {
					updateTool(4);
					
				}
				if (hit.rigidbody.gameObject.tag == "barn") {

					updateTool(0);
				}
			}
		}

	}
	void constant()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast (this.transform.position, fwd, out hit, 10)) {
			Debug.Log (hit.rigidbody.gameObject.tag.ToString ());
			item = hit.rigidbody.gameObject as GameObject;
			item.GetComponent<highLight>().OnHover();
		}
	}

	void updateTool(int num)
	{
		useShovel = false;
		useSeed = false;
		useWater = false;
		useHoe = false;
		shovel.SetActive (false);
		pail.SetActive (false);
		hoe.SetActive (false);
		sound.play (1);
		switch(num)
		{
		case 0:
			Debug.Log("Using nothing");
			break;
		case 1:
			useShovel = true;
			Debug.Log("Using shovel");
			shovel.SetActive(true);
			break;
		case 2:
			useSeed = true;
			Debug.Log("Using seed");
			break;
		case 3:
			useWater = true;
			Debug.Log("Using water pail");
			pail.SetActive(true);
			break;
		case 4:
			useHoe = true;
			Debug.Log("Using hoe");
			hoe.SetActive(true);
			break;
		default:
			break;
		}
	}
}
