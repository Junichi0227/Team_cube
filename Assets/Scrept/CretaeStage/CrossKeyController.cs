using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CrossKeyController : MonoBehaviour
{


    Subject<Squares> subject = new Subject<Squares>();


    /// <summary>
    /// 最大列数
    /// </summary>
    [SerializeField]
    private int maxRow;

    /// <summary>
    /// 最大行数
    /// </summary>
    [SerializeField]
    private int maxLine;

    /// <summary>
    /// 上ボタン
    /// </summary>
    [SerializeField]
    Button upButton;

    /// <summary>
    /// 下ボタン
    /// </summary>
    [SerializeField]
    Button downBUtton;

    /// <summary>
    /// 右ボタン
    /// </summary>
    [SerializeField]
    Button rightButton;

    /// <summary>
    /// 左ボタン
    /// </summary>
    [SerializeField]
    Button leftButton;

    /// <summary>
    /// 現在のマス
    /// </summary>
    Squares currentSquares;

    public IObservable<Squares> CrossControllerEvent
    {
        get { return subject; }
    }

    // Use this for initialization
    void Start()
    {

        upButton.onClick.AddListener(() =>
        {
            currentSquares.LINE = Mathf.Clamp(currentSquares.LINE+1, -maxLine / 2, maxLine / 2);
            subject.OnNext(currentSquares);
        });

        downBUtton.onClick.AddListener(() =>
        {
            currentSquares.LINE = Mathf.Clamp(currentSquares.LINE - 1, -maxLine / 2, maxLine / 2);
            subject.OnNext(currentSquares);
        });

        rightButton.onClick.AddListener(() =>
        {
            currentSquares.ROW = Mathf.Clamp(currentSquares.ROW+1, -maxRow / 2, maxRow / 2);
            subject.OnNext(currentSquares);
        });

        leftButton.onClick.AddListener(() =>
        {
            currentSquares.ROW = Mathf.Clamp(currentSquares.ROW-1, -maxRow / 2, maxRow / 2);
            subject.OnNext(currentSquares);
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
