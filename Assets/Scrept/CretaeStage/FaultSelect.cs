using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class FaultSelect : MonoBehaviour {

    Subject<int> subject = new Subject<int>();

    [SerializeField]
    Button button1;

    [SerializeField]
    Button button2;

    [SerializeField]
    Button button3;

    [SerializeField]
    Button floorButton;


    /// <summary>
    /// 現在の階層
    /// </summary>
    int currentFault;


    public IObservable<int> OnFaultButtonEvent
    {
        get { return subject; }
    }


	// Use this for initialization
	void Start () {

        button1.onClick.AddListener(() =>
        {
            currentFault = 1;
            subject.OnNext(currentFault);
        });

        button2.onClick.AddListener(() =>
        {
            currentFault = 2;
            subject.OnNext(currentFault);
        });

        button3.onClick.AddListener(() =>
        {
            currentFault = 3;
            subject.OnNext(currentFault);
        });

        floorButton.onClick.AddListener(() =>
        {
            currentFault = 0;
            subject.OnNext(currentFault);
        });
            
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
