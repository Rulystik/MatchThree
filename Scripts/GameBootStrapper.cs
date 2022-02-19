using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootStrapper : MonoBehaviour
{
    private Controller _controller;
    private Model _model;
    [SerializeField] private View _view;
    [SerializeField] private PrefabService _prefabService;
    [SerializeField] private MenuBehavior _menuBehavior;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _prefabService = FindObjectOfType<PrefabService>();
        _model = new Model();
        _controller = new Controller(_model, _view, _prefabService, _menuBehavior);
    }
}
