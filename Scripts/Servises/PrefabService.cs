using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PrefabService : MonoBehaviour
{
    [SerializeField] private GameObject piecesPrefabs;
    [SerializeField] private GameObject bgTilePrefab;
    [SerializeField] private Sprite blueNormalSprite;
    [SerializeField] private Sprite greenNormalSprite;
    [SerializeField] private Sprite orangeNormalSprite;
    [SerializeField] private Sprite pinkNormalSprite;
    [SerializeField] private Sprite yellowNormalSprite;
    [SerializeField] private Sprite lightGreenNormalSprite;
    [SerializeField] private Sprite rainbowSprite;
            
    [SerializeField] private int newPieceCount;
    private GameObject[,] poolGameObjects;
    private GameObject[,] poolBGTiles;

    private DotColor[] allcolorTypes = new[]
    {
        DotColor.Blue,
        DotColor.Green,
        DotColor.Orange,
        DotColor.Pink,
        DotColor.Yellow,
        DotColor.LightGreen
    };

    private FieldData data;

    private void Start()
    {
        poolGameObjects = new GameObject[9,9];
        poolBGTiles = new GameObject[9,9];
        InitPoolGamePiece();
        InitPoolBGTile();
    }

    void InitPoolGamePiece()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject gameObject = Instantiate(piecesPrefabs, Vector3.zero, quaternion.identity);
                gameObject.SetActive(false);
                poolGameObjects[i, j] = gameObject;
            }
        }
    }
    void InitPoolBGTile()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject gameObject = Instantiate(bgTilePrefab, Vector3.zero, quaternion.identity);
                gameObject.SetActive(false);
                poolBGTiles[i, j] = gameObject;
            }
        }
    }
    

    

    public FieldData CreateNewField()
    {
        FieldData data = new FieldData();
        data.DotColor = allcolorTypes[Random.Range(0, newPieceCount)];
        data.DotType = DotType.Normal;
        data.TileType = TileType.Normal;
        data.VisibleObject = GetFromPoolGamePiece();
        data.VisibleObject.GetComponent<SpriteRenderer>().sprite = GetSprite(data.DotColor);
        data.BgTile = GetFromBGTile();
        return data;
    }

    private Sprite GetSprite(DotColor color)
    {
        if (color == DotColor.Blue)
        {
            return blueNormalSprite;
        }
        if (color == DotColor.Green)
        {
            return greenNormalSprite;
        }
        if (color == DotColor.Orange)
        {
            return orangeNormalSprite;
            
        }
        if (color == DotColor.Pink)
        {
            return pinkNormalSprite;
        }
        if (color == DotColor.Rainbow)
        {
            return rainbowSprite;
        }
        if (color == DotColor.Yellow)
        {
            return yellowNormalSprite;
        }
        if (color == DotColor.LightGreen)
        {
            return lightGreenNormalSprite;
        }

        return null;
    }

    GameObject GetFromPoolGamePiece()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (!poolGameObjects[i,j].activeSelf)
                {
                    poolGameObjects[i, j].SetActive(true);
                    return poolGameObjects[i, j];
                }
            }
        }

        return null;
    }
    GameObject GetFromBGTile()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (!poolBGTiles[i,j].activeSelf)
                {
                    poolBGTiles[i, j].SetActive(true);
                    return poolBGTiles[i, j];
                }
            }
        }

        return null;
    }

}
