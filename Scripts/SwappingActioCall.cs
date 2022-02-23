using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwappingActioCall : MonoBehaviour
{
    private Vector2 _startPos;
    private Vector2 _direction;
    private Touch _touch;
    private bool ableToCheck;
    public string m_Text;
    
    public Action<Vector3, SwapDirectionEnum> SwapAction;

    private void Start()
    {
        ableToCheck = false;
    }

    private void Update()
    {
        if (ableToCheck && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;
                
                case TouchPhase.Moved:
                    _direction = touch.position - _startPos;
                    CheckingDistance();
                    break;

                case TouchPhase.Ended:
                    ableToCheck = false;
                    break;
            }
        }
    }
    private void CheckingDistance()
    {
        if (_direction.x >= 100)
        {
            SwapAction?.Invoke(gameObject.transform.position, SwapDirectionEnum.Right);
            ableToCheck = false;
        }

        if (_direction.x <= -100)
        {
            SwapAction?.Invoke(gameObject.transform.position, SwapDirectionEnum.Left);
            ableToCheck = false;
        }
        if (_direction.y <= -100)
        {
            SwapAction?.Invoke(gameObject.transform.position, SwapDirectionEnum.Down);
            ableToCheck = false;
        }
        if (_direction.y >= 100)
        {
            SwapAction?.Invoke(gameObject.transform.position, SwapDirectionEnum.Up);
            ableToCheck = false;
        }
    }
    private void OnMouseDown()
    {
        ableToCheck = true;
    }

}
