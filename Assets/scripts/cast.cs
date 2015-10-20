using UnityEngine;
using System.Collections;

public class cast : MonoBehaviour {

	bool useShovel = false;
	bool useSeed = false;
	bool useWater = false;
	bool useHoe = false;

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
					if(useShovel && hit.collider.gameObject.GetComponent<plot>().getState() == 0)
					{Debug.Log("hi");
						hit.collider.gameObject.GetComponent<plot>().change(1);
					}
					if(useSeed && hit.collider.gameObject.GetComponent<plot>().getState() == 1)
					{
						hit.collider.gameObject.GetComponent<plot>().change(2);
					}
					if(useHoe && hit.collider.gameObject.GetComponent<plot>().getState() == 2)
					{
						hit.collider.gameObject.GetComponent<plot>().change(3);
					}
					if(useWater && hit.collider.gameObject.GetComponent<plot>().getState() == 3)
					{
						hit.collider.gameObject.GetComponent<plot>().change(4);
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
	void updateTool(int num)
	{
		useShovel = false;
		useSeed = false;
		useWater = false;
		useHoe = false;
		switch(num)
		{
		case 0:
			Debug.Log("Using nothing");
			break;
		case 1:
			useShovel = true;
			Debug.Log("Using shovel");
			break;
		case 2:
			useSeed = true;
			Debug.Log("Using seed");
			break;
		case 3:
			useWater = true;
			Debug.Log("Using water pail");
			break;
		case 4:
			useHoe = true;
			Debug.Log("Using hoe");
			break;
		default:
			break;
		}
	}
}
