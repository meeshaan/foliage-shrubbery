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

	bool water = false;
	bool grown = false;

	float time = 0.0f;

	int state = 0;
	// Use this for initialization
	void Start () {
		this.renderer.material = initial;
		sFlower = GameObject.Find ("Sunflower");
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
			state = 1;
			break;
		case 2:
			this.renderer.material = seed;
			state = 2;
			break;
		case 3:
			this.renderer.material = covered;
			state = 3;
			break;
		case 4:
			this.renderer.material = watered;
			state = 4;
			water = true;
			break;
		case 5:
			this.renderer.material = flower;
			GameObject temp = Instantiate(sFlower,this.transform.position,this.transform.rotation) as GameObject;
			temp.transform.localScale.Set(.25f,.25f,.25f);
			state = 5;
			break;
		}
	}
	public int getState()
	{
		return state;
	}
}
