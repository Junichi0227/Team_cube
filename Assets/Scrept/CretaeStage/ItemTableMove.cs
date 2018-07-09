using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ItemTableMove : MonoBehaviour
{

    /// <summary>
    /// 基本の位置
    /// </summary>
    private Vector3 defaultPosition;

    /// <summary>
    /// Lerp移動クラス
    /// </summary>
    private LerpMove lerpMove;

    /// <summary>
    /// 移動時間(仮)
    /// </summary>
    private float moveTime = 0.3f;

    /// <summary>
    /// アイテムテーブルを選ぶ処理
    /// </summary>
    [SerializeField]
    private SelectItemTable selectItemTable;

    /// <summary>
    /// テーブルが出現しているかどうか
    /// </summary>
    private bool isAppearanceTable = false;

    [SerializeField]
    private List<GameObject> buttonObjects;


    // Use this for initialization
    void Start()
    {
        selectItemTable.SelectItemTableEvent.Subscribe(num =>
        {
            UpItemTable(num);
            DownItemTable(num);
        });

        lerpMove = new LerpMove();
    }

    // Update is called once per frame
    void Update()
    {
        lerpMove.Update();
    }

    /// <summary>
    /// アイテムテーブルを上に上げる
    /// </summary>
    private void UpItemTable(GameObject selectTab)
    {
        //テーブルが出現されていなかったら
        if (!isAppearanceTable)
        {
            //親オブジェクトを取得
            GameObject selectTable = selectTab.transform.parent.gameObject;
            //基本の位置を設定
            defaultPosition = selectTable.GetComponent<RectTransform>().localPosition;
            //移動終了地点の設定
            Vector3 moveEndPosition = selectTable.GetComponent<RectTransform>().localPosition + new Vector3(0, 130, 0);
            //移動開始
            lerpMove.StartMove(selectTable,selectTable.GetComponent<RectTransform>().localPosition, moveEndPosition, moveTime);
            //オブジェクトの子供内で一番下に(描画順を手前に持ってくるため)
            selectTable.transform.SetAsLastSibling();
            //SetButtonsEnabled(true);
            //出現判定を設定
            StartCoroutine(ChangeIsAppearanceTable());
            
        }
    }

    /// <summary>
    /// アイテムテーブルを下に下げる
    /// </summary>
    private void DownItemTable(GameObject selectTab)
    {
        if (isAppearanceTable)
        {
            GameObject selectTable = selectTab.transform.parent.gameObject;
            lerpMove.StartMove(selectTable,selectTable.GetComponent<RectTransform>().localPosition, defaultPosition, moveTime);
            //FindObjectOfType<SetButtonActive>().SetObjectActive(false);
            //SetButtonsEnabled(false);
            StartCoroutine(ChangeIsAppearanceTable());
        }
    }

    private IEnumerator ChangeIsAppearanceTable()
    {
        yield return new WaitForSeconds(moveTime);

        isAppearanceTable = !isAppearanceTable;
    }

  
}
