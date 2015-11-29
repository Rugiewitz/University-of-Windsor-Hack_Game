using UnityEngine;
using System.Collections;

public class WerewolfHealth : MonoBehaviour {
		public int hp=1;
		public Transform PEffect;
		public GameController Gmaster;
		private Animator anim;
		private bool returntorun=true;
		int attack = Animator.StringToHash("AttackPlayer");
		int done = Animator.StringToHash("DoneAttack");
		AudioSource woof;
		AudioSource bite;

		void Start () {
			anim = GetComponent<Animator> ();
			AudioSource[] audios = GetComponents<AudioSource>();
			woof = audios[0];
			bite = audios[1];
		}
		
		void OnCollisionEnter(Collision info)
		{
			if(info.gameObject.name == "Third Person Character")
			{
				Gmaster.SubHealth(hp);
				bite.Play();
				Transform effect = Instantiate(PEffect, transform.position, transform.rotation) as Transform;
				Destroy (effect.gameObject,2);
			}
			anim.SetTrigger(attack);

		}
}