using System;
using UnityEngine;

public class NTPTime 
{
    private DateTime _dateTime;
    public DateTime DateTime => _dateTime;

    public NTPTime()
    {
        SetTime();
    }

    private void SetTime()
    {
        try
        {
            _dateTime = GetNtpTime("ntp6.ntp-servers.net");
        }
        catch
        {
            Debug.Log("Trying another server");
            try
            {
                _dateTime = GetNtpTime("time.google.com");
            }
            catch
            {
                Debug.Log("Using system date");
                _dateTime = DateTime.Now;
            }
        }
    }

    private DateTime GetNtpTime(string server)
    {
        var ntpClient = new NtpClient(server);
        var ntpTime = ntpClient.GetNetworkTime();
        var dateTime = ntpTime.ToLocalTime();

        return dateTime;
    }
}
