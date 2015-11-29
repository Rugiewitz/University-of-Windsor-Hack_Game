using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {
	public int hp=1;
	public Transform PEffect;
	public GameController Gmaster;



	void OnCollisionEnter(Collision info)
	{
		if(info.gameObject.name == "Third Person Character")
		{
			Gmaster.SubHealth(hp);
			audio.Play();
			Transform effect = Instantiate(PEffect, transform.position, transform.rotation) as Transform;
			Destroy (effect.gameObject,2);

		}
	}


}
