using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    UP,
    DOWN,
    RIGHT,
    LEFT
}


public class SetRotateButtons : MonoBehaviour
{

    [SerializeField]
    private Direction direction;


    private Button button;


    private RotateCube rotateCube1;

    private RotateCube2 rotateCube2;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        rotateCube1 = FindObjectOfType<RotateCube>();
        rotateCube2 = FindObjectOfType<RotateCube2>();

        if (direction == Direction.UP)
        {
            button.onClick.AddListener(() =>
            {
                rotateCube1.PushDown_Up();
                rotateCube2.PushDown_Up();
            });
               
        }

        if (direction == Direction.DOWN)
        {
            button.onClick.AddListener(() =>
            {
                rotateCube1.PushDown_Down();
                rotateCube2.PushDown_Down();
            });

        }

        if (direction == Direction.RIGHT)
        {
            button.onClick.AddListener(() =>
            {
                rotateCube1.PushDown_Right();
                rotateCube2.PushDown_Right();
            });

        }

        if (direction == Direction.LEFT)
        {
            button.onClick.AddListener(() =>
            {
                rotateCube1.PushDown_Left();
                rotateCube2.PushDown_Left();
            });

        }
    }


}
