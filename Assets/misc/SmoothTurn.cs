using UnityEngine;
using System.Collections;

public class SmoothTurn : MonoBehaviour {
	
	public float speed = 0.1f; 
	public Transform pPos; // the target position
	
	void Update(){	
		transform.rotation = Quaternion.Slerp (transform.rotation, pPos.rotation,  speed * Time.deltaTime);
	}
}
