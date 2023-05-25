using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivisionPanel : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _panel.SetActive(!_panel.activeSelf);
    }
}
