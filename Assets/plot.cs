using UnityEngine;
using System.Collections;

public class plot : MonoBehaviour {

	public Material yellow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void change()
	{
		this.renderer.material = yellow;
	}
}
