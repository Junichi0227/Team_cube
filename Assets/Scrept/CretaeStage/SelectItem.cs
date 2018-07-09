using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// アイテムの選択
/// </summary>
public class SelectItem: MonoBehaviour {


    [SerializeField]
    private Camera uiCamera;

    [SerializeField]
    private SetGetItem setGetItem;

    Subject<GameObject> subject = new Subject<GameObject>();


    public IObservable<GameObject> SelectItemIconEvent
    {
        get { return subject; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray,out hit))
            {
                if (!hit.collider.gameObject.GetComponent<ItemInformation>()) return;
                 foreach(var b in setGetItem.GetItems)
                {
                    //タッチしたオブジェクトと所持アイテムと同じ種類のものを設定
                    if(b.GetComponent<ItemInformation>().ItemType == hit.collider.gameObject.GetComponent<ItemInformation>().ItemType)
                    {
                        Debug.Log(b.GetComponent<ItemInformation>().ItemType);
                        subject.OnNext(b);
                    }
                }
            }
        }
		
	}
}
