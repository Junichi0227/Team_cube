﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageManager : MonoBehaviour
{


    /// <summary>
    /// ブロックを並べる画像
    /// </summary>
    [SerializeField]
    private GameObject blockIconImage;


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
    /// 全てのブロックのリスト
    /// </summary>
    [SerializeField]
    private List<GameObject> allItemObjects;

    /// <summary>
    /// 所持しているブロックのアイコン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getBlocksIcon;

    /// <summary>
    /// 所持しているブロック
    /// (配置するオブジェクト)
    /// </summary>
    private List<GameObject> getBlocks;

    /// <summary>
    /// 所持しているプレイヤー１のスキン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getPlayer1SkinIcons;

    /// <summary>
    /// 所持しているプレイヤー1のスキン
    /// (配置するオブジェクト)
    /// </summary>
    private List<GameObject> getPlayer1Skins;

    /// <summary>
    /// 所持しているプレイヤー2のスキン
    /// (UIとして表示)
    /// </summary>
    private List<GameObject> getPlayer2SkinIcons;

    /// <summary>
    /// 所持しているプレイヤー2のスキン
    /// (配置するオブジェクト)
    /// </summary>
    private List<GameObject> getPlayer2Skins;





    ///// <summary>
    ///// プレイヤー1のスキン
    ///// </summary>
    //[SerializeField]
    //private List<GameObject> player1Sukin;

    ///// <summary>
    ///// プレイヤー2のスキン
    ///// </summary>
    //[SerializeField]
    //private List<GameObject> player2Sukin;

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

    private bool isSelectObject;



    void Start()
    {
        //List初期化まとめ
        InitList();
        AddMyItem();
    }



    void Update()
    {
        TouchItemIcon();
        ArrangementObject();
    }

    /// <summary>
    /// 使用Listの初期化
    /// </summary>
    private void InitList()
    {
        getBlocksIcon = new List<GameObject>();
        getBlocks = new List<GameObject>();
        getPlayer1SkinIcons = new List<GameObject>();
        getPlayer1Skins = new List<GameObject>();
        getPlayer2SkinIcons = new List<GameObject>();
        getPlayer2Skins = new List<GameObject>();
    }

    /// <summary>
    /// 自分の所持アイテムの追加
    /// </summary>

    private void AddMyItem()
    {
        //アイテム所持判定を取得
        int[] isGetItems = FindObjectOfType<CreateStageItemData>().IsGetBlocks;
        //全てのアイテム一覧を取得
        List<GameObject> allItemSkins = FindObjectOfType<CreateStageItemData>().AllItemIcons;

        for (int i = 0; i < isGetItems.Length; i++)
        {
            //ブロックを所持していたら
            if (isGetItems[allItemSkins[i].GetComponent<ItemInformation>().ID] == 1)
            {
                switch(allItemSkins[i].GetComponent<ItemInformation>().Type)
                {
                    case ItemType.BLOCK:
                        //所持ブロックリストに追加
                        getBlocksIcon.Add(allItemSkins[i]);
                        getBlocks.Add(allItemObjects[i]);
                        break;
                    case ItemType.PLAYER1SKIN:
                        //所持プレイヤー1スキンリストに追加
                        getPlayer1SkinIcons.Add(allItemSkins[i]);
                        getPlayer1Skins.Add(allItemObjects[i]);
                        break;
                    case ItemType.PLAYER2SKIN:
                        //所持プレイヤー1スキンリストに追加
                        getPlayer1SkinIcons.Add(allItemSkins[i]);
                        getPlayer1Skins.Add(allItemObjects[i]);
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
    /// アイコンのタッチ判定
    /// </summary>
    private void TouchItemIcon()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Rayを飛ばす
            Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                //オブジェクトにItemIDがアタッチされたいなかったら処理しない
                if (!hit.collider.gameObject.GetComponent<ItemInformation>()) return;
                foreach (var b in getBlocks)
                {
                    //タッチしたオブジェクトと同じIDのオブジェクトを選択
                    if (b.GetComponent<ItemInformation>().ID == hit.collider.gameObject.GetComponent<ItemInformation>().ID)
                    {
                        selectObject = b;
                        isSelectObject = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// オブジェクトの配置(仮)
    /// </summary>
    private void ArrangementObject()
    {
        //選択中のオブジェクトが無かったら処理しない。
        if (!isSelectObject) return;
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition;
            clickPosition.z = 10;
            GameObject item = Instantiate(selectObject, Camera.main.ScreenToWorldPoint(clickPosition), selectObject.transform.rotation);
        }

    }
}