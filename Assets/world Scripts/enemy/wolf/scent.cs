using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class scent : MonoBehaviour {
	public Transform player;
	public List<GameObject> circles = new List<GameObject>();// stores each object of the balls droped in order as a node on a list.
	public static List<GameObject> copylist = new List<GameObject> ();
	private bool start=true,produce=false;
	private int counter=0;
	float number;
	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "Third Person Character") {
			produce = false;
			print ("false");
		}
	}
	void OnTriggerExit(Collider other){//it will leave the player alone if the player isn't in the bubble/ they outrun him
		if(other.gameObject.name == "Third Person Character"){
			produce = true;
			print ("true");
		}
	}
	void Update () {
		if (produce == true){
				if (start == true) {//once the program start
						GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);//creates a sphere 
						sphere.transform.position = player.transform.position; // adds it at the position where the player walks
						//sphere.renderer.enabled=false; // this will make the sphere invisiable 
						sphere.collider.isTrigger = true; // this will add the trigger colider to walk through the spheres
						sphere.AddComponent<Rigidbody> ();
						sphere.renderer.enabled = false;
						sphere.rigidbody.isKinematic = true;
						sphere.rigidbody.useGravity = false;
						circles.Add (sphere); // adds it to the list
						start = false; // first position of the list has been istablised, it will continue 
						counter++;// keeps track of the balls, increase it by one
				}
				GameObject temp = circles [counter - 1];//take the previous position of the ball
				number = Vector3.Distance (temp.transform.position, player.transform.position);// compare the previous position with the current position of the player
				//print (number);
				if (number > 2.0f) {// if the distance between the ball and player are less then this size, it will make another ball
						GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);//creates new ball
						sphere.transform.position = player.transform.position;// changes it to the position of the player
						//sphere.renderer.enabled = false;// invisable
						sphere.collider.isTrigger = true;// walk through the ball with no collision 
						sphere.AddComponent<Rigidbody> ();
						sphere.renderer.enabled = false;
						sphere.rigidbody.isKinematic = true;
						sphere.rigidbody.useGravity = false;
						circles.Add (sphere);//adds it to the list
						counter++;// increase the counter
				}
				//print (circles.Count);
				copylist = circles;
		}
		//print (circles.Count);
	}

}
