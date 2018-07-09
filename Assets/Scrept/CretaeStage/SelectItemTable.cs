using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectItemTable : MonoBehaviour
{

    Subject<GameObject> subject = new Subject<GameObject>();


    [SerializeField]
    private Camera uiCamera;
    /// <summary>
    /// ブロックテーブル
    /// </summary>
    [SerializeField]
    private GameObject blockTab;

    /// <summary>
    /// プレイヤー１テーブル
    /// </summary>
    [SerializeField]
    private GameObject Player1SkinTab;

    /// <summary>
    /// プレイヤー2テーブル
    /// </summary>
    [SerializeField]
    private GameObject Player2SkinTab;

    /// <summary>
    /// 選択したテーブル
    /// </summary>
    private GameObject selectTab;


    public IObservable<GameObject> SelectItemTableEvent
    {
        get { return subject; }
    }

    // Use this for initialization
    void Start()
    {
       
    }

    private void Update()
    {
        if (TouchObject.IsTouchObject(blockTab, uiCamera))
        {
            selectTab = blockTab;
            subject.OnNext(selectTab);
        }
        else if (TouchObject.IsTouchObject(Player1SkinTab, uiCamera))
        {
            selectTab = Player1SkinTab;
            subject.OnNext(selectTab);
        }
        else if(TouchObject.IsTouchObject(Player2SkinTab,uiCamera))
        {
            selectTab = Player2SkinTab;
            subject.OnNext(selectTab);
        }
    }


}
