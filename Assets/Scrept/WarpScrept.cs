using UnityEngine;
using System.Collections;

public class WarpScrept : MonoBehaviour {

	public GameObject warp1;

	public GameObject gettarget(){
		return warp1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollision(Collision other){
		Debug.Log ("In");
		other.gameObject.transform.position = warp1.transform.position;
	}*/

	public void Warp(GameObject warp1){
		this.gameObject.transform.position = warp1.transform.position;
	}
}
