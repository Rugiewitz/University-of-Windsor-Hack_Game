using UnityEngine;
using System.Collections;

public class OutofBounds : MonoBehaviour {
	void OnTriggerEnter (Collider info)
	{
		if(info.name == "Third Person Character")
		{
		Application.LoadLevel (Application.loadedLevel);
		}
	}
}
