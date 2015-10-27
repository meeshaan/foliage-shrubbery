using UnityEngine;
using System.Collections;

public class sounds : MonoBehaviour {
	
	public AudioClip pickuptool;
	public AudioClip shoveling;
	public AudioClip spreading;
	public AudioClip watering;

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(int i)
	{
		AudioClip clip = pickuptool;
		switch(i)
		{
		case 1:
			clip = pickuptool;
			break;
		case 2:
			clip = shoveling;
			break;
		case 3:
			clip = spreading;
			break;
		case 4:
			clip = watering;
			break;
		}
		AudioSource aS = player.GetComponent<AudioSource> ();
		aS.clip = clip;
		aS.PlayOneShot (clip);
	}
}
