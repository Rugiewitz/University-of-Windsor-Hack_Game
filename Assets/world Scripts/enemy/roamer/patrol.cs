using UnityEngine;
using System.Collections;

public class patrol : MonoBehaviour {
	public Transform player;
	public Transform pod1;
	public Transform pod2;
	public Transform pod3;
	public Transform pod4;
	public int speed=2;
	private bool travelto1=true,travelto2=false,travelto3=false,travelto4=false;
	private bool playerInBounds,attack = false, travelback=false,metpoint=false; 
	private bool save1,save2,save3,save4;
	//private float Waittime;
	
	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Third Person Character"){
			playerInBounds = true;
		//	print("I see you");
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.name == "Third Person Character"){
			playerInBounds = false;
		}
	}
	void Update(){
		if(playerInBounds){
			attack=true;
			if(travelto1){
				save1=travelto1;
				travelto1=false;
			//	print("going back to pointA");
			}
			if(travelto2){
				save2=travelto2;
				travelto2=false;
			//	print("going back to pointB");
			}
			if(travelto3){
				save3=travelto3;
				travelto3=false;
			//	print("going back to pointc");
			}
			if(travelto4){
				save4=travelto4;
				travelto4=false;
			//	print("going back to pointd");
			}
		}
		if(attack){
			transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
			transform.LookAt(player);
		//	print("ATTAAAAAAAAAAAAAAAAAAAAAAACK");
		}
		if(playerInBounds==false && attack==true){
			travelback=true;
			attack=false;
		//	print("screw you i'm going home");

		}
		if(travelback){
			if(save1){
				travelto1=save1;
				save1=false;
			}
			if(save2){
				travelto2=save2;
				save2=false;
			}
			if(save3){
				travelto3=save3;
				save3=false;
			}
			if(save4){
				travelto4=save4;
				save4=false;
			}
		}
		if(travelto1){
			transform.position = Vector3.MoveTowards(transform.position,pod1.transform.position,speed*Time.deltaTime);
			transform.LookAt(pod1);
	//		print("going to A");
		}
		if(travelto2){
			transform.position = Vector3.MoveTowards(transform.position,pod2.transform.position,speed*Time.deltaTime);
			transform.LookAt(pod2);
	//		print("going to B");
		}
		if(travelto3){
			transform.position = Vector3.MoveTowards(transform.position,pod3.transform.position,speed*Time.deltaTime);
			transform.LookAt(pod3);
	//		print("going to C");
		}
		if(travelto4){
			transform.position = Vector3.MoveTowards(transform.position,pod4.transform.position,speed*Time.deltaTime);
			transform.LookAt(pod4);
		//	print("going to D");
		}
		if(metpoint==false){
		//	print("hONEY I'M HOOOOOOOOOOOOOOOOOOOOOME");
			if(travelto1==true && transform.position.x>pod1.transform.position.x-2 && transform.position.x<pod1.transform.position.x+2){
				if(transform.position.z>pod1.transform.position.z-2 && transform.position.z<pod1.transform.position.z+2){
					//metpoint=true;
			//		print("here at A");
					travelto1=false;
					travelto2=true;
				}				
			}
			if(travelto2==true && transform.position.x>pod2.transform.position.x-2 && transform.position.x<pod2.transform.position.x+2){
				if(transform.position.z>pod2.transform.position.z-2 && transform.position.z<pod2.transform.position.z+2){
					//metpoint=true;
			//		print("here at B");
					travelto2=false;
					travelto3=true;
				}				
			}
			if(travelto3==true && transform.position.x>pod1.transform.position.x-2 && transform.position.x<pod3.transform.position.x+2){
				if(transform.position.z>pod3.transform.position.z-2 && transform.position.z<pod3.transform.position.z+2){
					//metpoint=true;
				//	print("here at C");
					travelto3=false;
					travelto4=true;
				}				
			}
			if(travelto4==true && transform.position.x>pod4.transform.position.x-2 && transform.position.x<pod4.transform.position.x+2){
				if(transform.position.z>pod4.transform.position.z-2 && transform.position.z<pod4.transform.position.z+2){
					//metpoint=true;
				//	print("here at D");
					travelto4=false;
					travelto1=true;
				}				
			}
		}
	}
}