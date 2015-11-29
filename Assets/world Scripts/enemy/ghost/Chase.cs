using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{
	public Transform player;
	public float speed=1.5f;
	void Update (){
		transform.position = Vector3.MoveTowards (transform.position,player.transform.position,speed*Time.deltaTime);
		transform.LookAt (player);
	}
}