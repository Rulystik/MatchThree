using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model
{
    public int WidthField { get; private set; }
    public int HeightField { get; private set; }
    public GameObject[,] bgField;
    private FieldData[,] fieldDatas;

    public Model()
    {
        Init();
    }
    public void Init()
    {
        WidthField = 9;
        HeightField = 9;
        fieldDatas = new FieldData[WidthField, HeightField];
        // FieldInit();
    }

    // void FieldInit()
    // {
    //     for (int i = 0; i < WidthField; i++)
    //     {
    //         for (int j = 0; j < HeightField; j++)
    //         {
    //             fieldDatas[i, j] = new FieldData();
    //         }
    //     }
    // }

    public FieldData GetField(int x, int y)
    {
        return fieldDatas[x, y];
    }


    public void SetFieldPos(int x, int y)
    {
        SetFieldPos(x, y, new Vector2());
    }

    public void SetFieldPos(int x, int y, Vector2? vec)
    {
        fieldDatas[x, y].PosX = (int)vec?.x;
        fieldDatas[x, y].PosY = (int)vec?.y;
    }


    public void SetFieldData(int x, int y, FieldData data)
    {
        fieldDatas[x, y] = data;
    }
}
    
