using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class InstantiateStageObject : MonoBehaviour
{

    Subject<GameObject> subject = new Subject<GameObject>();

    public IObservable<GameObject> OnSetObjectEvent
    {
        get { return subject; }
    }

    /// <summary>
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
    private SelectItem selectItemController;

    /// <summary>
    /// 選択中のオブジェクト
    /// </summary>
    private GameObject selectItemObject;

    /// <summary>
    /// 現在のマス
    /// </summary>
    private Squares currentSquares;

    /// <summary>
    /// 現在の階層
    /// </summary>
    private int currentFault;

    /// <summary>
    /// 生成する場所に表示するオブジェクト
    /// </summary>
    private GameObject instantiatePointObject;

    private List<GameObject> createStageObjects = new List<GameObject>();
    public List<GameObject>CreateStageObjects
    {
        get { return createStageObjects; }
    }


    [SerializeField]
    private GameObject floorCursor;

    [SerializeField]
    private GameObject blockCursor;

    [SerializeField]
    private Material cursorMaterial;


    [SerializeField]
    private Button playStartButton;

    private Button bu;

    // Use this for initialization
    void Start()
    {
       
       // playStartButton.SetActive(false);
        currentSquares = new Squares(0, 0);
        currentFault = 0;
        SetPointObject();
        createStageObjects = new List<GameObject>();

        //アイテムを選ぶと呼び出される
        selectItemController.SelectItemIconEvent.
            Subscribe(num =>
                {
                    selectItemObject = num;
                    //もしもスキンだったら重力を無効にする
                    if (selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER1SKIN ||
                   selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER2SKIN)
                    {
                        selectItemObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                    SetPointObject();
                });


        //十字キーを押すと呼び出される
        crossKeyController.CrossControllerEvent.Subscribe(num =>
    {

        currentSquares = num;
        instantiatePointObject.transform.position = InstantiateObjectPosition();
    });


        //階層ボタンを呼ぶと呼び出される
        faultSelect.OnFaultButtonEvent.Subscribe(num =>
        {
            currentFault = num;
            SetPointObject();
        });


    }

    // Update is called once per frame
    void Update()
    {
        if(IsSetGoal()&&IsSetPlayer1Skin()&&IsSetPlayer2Skin())
        {
            playStartButton.interactable = true;
        }

    }

    /// <summary>
    /// ポイントの設定
    /// </summary>
    private void SetPointObject()
    {
        if (selectItemObject != null)
        {
            Destroy(instantiatePointObject);
            Debug.Log("アイテム選択");
        }

        //アイテムが選ばれていない状態
        if (selectItemObject == null)
        {
            if (currentFault == 0)
                instantiatePointObject = Instantiate(floorCursor, InstantiateObjectPosition(), floorCursor.transform.rotation);
            else
                instantiatePointObject = Instantiate(blockCursor, InstantiateObjectPosition(), blockCursor.transform.rotation);
        }
        //選ばれていたら
        else
        {
            //床じゃないときに階層が一番下だったら階層を1に設定する
            if (!(selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.FLOOR||
                selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.GOAL) && currentFault == 0)
            {
                currentFault = 1;
            }

            instantiatePointObject = Instantiate(selectItemObject, InstantiateObjectPosition(), selectItemObject.transform.rotation);

            //マテリアル設定
            instantiatePointObject.GetComponent<MeshRenderer>().material = cursorMaterial;
            instantiatePointObject.GetComponent<Collider>().enabled = false;

        }
    }
    private Vector3 InstantiateObjectPosition()
    {
        //階層が一番下だったら
        if (currentFault == 0)
        {
            return new Vector3(currentSquares.ROW, -0.1f, currentSquares.LINE);
        }
        //下以外
        else
        {
            //床だったら
            if (selectItemObject != null &&
                ( selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.FLOOR|| 
                selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.GOAL))
            {
                return new Vector3(currentSquares.ROW, currentFault - 0.1f, currentSquares.LINE);
            }
            return new Vector3(currentSquares.ROW, currentFault - 0.5f, currentSquares.LINE);
        }
    }

    /// <summary>
    /// 生成
    /// </summary>
    public void InstantiateObject()
    {
        //選択中のオブジェクトが無かったら処理しない
        if (selectItemObject == null) return;

        if (IsSetPlayer1Skin() && selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER1SKIN ||
            IsSetPlayer2Skin() && selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER2SKIN||
            IsSetGoal()&&selectItemObject.GetComponent<ItemInformation>().ItemField == ItemField.GOAL) return;

        foreach (var c in createStageObjects)
        {
            //同じ場所には配置できない
            if (c.GetComponent<ItemInformation>().Squares == currentSquares && c.GetComponent<ItemInformation>() &&
                c.GetComponent<ItemInformation>().Fault == currentFault) return;
        }



        GameObject gameObject = Instantiate(selectItemObject, InstantiateObjectPosition(), instantiatePointObject.transform.rotation);
        gameObject.GetComponent<ItemInformation>().Squares = currentSquares;
        gameObject.GetComponent<ItemInformation>().Fault = currentFault;
        createStageObjects.Add(gameObject);

    }


    /// <summary>
    /// プレイヤースキンがセットされているかどうか
    /// </summary>
    /// <returns></returns>
    private bool IsSetPlayer1Skin()
    {
        foreach (var c in createStageObjects)
        {
            //選択中のオブジェクトがPlayer1スキンで配置しているオブジェクトの中にPlayer1スキンがあったら
            if (c.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER1SKIN) return true;
        }

        return false;
    }

    private bool IsSetPlayer2Skin()
    {
        foreach (var c in createStageObjects)
        {
            //選択中のオブジェクトがPlayer2スキンで配置しているオブジェクトの中にPlayer2スキンがあったら
            if (c.GetComponent<ItemInformation>().ItemField == ItemField.PLAYER2SKIN) return true;
        }

        return false;
    }

    private bool IsSetGoal()
    {
        int goalCount = 0;
        foreach (var c in createStageObjects)
        {
            if(c.GetComponent<ItemInformation>().ItemField == ItemField.GOAL)
            {
                goalCount++;
            }
        }
        if (goalCount == 2) return true;

        return false;
    }
}
