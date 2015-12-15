using UnityEngine;
using System.Collections;

public class plot : MonoBehaviour {

	public Material initial;
	public Material dug;
	public Material seed;
	public Material covered;
	public Material watered;
	public Material flower;
	public GameObject sFlower;

	public GameObject dirtInitial;
	public GameObject dirtDug;
	public GameObject dirtSeed;
	public GameObject dirtCovered;
	public GameObject dirtWatered;
	public GameObject sunFlower;

	bool water = false;
	bool grown = false;

	float time = 0.0f;

	int state = 0;
	// Use this for initialization
	void Start () {
		this.GetComponent<MeshRenderer> ().enabled = false;
		GameObject temp = Instantiate(dirtInitial,this.transform.position,this.transform.rotation) as GameObject;
		temp.transform.localScale = new Vector3 (.009f, .009f, .009f);
		temp.transform.position = new Vector3 (this.transform.position.x, .17f, this.transform.position.z);
		dirtInitial = temp;
		sFlower = GameObject.Find ("SunFlower_Anim");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!grown && water)
		{
			time += Time.deltaTime;
			if(time >= 3)
			{
				change(5);
				grown = true;
				water = false;
			}
		}
	}
	public void change(int num)
	{
		switch(num)
		{
		case 1:
			this.renderer.material = dug;
			dirtInitial.SetActive(false);
			GameObject temp = Instantiate(dirtDug,this.transform.position,this.transform.rotation) as GameObject;
			temp.transform.localScale = new Vector3 (.009f, .009f, .009f);
			temp.transform.position = new Vector3 (this.transform.position.x, .17f, this.transform.position.z);
			dirtDug = temp;
			state = 1;
			break;
		case 2:
			this.renderer.material = seed;
			GameObject temp2 = Instantiate(dirtSeed, this.transform.position,this.transform.rotation) as GameObject;
			temp2.transform.localScale = new Vector3(.1f,.1f,.1f);
			dirtSeed = temp2;
			state = 2;
			break;
		case 3:
			this.renderer.material = covered;
			dirtDug.SetActive(false);
			dirtSeed.SetActive(false);
			GameObject temp3 = Instantiate(dirtCovered,this.transform.position,this.transform.rotation) as GameObject;
			temp3.transform.localScale = new Vector3 (.009f, .009f, .009f);
			temp3.transform.position = new Vector3 (this.transform.position.x, .17f, this.transform.position.z);
			dirtCovered = temp3;
			state = 3;
			break;
		case 4:
			this.renderer.material = watered;
			dirtCovered.SetActive(false);
			GameObject temp4 = Instantiate(dirtCovered,this.transform.position,this.transform.rotation) as GameObject;
			temp4.transform.localScale = new Vector3 (.009f, .009f, .009f);
			temp4.transform.position = new Vector3 (this.transform.position.x, .17f, this.transform.position.z);
			dirtDug = temp4;
			state = 4;
			water = true;
			break;
		case 5:
			this.renderer.material = flower;
			dirtInitial.SetActive(true);
			GameObject temp5 = Instantiate(sFlower,this.transform.position,this.transform.rotation) as GameObject;
			temp5.transform.localScale.Set(.25f,.25f,.25f);
			state = 5;
			break;
		}
	}
	public int getState()
	{
		return state;
	}
}
