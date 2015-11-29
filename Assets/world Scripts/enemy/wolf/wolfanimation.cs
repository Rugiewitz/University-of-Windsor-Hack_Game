using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class wolfanimation : MonoBehaviour {
	public scent scents;
	public Transform player;
	public float speed=2.0f;
	public Transform sq1;
	public Transform sq2;
	public Transform sq3;
	public Transform sq4;
	int counter=0, foundcounter=0;
	private Animator anim;
	private bool playerInBounds=false,howl=false,finishhowl=false, playonce=true,settime=false, foundmyBalls=false, chasehuman=false;
	private bool patrol=true,patrol1 = true, patrol2 = false, patrol3 = false, patrol4 = false;
	private float saveTime;
	
	List<GameObject> list = scent.copylist;
	int size=0;

	int howling = Animator.StringToHash("Howl");
	int run = Animator.StringToHash("PlayerInSight");
	AudioSource woof;
	AudioSource bite;


 
     //I'm using a coroutine to be sure the list in Script1 is created before I print the items in the list.
     void Start(){
		anim = GetComponent<Animator> ();// establish animations
		AudioSource[] audios = GetComponents<AudioSource>();// establish audio being held in an array
		woof = audios[0];//establish position in the array of the "growl sound"


	}
	
	void OnTriggerStay(Collider other){//this collider is for the giant invisiable circle/bubble, it is represents the "sight-bubble"
		if(other.gameObject.name == "Third Person Character"){// this if statement will work if you're in the range of the wolf
			playerInBounds = true;
			howl=true;
			chasehuman=true;
			foundmyBalls=false;
			patrol=false;
			patrol1=false;
			patrol2=false;
			patrol3=false;
			patrol4=false;
			//print("I see you");
		}
		if (playerInBounds == false && foundmyBalls == false) {
			list = scent.copylist;
			size=list.Count;
			//print (size);
			if (other.gameObject.name == "Sphere") {
				howl = true;
				foundmyBalls = true;
				counter++;
				patrol=false;
				patrol1=false;
				patrol2=false;
				patrol3=false;
				patrol4=false;
				//print(howl);
			//	print (foundmyBalls);
			}
		}
	}

	void OnTriggerExit(Collider other){//it will leave the player alone if the player isn't in the bubble/ they outrun him
		if(other.gameObject.name == "Third Person Character"){
			playerInBounds = false;
		}
	}
	

	void Update () {
		if (patrol == true) {
			if(patrol1==true){
				transform.LookAt (2 * transform.position - sq2.position);
				transform.position = Vector3.MoveTowards (transform.position, sq2.position, speed * Time.deltaTime);
				if(Vector3.Distance (transform.position, sq2.position)<1){
					patrol1=false;
					patrol2=true;
				}
			}
			if(patrol2==true){
				transform.LookAt (2 * transform.position - sq3.position);
				transform.position = Vector3.MoveTowards (transform.position, sq3.position, speed * Time.deltaTime);
				if(Vector3.Distance (transform.position, sq3.position)<1){
					patrol2=false;
					patrol3=true;
				}
			}
			if(patrol3==true){
				transform.LookAt (2 * transform.position - sq4.position);
				transform.position = Vector3.MoveTowards (transform.position, sq4.position, speed * Time.deltaTime);
				if(Vector3.Distance (transform.position, sq4.position)<1){
					patrol3=false;
					patrol4=true;
				}
			}
			if(patrol4==true){
				transform.LookAt (2 * transform.position - sq1.position);
				transform.position = Vector3.MoveTowards (transform.position, sq1.position, speed * Time.deltaTime);
				if(Vector3.Distance (transform.position, sq1.position)<1){
					patrol4=false;
					patrol1=true;
				}
			}

				}
		if (chasehuman == true) {
			if (howl == true) {
								if (settime == false) {
										saveTime = Time.time;
										settime = true;
								}
								if (playonce == true) {
										woof.Play ();
										playonce = false;
								}
								anim.SetTrigger (howling);
								if (Time.time - saveTime >= 7) {
										finishhowl = true;
								}
						}
						if (finishhowl == true) {
								anim.SetTrigger ("PlayerInSight");
								transform.LookAt (2 * transform.position - player.position);
								transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
						}
				}
		if(foundmyBalls==true && chasehuman == false){
			list = scent.copylist;
			size=list.Count;
			if (howl == true) {
				if (settime = false) {
					saveTime = Time.time;
					settime = true;
				}
				if (playonce == true) {
					woof.Play ();
					playonce = false;
				}
				anim.SetTrigger (howling);
				if (Time.time - saveTime >= 7) {
					finishhowl = true;
				}
			}
			if (finishhowl == true) {
				anim.SetTrigger ("PlayerInSight");
				transform.LookAt (2 * transform.position - list[counter].transform.position);
				transform.position = Vector3.MoveTowards (transform.position, list[counter].transform.position, speed * Time.deltaTime);
				if(Vector3.Distance (transform.position, list[counter].transform.position)<1)
					counter++;

			}
			
		}
	}
}
