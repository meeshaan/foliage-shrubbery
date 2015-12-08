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

	public Animator arms;

	public Light shovelLight;
	public Light seedLight;
	public Light hoeLight;
	public Light pailLight;
	public Light dirtLight;

	private bool shovelTutorial = true;
	private bool seedTutorial = true;
	private bool hoeTutorial = true;
	private bool pailTutorial = true;

	// Use this for initialization
	void Start () {
		shovel.SetActive (false);
		pail.SetActive (false);
		hoe.SetActive (false);
		shovelLight.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		constant ();
		if (arms.GetCurrentAnimatorStateInfo (0).IsName ("Dig")) {
			arms.SetBool("Shovel Kneeling",false);
		}
		if (arms.GetCurrentAnimatorStateInfo (0).IsName ("Hoe Cover")) {
			arms.SetBool("Hoe Kneeling",false);
		}

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			if (Physics.Raycast (this.transform.position, fwd, out hit, 4)) {
				if (hit.rigidbody.gameObject.tag == "plots") {
					if(useShovel && hit.collider.gameObject.GetComponent<plot>().getState() == 0)
					{
						dirtLight.enabled = false;
						seedLight.enabled = true;
						shovelTutorial = false;
						hit.collider.gameObject.GetComponent<plot>().change(1);
						sound.play(2);
						arms.SetBool("Shovel Kneeling", true);
						arms.SetBool("Dig", true);
					}
					if(useSeed && hit.collider.gameObject.GetComponent<plot>().getState() == 1)
					{
						dirtLight.enabled = false;
						hoeLight.enabled = true;
						seedTutorial = false;
						hit.collider.gameObject.GetComponent<plot>().change(2);
						sound.play(3);
						arms.SetBool("Seed",true);
					}
					if(useHoe && hit.collider.gameObject.GetComponent<plot>().getState() == 2)
					{
						dirtLight.enabled = false;
						pailLight.enabled = true;
						hoeTutorial = false;
						hit.collider.gameObject.GetComponent<plot>().change(3);
						sound.play(2);
						arms.SetBool("Hoe Kneeling", true);
						arms.SetBool("Hoe Trigger", true);
					}
					if(useWater && hit.collider.gameObject.GetComponent<plot>().getState() == 3)
					{
						dirtLight.enabled = false;
						hit.collider.gameObject.GetComponent<plot>().change(4);
						sound.play(4);
						pailTutorial = false;
						arms.SetBool("Water Pour",true);
					}

				}
				if (hit.rigidbody.gameObject.tag == "shovel") {
					updateTool(1);
					arms.SetBool("GetTool",true);
				}
				if (hit.rigidbody.gameObject.tag == "seed") {
					updateTool(2);
					arms.SetBool("GetTool",true);
				}
				if (hit.rigidbody.gameObject.tag == "waterPail") {
					updateTool(3);
					arms.SetBool("GetTool",true);
				}
				if (hit.rigidbody.gameObject.tag == "hoe") {
					updateTool(4);
					arms.SetBool("GetTool",true);
				}
				if (hit.rigidbody.gameObject.tag == "barn") {

					//updateTool(0);
				}
			}
		}
	}
	void constant()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast (this.transform.position, fwd, out hit, 4)) {
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

		switch(num)
		{
		case 0:
			Debug.Log("Using nothing");
			break;
		case 1:
			useShovel = true;
			sound.play (1);
			Debug.Log("Using shovel");
			shovel.SetActive(true);
			if (shovelTutorial)
			{
				shovelLight.enabled = false;
				dirtLight.enabled = true;
			}
			break;
		case 2:
			useSeed = true;
			sound.play(5);
			Debug.Log("Using seed");
			if (seedTutorial)
			{
				seedLight.enabled = false;
				dirtLight.enabled = true;
			}
			break;
		case 3:
			useWater = true;
			sound.play(6);
			Debug.Log("Using water pail");
			pail.SetActive(true);
			if (pailTutorial)
			{
				pailLight.enabled = false;
				dirtLight.enabled = true;
			}
			break;
		case 4:
			useHoe = true;
			sound.play (1);
			Debug.Log("Using hoe");
			hoe.SetActive(true);
			if (hoeTutorial)
			{
				hoeLight.enabled = false;
				dirtLight.enabled = true;
			}
			break;
		default:
			break;
		}
	}
}
