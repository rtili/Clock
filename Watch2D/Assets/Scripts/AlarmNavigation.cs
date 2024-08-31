using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmNavigation : MonoBehaviour
{
    [SerializeField] private GameObject[] _objToActive;
    [SerializeField] private GameObject _alarmButton;
    public Action AlarmSet;

    public void OpenAlarmMenu()
    {
        _alarmButton.SetActive(false);
        foreach (GameObject obj in _objToActive)
        {
            obj.SetActive(true);
        }
    }

    public void BackToClock()
    {
        _alarmButton.SetActive(true);
        foreach (GameObject obj in _objToActive)
        {
            obj.SetActive(false);
        }
    }

    public void SetAlarm()
    {
        AlarmSet?.Invoke();
        _alarmButton.SetActive(true);
        foreach (GameObject obj in _objToActive)
        {
            obj.SetActive(false);
        }
    }
}
