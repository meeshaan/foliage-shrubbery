using UnityEngine;
using System.Collections;

public class highLight : MonoBehaviour {

	public GameObject item;
	public float timer = 0f;
	bool running=false;
	// Use this for initialization
	void Start () {
		item.GetComponent<ParticleSystem> ().Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			if (timer <= 0) {
				OffHover ();
			}
			timer -= Time.deltaTime;
		}
	}

	public void OnHover()
	{
		if(!running)
			item.GetComponent<ParticleSystem> ().Play ();
		timer = .2f;
		running = true;
	}
	public void OffHover()
	{
		item.GetComponent<ParticleSystem> ().Stop();
		running = false;
	}
}
