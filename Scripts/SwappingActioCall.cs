using System;
using UnityEngine;

public class SwappingActioCall : MonoBehaviour
{
    public Action<Vector3> StartPos;
    public Action<Vector3> TargetPos;
    public Action ResetPositions;

    private void OnMouseDown()
    {
        StartPos?.Invoke(gameObject.transform.position);
        // Debug.Log("Down  "+ gameObject.transform.position);
    }

    private void OnMouseUp()
    {
        // ResetPositions?.Invoke();
        // Debug.Log("Reset");
    }

    private void OnMouseEnter()
    {
        TargetPos?.Invoke(gameObject.transform.position);
        // Debug.Log("Enter  "+ gameObject.transform.position);
    }
    
    
}
