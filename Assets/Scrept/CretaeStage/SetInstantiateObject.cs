using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SetInstantiateObject : MonoBehaviour {


    Subject<GameObject> subject = new Subject<GameObject>();

    public IObservable<GameObject> OnSetObjectEvent
    {
        get { return subject; }
    }

    // <summary>
    /// 十字キーの制御
    /// </summary>
    [SerializeField]
    private CrossKeyController crossKeyController;

    /// <summary>
    /// 階層の選択
    /// </summary>
    [SerializeField]
    private FaultSelect faultSelect;

    /// <summary>
    /// アイテムの選択
    /// </summary>
    [SerializeField]
    private SelectItem selectItem;

    /// <summary>
    /// 現在のマス
    /// </summary>
    private Squares currentSquares;

    /// <summary>
    /// 現在の階層
    /// </summary>
    private int currentFault;


    private GameObject selectItemObject;

    private GameObject instantiatePointObject;


    // Use this for initialization
    void Start () {


        selectItem.SelectItemIconEvent.TakeWhile(num => num != selectItemObject).Subscribe(num =>
        {
            selectItemObject = num;
            instantiatePointObject = Instantiate(selectItemObject);
            //Debug.Log(num.name);
        });

        crossKeyController.CrossControllerEvent.Subscribe(num =>
        {
            currentSquares = num;
            instantiatePointObject.transform.position = InstantiateObjectPosition();
        });

        faultSelect.OnFaultButtonEvent.Subscribe(num =>
        {
            currentFault = num;
            instantiatePointObject.transform.position = InstantiateObjectPosition();
        });


    }

    private Vector3 InstantiateObjectPosition()
    {
        if (currentFault == 4)
        {
            return new Vector3(currentSquares.ROW, -0.1f, currentSquares.LINE);
        }
        else
        {
            return new Vector3(currentSquares.ROW, 1.5f / currentFault, currentSquares.LINE);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
