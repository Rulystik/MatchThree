using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controller
{
    private Model _model;
    private View _view;
    private PrefabService _prefabService;
    private MenuBehavior _menuBehavior;
    private Random rnd = new Random();

    public bool canSwap = true;
    
    private Vector2? _startSwapPos;
    private Vector2? _targetSwapPos;

    public List<SwappingActioCall> swapListCall;

    public Controller(Model model, View view, PrefabService prefabService, MenuBehavior menuBehavior)
    {
        _model = model;
        _view = view;
        _prefabService = prefabService;
        _menuBehavior = menuBehavior;
        
        swapListCall = new List<SwappingActioCall>();

        _view.StartButton += PrepareLevelMenu;
        _view.ExitButton += ExitGame;
        _view.PauseButton += GetMenuOnPause;
        _view.ResumeButton += BackToGame;
        _view.ChooseLevel += StartGame;
    }

    private void StartGame(string str)
    {
        _menuBehavior.BlackScreenOnOff();
        DOVirtual.DelayedCall(0.3f, _menuBehavior.LevelPanelActivity).OnComplete(_menuBehavior.BlackScreenOnOff);
        _menuBehavior.ChangeLevelText(str);
        GetNewPieces();
        SwapInit();

    }

    private void SwapInit()
    {
        foreach (var swap in swapListCall)
        {
            swap.StartPos += StartPosInit;
            swap.TargetPos += TargetPosInit;
            swap.ResetPositions += ResetPos;
        }
    }

    public void BackToGame()
    {
        _menuBehavior.MovingPanel();
        DOVirtual.DelayedCall(0.3f, _menuBehavior.BlackScreenOnOff);

    }

    private void GetMenuOnPause()
    {
        _menuBehavior.BlackScreenOnOff();
        DOVirtual.DelayedCall(0.3f, _menuBehavior.MovingPanel);
    }

    private void ExitGame()
    {
        // Save progress TODO
        Application.Quit();
    }

    private void PrepareLevelMenu()
    {
        _menuBehavior.MovingPanel();
        DOVirtual.DelayedCall(0.3f, _menuBehavior.BlackScreenOnOff);
        _menuBehavior.startButton.SetActive(false);
        _menuBehavior.resumeButton.SetActive(true);
        _menuBehavior.menuText.text = "Pause";
        
        // UI Level manager action (saved progress) TODO
    }

    private void GetNewPieces()
    {
        for (int i = 0; i < _model.WidthField; i++)
        {
            for (int j = 0; j < _model.HeightField; j++)
            {
                FieldData data = _prefabService.CreateNewField();
                data.PosX = i;
                data.PosY = j;
                data.VisibleObject.transform.position = new Vector3(i, j,-0.2f);
                swapListCall.Add(data.VisibleObject.GetComponent<SwappingActioCall>());
                data.BgTile.transform.position = new Vector3(i, j,0);
                data.VisibleObject.name = data.DotColor.ToString() + (data.PosX, data.PosY);
                _model.SetFieldData(i,j, data);
            }
        }
    }

    

    private void TargetPosInit(Vector3 pos)
    {
        
    }

    private void SwapFieldData(FieldData startFieldData, FieldData targetFieldData)
    {
        var temp = startFieldData.VisibleObject;
        startFieldData.VisibleObject = targetFieldData.VisibleObject;
        targetFieldData.VisibleObject = temp;
    }

    private void StartPosInit(Vector3 pos)
    {
        if (canSwap)
        {
            _targetSwapPos = null;
            _startSwapPos = pos;
            Debug.Log("Start Pos  -   "+pos);
        }
    }

    private void ResetPos()
    {
        _startSwapPos = null;
        canSwap = true;
    }
}
