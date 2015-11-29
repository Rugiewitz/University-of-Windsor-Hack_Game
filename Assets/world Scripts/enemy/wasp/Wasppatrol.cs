using UnityEngine;
using System.Collections;

public class Wasppatrol : MonoBehaviour {
	public Transform player;
	public float chasespeed=1.5f;
	public float flyspeed=3.0f;
	public int x1=-15;
	public int x2=180;
	public int z1=157;
	public int z2=-30;
	public int landheight=3;
	public int maxheight=11;
	private bool land=false, lift=false,locationflyto=false, waitandsee=false, attack=false;
	private bool random=true;
	private bool playerInBounds;
	private int newx=0,newz=0;
	private float saveTime;
	
	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Third Person Character"){
			playerInBounds = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.name == "Third Person Character"){
			playerInBounds = false;
		}
	}

	void Update () {
	//=======================================================================
		if(random){
			newx = Random.Range (x1, x2);
			newz = Random.Range (z1, z2);
			random = false;
			locationflyto=true;
		}
	//=======================================================================
		if(locationflyto){
			transform.LookAt(new Vector3 (newx,maxheight,newz));
			if(newz<transform.position.z)
				transform.position+=-Vector3.forward*flyspeed*Time.deltaTime; 
				else
				transform.position+=Vector3.forward*flyspeed*Time.deltaTime; 
				
				if(newx<transform.position.x)
				transform.position+=Vector3.left*flyspeed*Time.deltaTime; 
				else
				transform.position+=-Vector3.left*flyspeed*Time.deltaTime;
			if(transform.position.x>newx-10 && transform.position.x<newx+10)
				if(transform.position.z>newz-10 && transform.position.z<newz+10){
					locationflyto=false;
					land=true;
					saveTime=Time.time;
				}
					
		
		}
	//==========================================================================
        if(land){
			if(transform.position.y>landheight)
				transform.position+=(-Vector3.up*flyspeed*Time.deltaTime);
			if(Time.time-saveTime>=8 || transform.position.y<=landheight){
				land=false;
				waitandsee=true;
				saveTime=Time.time;
			}
				
		}
	//=======================================================================
		if(waitandsee){
			if(playerInBounds){
				if(player.position.x!=transform.position.x && player.position.z!=transform.position.z ){
					if(player.position.z<transform.position.z)
						transform.position+=-Vector3.forward*chasespeed*Time.deltaTime; 
					else
						transform.position+=Vector3.forward*chasespeed*Time.deltaTime; 
					
					if(player.position.x<transform.position.x)
						transform.position+=Vector3.left*chasespeed*Time.deltaTime; 
					else
						transform.position+=-Vector3.left*chasespeed*Time.deltaTime; 
				}
				transform.LookAt (player);
			}
			if(Time.time-saveTime>=8 && attack==false){
				lift=true;
				waitandsee=false;
			}
		}
	//========================================================================
		if(lift){
			if(transform.position.y<maxheight)
				transform.position+=(Vector3.up*2*Time.deltaTime);
			if(transform.position.y>=maxheight){
				lift=false;
				random=true;
			}
				
		}
		
	}
}
