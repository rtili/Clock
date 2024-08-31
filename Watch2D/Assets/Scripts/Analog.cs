using System;
using System.Collections;
using UnityEngine;

public class Analog : MonoBehaviour, ITimeUpdate
{
    [SerializeField] private float _clockSpeed = 1;
    [SerializeField] private GameObject _pointerSeconds;
    [SerializeField] private GameObject _pointerMinutes;
    [SerializeField] private GameObject _pointerHours;

    private int _minutes, _hours, _seconds;
    public int Minutes => _minutes;
    public int Hours => _hours;

    private float _msecs;
    private NTPTime _ntpTime;
    private DateTime _dateTime;

    private void Start()
    {
        UpdateTime();
        StartCoroutine(UpdateTimeOnHour());
    }

    private void Update()
    {
        _msecs += Time.deltaTime * _clockSpeed;
        if (_msecs >= 1.0f)
        {
            _msecs -= 1.0f;
            _seconds++;
            if (_seconds >= 60)
            {
                _seconds = 0;
                _minutes++;
                if (_minutes >= 60)
                {
                    _minutes = 0;
                    _hours++;
                    if (_hours >= 24)
                        _hours = 0;
                }
            }
        }

        float rotationSeconds = (360.0f / 60.0f) * _seconds;
        float rotationMinutes = (360.0f / 60.0f) * _minutes;
        float rotationHours = ((360.0f / 12.0f) * _hours) + ((360.0f / (60.0f * 12.0f)) * _minutes);

        _pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationSeconds);
        _pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationMinutes);
        _pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationHours);
    }

    private IEnumerator UpdateTimeOnHour()
    {
        yield return new WaitForSeconds(3600);
        UpdateTime();
        StartCoroutine(UpdateTimeOnHour());
    }

    public void UpdateTime()
    {
        _ntpTime = new NTPTime();
        _dateTime = _ntpTime.DateTime;

        _hours = _dateTime.Hour;
        _minutes = _dateTime.Minute;
        _seconds = _dateTime.Second;
    }
}
