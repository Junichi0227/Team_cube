using UnityEngine;
using System.Collections;

public class CameraFirstPos : MonoBehaviour {
	public Camera maincamera; // 使用するカメラ
	private Vector3 Firstposition;
	private Quaternion Firstrotation;

	// Use this for initialization
	void Start () {
		Firstposition = maincamera.transform.position;
		Firstrotation = maincamera.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FirstPositionCamera(){
		maincamera.transform.position = Firstposition;
		maincamera.transform.rotation = Firstrotation;
		//maincamera.transform.Rotate(Firstrotation);
	}
}
