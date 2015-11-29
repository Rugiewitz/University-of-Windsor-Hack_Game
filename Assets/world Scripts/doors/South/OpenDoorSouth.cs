using UnityEngine;
using System.Collections;

public class OpenDoorSouth : MonoBehaviour {
	private bool button=false;
	public Transform player;
	void Update (){
		if (player.position.z < transform.position.z + 1)
			button = true;
		if(open(transform.rotation.eulerAngles.y)!=true && button==true)
			transform.Rotate (0, 0, -Time.deltaTime * 5);
		
	}
	public bool open(float x){
		if (x <= 90 && x >= 80)
			return true;
		else
			return false;
	}
}
