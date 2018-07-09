using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Squares
{

    /// <summary>
    /// 行
    /// </summary>
    public int LINE;

    /// <summary>
    /// 列
    /// </summary>
    public int ROW;


    public Squares(int line, int row)
    {
        LINE = line;
        ROW = row;
    }

    public static bool operator ==(Squares squares1, Squares squares2)
    {
        if (squares1.LINE == squares2.LINE && squares1.ROW == squares2.ROW)
        {
            return true;
        }

        return false;
    }

    public static bool operator !=(Squares squares1, Squares squares2)
    {
        return !(squares1 == squares2);
    }

}
