using UnityEngine;
using System.Collections;

public class TransitionScreen : MonoBehaviour {
	public int nextlevel;	
	void Update () {
		if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.N)) && (nextlevel == 1)){
			Application.LoadLevel(Application.loadedLevel+1);
		}
		if(Input.GetKeyDown(KeyCode.Q)){
			Application.Quit();
		}

	}
}
