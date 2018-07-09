using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGetItem : MonoBehaviour
{

    [SerializeField]
    private CreateStageItemData createStageItemData;

    /// <summary>
    /// ブロックを並べる画像
    /// </summary>
    [SerializeField]
    private GameObject blockIconImage;

    /// <summary>
    /// プレイヤー1のスキンを並べる画像
    /// </summary>
    [SerializeField]
    private GameObject player1SkinImage;

    /// <summary>
    /// プレイヤー2のスキンを並べる画像
    /// </summary>
    [SerializeField]
    private GameObject player2SkinImage;


    /// <summary>
    /// 設置できる最大数
    /// </summary>
    [SerializeField]
    private int installedMax;

    /// <summary>
    /// 現在の設置数
    /// </summary>
    private int numberOfInstalled;

    /// <summary>
    /// 所持しているブロックのアイコン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getBlocksIcon;

    /// <summary>
    /// 所持しているブロック
    /// (配置するオブジェクト)
    /// </summary>
    private List<GameObject> getItems;

    public List<GameObject> GetItems
    {
        get { return getItems; }
    }


    /// <summary>
    /// 所持しているプレイヤー１のスキン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getPlayer1SkinIcons;

    /// <summary>
    /// 所持しているプレイヤー2のスキン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getPlayer2SkinIcons;

    /// <summary>
    /// アイコン配置の開始位置
    /// </summary>
    [SerializeField]
    private GameObject iconStartPosition;

    /// <summary>
    /// UI用のカメラを取得
    /// </summary>
    [SerializeField]
    private Camera uiCamera;


    /// <summary>
    /// 選択中のオブジェクト
    /// </summary>
    private GameObject selectObject;

    /// <summary>
    /// オブジェクトを選択できる状態かどうか
    /// </summary>
    private bool isSelectObject;


    /// <summary>
    /// オブジェクトを選択できる状態かどうか
    /// </summary>
    private bool isCanSelectObject;
    public bool IsCanSelectObject
    {
        get { return isCanSelectObject; }
        set { this.isCanSelectObject = value; }
    }

    /// <summary>
    /// 使用Listの初期化
    /// </summary>
    private void InitList()
    {
        getBlocksIcon = new List<GameObject>();
        getItems = new List<GameObject>();
        getPlayer1SkinIcons = new List<GameObject>();
        getPlayer2SkinIcons = new List<GameObject>();
    }

    /// <summary>
    /// 自分の所持アイテムの追加
    /// </summary>

    public void SetItem(int[]isGetItems,List<GameObject>allItemIcons,List<GameObject>allItemObjects)
    {
        InitList();
        for (int i = 0; i < isGetItems.Length; i++)
        {
            //ブロックを所持していたら
            if (isGetItems[(int)allItemObjects[i].GetComponent<ItemInformation>().ItemType] == 1)
            {
                switch(allItemObjects[i].GetComponent<ItemInformation>().ItemField)
                {
                    case ItemField.BLOCK:
                        //所持ブロックリストに追加
                        getBlocksIcon.Add(allItemIcons[i]);
                        getItems.Add(allItemObjects[i]);
                        break;
                    case ItemField.FLOOR:
                        //所持ブロックリストに追加
                        getBlocksIcon.Add(allItemIcons[i]);
                        getItems.Add(allItemObjects[i]);
                        break;
                    case ItemField.GOAL:
                        //所持ブロックリストに追加
                        getBlocksIcon.Add(allItemIcons[i]);
                        getItems.Add(allItemObjects[i]);
                        break;
                    case ItemField.PLAYER1SKIN:
                        //所持プレイヤー1スキンリストに追加
                        getPlayer1SkinIcons.Add(allItemIcons[i]);
                        getItems.Add(allItemObjects[i]);
                        break;
                    case ItemField.PLAYER2SKIN:
                        //所持プレイヤー1スキンリストに追加
                        getPlayer2SkinIcons.Add(allItemIcons[i]);
                        getItems.Add(allItemObjects[i]);
                        break;
                }         
            }
        }
        //設定
        SetItemIcon();
    }

    /// <summary>
    /// アイテムアイコンの設定
    /// </summary>
    private void SetItemIcon()
    {
        SetBlockIcon();
        SetPlayer1SkinIcon();
        SetPlayer2SkinIcon();
    }

    /// <summary>
    /// ブロックアイコンの設定
    /// </summary>
    private void SetBlockIcon()
    {
        for (int i = 0; i < getBlocksIcon.Count; i++)
        {
            //生成
            GameObject iconObject = Instantiate(getBlocksIcon[i]);
            //親オブジェクトを設定
            iconObject.transform.SetParent(blockIconImage.transform, false);
            //座標の設定
            float positionX = iconStartPosition.transform.position.x + (i * 1.5f);
            iconObject.transform.position = new Vector3(positionX, iconObject.transform.position.y, iconObject.transform.position.z);
        }
    }

    /// <summary>
    /// プレイヤー１スキンアイコンの設定
    /// </summary>
    private void SetPlayer1SkinIcon()
    {
        for (int i = 0; i < getPlayer1SkinIcons.Count; i++)
        {
            //生成
            GameObject iconObject = Instantiate(getPlayer1SkinIcons[i]);
            //親オブジェクトを設定
            iconObject.transform.SetParent(player1SkinImage.transform, false);
            //座標の設定
            float positionX = iconStartPosition.transform.position.x + (i * 1.5f);
            iconObject.transform.position = new Vector3(positionX, iconObject.transform.position.y, iconObject.transform.position.z);
        }
    }

    /// <summary>
    /// x
    /// </summary>
    private void SetPlayer2SkinIcon()
    {
        for (int i = 0; i < getPlayer2SkinIcons.Count; i++)
        {
            //生成
            GameObject iconObject = Instantiate(getPlayer2SkinIcons[i]);
            //親オブジェクトを設定
            iconObject.transform.SetParent(player2SkinImage.transform, false);
            //座標の設定
            float positionX = iconStartPosition.transform.position.x + (i * 1.5f);
            iconObject.transform.position = new Vector3(positionX, iconObject.transform.position.y, iconObject.transform.position.z);
        }
    }

}
