using System;
using UnityEngine;
using UnityEngine.UI;

public class Digit : MonoBehaviour
{
    [SerializeField] private Text _hourTime;
    [SerializeField] private Text _minuteTime;
    [SerializeField] private Analog _analog;

    private void Update()
    {
        _hourTime.text = _analog.Hours.ToString("D2");
        _minuteTime.text = _analog.Minutes.ToString("D2");
    }
}
