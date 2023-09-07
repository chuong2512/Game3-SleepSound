using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private int _time;

    private void OnValidate()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _button?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        AudioManager.Instance.SetTimeCount(_time);
    }

    public void SetTime(int i)
    {
        switch (i)
        {
            case 0:
                _time = 60;
                _text.SetText("");
                break;
            case 1:
                _time = 60;
                _text.SetText("");
                break;
            case 2:
                _time = 60;
                _text.SetText("");
                break;
            case 3:
                _time = 60;
                _text.SetText("");
                break;
            case 4:
                _time = 60;
                _text.SetText("");
                break;
            case 5:
                _time = 60;
                _text.SetText("");
                break;
        }
    }
}