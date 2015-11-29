using UnityEngine;
using System.Collections;

public class TakeCoin : MonoBehaviour 
{
	public Transform coinPEffect;
	public int coinValue = 1;
	public GameController Gmaster;
	private bool off=true;
	void OnTriggerEnter(Collider info)
	{
		if(info.name == "Third Person Character")
		{
			Gmaster.AddScore(coinValue);
			audio.Play();
			Transform effect = Instantiate(coinPEffect, transform.position, transform.rotation) as Transform;
			gameObject.renderer.enabled=false;
			Destroy (effect.gameObject,2);
			Destroy(gameObject, 0.5f);
		}
	}
	void update(){
		if(off==true && gameObject.renderer.enabled==false){
			audio.Play();
			off=false;
		}
	}
}
