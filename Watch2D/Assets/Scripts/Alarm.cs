using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AlarmNavigation _alarmNav;
    [SerializeField] private InputField _hourInput;
    [SerializeField] private InputField _minuteInput;
    [SerializeField] private Analog _analog;
    [SerializeField] private GameObject _alarmPanel;
    private int _hour, _minute;

    private void Start()
    {
        _alarmNav.AlarmSet += SetAlarm;
    }

    private void Update()
    {
        if (_hour == _analog.Hours && _minute == _analog.Minutes)
        {
            StartCoroutine(ActivateAlarm());
        }
    }

    private IEnumerator ActivateAlarm()
    {
        _alarmPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        _alarmPanel.SetActive(false);
    }

    private void SetAlarm()
    {
        _hour = Convert.ToInt32(_hourInput.text);
        _minute = Convert.ToInt32(_minuteInput.text);
    }
}
