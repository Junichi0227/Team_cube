using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove{

    //移動開始位置
    private Vector3 startPosition;

    //移動終了位置
    private Vector3 endPosition;

    //移動にかかる時間
    private float time = 0;

    //移動開始時間
    float startTime = 0;

    //移動経過時間
    float elapsedTime = 0;

    //終了判定
    bool isEnd = false;
    public bool IsEnd
    {
        get { return isEnd; }
        set { isEnd = value; }
    }


    //移動中かどうか
    bool isMove = false;
    public bool IsMove
    {
        get { return isMove; }
        set { isMove = value; }
    }

    public LerpMove()
    {
       
    }

 

    public void Update(GameObject gameObject)
    {
        if (!isMove) return;
        var dift = Time.timeSinceLevelLoad - startTime;
        if (dift > time)
        {
            isEnd = true;
            isMove = false;
        }

        var rate = dift / time;

        //UIだったら
        if(gameObject.GetComponent<RectTransform>())
        {
             gameObject.GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPosition, endPosition, rate);
        }
        //そうじゃなかったら
        else
        {
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, rate);
        }
    }

    public void StartMove(Vector3 startPos,Vector3 endPos, float time)
    {
        startTime = Time.timeSinceLevelLoad;
        startPosition = startPos;
        endPosition = endPos;
        this.time = time;
        isEnd = false;
        isMove = true;
    }
}
