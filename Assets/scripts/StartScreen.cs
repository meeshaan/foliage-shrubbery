using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	public GameObject Player;
	bool menu = true;
	// Use this for initialization
	void Start () {
		Player.GetComponent<CharacterController> ().enabled = false;
		Player.GetComponent<MouseLook> ().enabled = false;
		this.GetComponent<MouseLook> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (menu) {
			GUILayout.BeginArea (new Rect (0, 0, 100, 100));
			GUILayout.BeginVertical ();
			if (GUILayout.Button ("Start Game")) {
				Player.GetComponent<CharacterController> ().enabled = true;
				Player.GetComponent<MouseLook> ().enabled = true;
				this.GetComponent<MouseLook> ().enabled = true;
				menu = false;
			}
			if (GUILayout.Button ("End Game")) {
				Application.Quit ();
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
	}
}
