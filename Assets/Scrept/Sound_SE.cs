using UnityEngine;
using System.Collections;

public class Sound_SE : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	public void Click_SE(){
		Debug.Log ("IN");
		audioSource.PlayOneShot (sound,1f);
	}
}
