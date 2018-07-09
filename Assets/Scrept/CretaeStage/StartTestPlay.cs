using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StartTestPlay : MonoBehaviour {

    [SerializeField]
    private GameObject canvas;


    [SerializeField]
    private GameObject buttons;


	// Use this for initialization
	void Start () {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            canvas.SetActive(false);
            Instantiate(buttons);
            FindObjectOfType<RotateCube>().GetComponent<Rigidbody>().useGravity = true;
            FindObjectOfType<RotateCube2>().GetComponent<Rigidbody>().useGravity = true;
        });

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
