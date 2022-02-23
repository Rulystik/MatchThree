using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldData
{
    public int PosX { get; set;}
    public int PosY { get; set;}
    public DotType DotType { get; set;}
    public DotColor DotColor { get; set;}
    public TileType TileType { get; set;}
    public GameObject VisibleObject { get; set;}
    public GameObject BgTile { get; set; }
    private IDestroyable _destoy;


}
