using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable All

public enum DotType
{
    Normal,
    Bomb,
    Column,
    Row,
    Rainbow
}
public enum DotColor
{
    Blue,
    Green,
    LightGreen,
    Orange,
    Pink,
    Yellow,
    Rainbow
}
public enum TileType
{
    Normal,
    Ice,
    Locks,
    Concrete,
    NonePlayable
}
public enum ShiftDirection
{
    Left,
    right,
    Up,
    Down
}

public class View : MonoBehaviour
{
    public Action<ShiftDirection> InputPlayer;
    public Action StartButton;
    public Action ExitButton;
    public Action PauseButton;
    public Action ResumeButton;
    public Action<string> ChooseLevel;

    [SerializeField] private CanvasGroup levelButtons;
    private List<ButtonLevel> _levelButtonsList = new List<ButtonLevel>();
    public List<Collider> allPiesecCollider;
    
    public bool canSwipe = true;

    [SerializeField] 
    private Camera _camera;

    private void Start()
     {
         CameraInit();
         GetButtonLevels();
     }

    private void Update()
    {
    }

    void CameraInit()
     {
         _camera.transform.position = new Vector3(4, 5.5f, -20);
         _camera.orthographicSize = (9 * _camera.pixelHeight / _camera.pixelWidth * 0.5f)+0.5f; 
     }
     public void StartButtonDown()
     {
         StartButton?.Invoke();
     }

     public void ExitButtonDown()
     {
         ExitButton?.Invoke();
     }

     public void PauseButtonDown()
     {
         PauseButton?.Invoke();
     }

     public void ResumeButtonDown()
     {
         ResumeButton?.Invoke();
     }

     private void GetButtonLevels()
     {
         foreach (var child in levelButtons.GetComponentsInChildren<ButtonLevel>())
         {
             _levelButtonsList.Add(child);
             child.LelevButtonPressed += levelButton;
         }
     }

     private void levelButton(string str)
     {
         ChooseLevel?.Invoke(str);
     }

     

}
