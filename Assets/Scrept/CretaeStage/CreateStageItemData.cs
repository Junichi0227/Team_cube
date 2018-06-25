using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageItemData : MonoBehaviour
{
    const string saveKey = "ItemData";

    /// <summary>
    /// 全てのブロックもアイコンのリスト
    /// </summary>
    [SerializeField]
    private List<GameObject> allItemIcons;
    public List<GameObject> AllItemIcons
    {
        get { return allItemIcons; }
    }

    /// <summary>
    /// アイテムを持っているかの判定
    /// 持っていないなら0,持っているなら1にする
    /// </summary>
    private int[] isGetItems;
    public int[] IsGetBlocks
    {
        get { return isGetItems; }
    }



    void Start()
    {
        Debug.Log((int)ItemField.BLOCK);
        GetData();
        SetItemGet(ItemType.Floor, true);
        SetItemGet(ItemType.Goal, false);
        SetItemGet(ItemType.Wall, true);
        SetItemGet(ItemType.LightCube_Blue, true);
        SetItemGet(ItemType.LightCube_Orange, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// アイテムの購入の設定
    /// 指定したIDのアイテムを持っているかを設定する
    /// 指定したTypeの中のIDのものを設定する
    /// </summary>
    public void SetItemGet(ItemType itemType, bool isGet)
    {

        if (isGet)
            isGetItems[(int)itemType] = 1;
        else
            IsGetBlocks[(int)itemType] = 0;

        SaveData();
    }


    /// <summary>
    /// データの保存
    /// </summary>
    private void SaveData()
    {
        string[] isGetItems_ = new string[allItemIcons.Count];
        for (int i = 0; i < isGetItems.Length; i++)
        {
            isGetItems_[i] = isGetItems[i].ToString();
        }
        string isGetItems_string = string.Join(",", isGetItems_);
        PlayerPrefs.SetString(saveKey, isGetItems_string);

    }

    /// <summary>
    /// データの取得
    /// </summary>
    private void GetData()
    {
        //データを文字列で取得
        string isGetBlocks_string = PlayerPrefs.GetString(saveKey);
        //文字列が保存されていたら
        if (isGetBlocks_string.Length > 0)
        {
            Debug.Log(isGetBlocks_string);
            //,で区切って配列に分けて保存
            string[] isGetBlocks_ = isGetBlocks_string.Split(","[0]);
            isGetItems = new int[allItemIcons.Count];
            for (int i = 0; i < isGetBlocks_.Length; i++)
            {
                //int型に変換して配列に入れる
                isGetItems[i] = int.Parse(isGetBlocks_[i]);
            }
        }
        else
        {
            isGetItems = new int[allItemIcons.Count];
        }
    }

}
