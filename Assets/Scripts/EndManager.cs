using System;
using CalendarUtility;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public LogoManager Logo;
    public detector Detector;

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

    public void ResetGame()
    {
        GameManager.Instance.Reset();
        Detector.Reset();
        Logo.Reset();
    }

    public void OnNoClick()
    {

    }

    public void OnHomeClick()
    {
        gameObject.SetActive(false);
        ResetGame();
    }
}
