using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTable : MonoBehaviour
{


    [SerializeField]
    private GameObject selectItemTableUI;

    [SerializeField]
    private Camera uiCamera;

    [SerializeField]
    private CreateStageManager createStageManager;

    private Vector3 defaultPosition;

    private LerpMove lerpMove;

    private float moveTime = 0.3f;


    // Use this for initialization
    void Start()
    {
        defaultPosition = GetComponent<RectTransform>().localPosition;
        lerpMove = new LerpMove();
    }

    // Update is called once per frame
    void Update()
    {

        UpItemTable();
        DownItemTable();
        //SetIsCanSelectObject();
        lerpMove.Update(gameObject);
        Debug.Log(lerpMove.IsMove);
        //Debug.Log(lerpMove.IsEnd);
    }

    /// <summary>
    /// アイテムテーブルを上に上げる
    /// </summary>
    private void UpItemTable()
    {
        // if(lerpMove.IsMove)
        if (!createStageManager.IsCanSelectObject && TouchObject.IsTouchObject(selectItemTableUI, uiCamera))
        {
            //移動終了地点の設定
            Vector3 moveEndPosition = GetComponent<RectTransform>().localPosition + new Vector3(0, 130, 0);
            //移動開始
            lerpMove.StartMove(GetComponent<RectTransform>().localPosition, moveEndPosition, moveTime);
            //オブジェクトの子供内で一番下に(描画順を手前に持ってくるため)
            transform.SetAsLastSibling();
            StartCoroutine(ChangeIsCanSelectObject());
        }
    }

    /// <summary>
    /// アイテムテーブルを下に下げる
    /// </summary>
    private void DownItemTable()
    {
        if (createStageManager.IsCanSelectObject && TouchObject.IsTouchObject(selectItemTableUI, uiCamera))
        {
            lerpMove.StartMove(GetComponent<RectTransform>().localPosition, defaultPosition, moveTime);
            StartCoroutine(ChangeIsCanSelectObject());
        }
    }

    private IEnumerator ChangeIsCanSelectObject()
    {
        yield return new WaitForSeconds(moveTime);

        createStageManager.IsCanSelectObject = !createStageManager.IsCanSelectObject;
    }
}
