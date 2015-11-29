using UnityEngine;
using System.Collections;

public class OpenDoorEast : MonoBehaviour {
	private bool button=false;
	public Transform player;
	void Update (){
		if (player.position.x < transform.position.x + 1)
			button = true;
		if(open(transform.rotation.eulerAngles.y)!=true && button==true)
			transform.Rotate (0, 0, -Time.deltaTime * 5);
		
	}
	public bool open(float x){
		if (x <= 190 && x >= 180)
			return true;
		else
			return false;
	}
}
