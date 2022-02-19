using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    private Button _button;
    private string _levelNumb;

    public Action<string> LelevButtonPressed;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _levelNumb = gameObject.GetComponentInChildren<Text>().text;
        _button.onClick.AddListener(ButtonPressed);
    }

    private void ButtonPressed()
    {
        LelevButtonPressed?.Invoke(_levelNumb);
    }
}
