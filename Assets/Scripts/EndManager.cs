using System;
using System.Collections;
using System.Collections.Generic;
using CalendarUtility;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnYesClick()
    {
        var calendarEvent = new CalendarEvent();
        calendarEvent.Title = "TEST";
        calendarEvent.StartTime = DateTime.Now;
        calendarEvent.IsAllDayEvent = true;
        calendarEvent.Description = "TEST Description";

        var url = string.Empty;
        switch (Application.platform)
        {
            case RuntimePlatform.tvOS:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                break;

            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
            default:
                url = CalendarHelper.GenerateGoogleCalendarUrl(calendarEvent);
                Application.OpenURL(url);
                break;
        }
    }

    public void OnNoClick()
    {

    }

    public void OnHomeClick()
    {

    }
}
