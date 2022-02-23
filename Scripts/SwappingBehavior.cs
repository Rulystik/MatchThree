﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public enum SwapDirectionEnum
{
    Right,
    Left,
    Up,
    Down
}
public class SwappingBehavior
{
    private FieldData[,] _fieldData;
    private bool canMove = true;
    private Sequence _sequence;
    private Vector3 _vectorToMove;
    private Vector3 _targetPos;

    private List<FieldData> SameObjects;

    public SwappingBehavior(FieldData[,] fieldData)
    {
        _fieldData = fieldData;
        SameObjects = new List<FieldData>();
    }
    public void SwapPieces(Vector3 startPos , SwapDirectionEnum direction)
    {
        _vectorToMove = VectorToMove(direction);
        _targetPos = startPos + _vectorToMove;
    
        if (canMove && IsInArrayField(_targetPos))
        {
            
            SwapFieldDatas(startPos, _targetPos);

            // DOVirtual.DelayedCall(0.35f, () => canMove = true);

            DOVirtual.DelayedCall(.35f, () => SwapFieldDatas(_targetPos, startPos, .35f));
        }
    }
    private bool IsInArrayField(Vector3 pos)
    {
        if (pos.x < 0 || pos.x > 8 || pos.y < 0 || pos.y > 8)
        {
            return false;
        }

        return true;
    }
    
    Vector3 VectorToMove(SwapDirectionEnum direction)
    {
        if (direction == SwapDirectionEnum.Right)
        {
            return new Vector3(1,0, -0.3f);
        }
        if (direction == SwapDirectionEnum.Left)
        {
            return new Vector3(-1,0, -0.3f);
        }
        if (direction == SwapDirectionEnum.Up)
        {
            return new Vector3(0,1, -0.3f);
        }
        return new Vector3(0,-1, -0.3f);
    }
    

    private void SwapFieldDatas(Vector3 start, Vector3 target, float delay = 0)
    {
        canMove = false;
        int startPosX = (int)start.x;
        int startPosY = (int)start.y;

        int targetX = (int) target.x;
        int targetPosY = (int)target.y;

        var temp = _fieldData[startPosX, startPosY];

        _fieldData[startPosX, startPosY] = _fieldData[targetX, targetPosY];
        _fieldData[startPosX, startPosY].PosX = startPosX;
        _fieldData[startPosX, startPosY].PosY = startPosY;

        _fieldData[targetX, targetPosY] = temp;
        _fieldData[targetX, targetPosY].PosX = targetX;
        _fieldData[targetX, targetPosY].PosY = targetPosY;
        
        MoveObject(_fieldData[startPosX, startPosY], delay);
        MoveObject(_fieldData[targetX, targetPosY], delay);
    }
    private void MoveObject(FieldData fieldData, float delay = 0)
    {
        var pos = new Vector3(fieldData.PosX, fieldData.PosY, -0.3f);
        if (fieldData.VisibleObject.transform.position != pos)
        {
            var ff = fieldData.VisibleObject.transform.position;
            if (delay >.1f)
            {
                fieldData.VisibleObject.transform.DOMove(pos, 0.3f).SetDelay(delay).OnComplete(() => canMove = true);
            }
            fieldData.VisibleObject.transform.DOMove(pos, 0.3f).SetDelay(delay);
        }
    }


    private void SeachMatchesAt(int x, int y)
    {
        
    }
}
