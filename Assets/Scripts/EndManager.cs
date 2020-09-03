using System;
using CalendarUtility;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine.Networking;

public class EndManager : MonoBehaviour
{
    public LogoManager Logo;
    public detector Detector;

    public GameObject content;
    public GameObject yesbtn;
    public GameObject nobtn;



    public GameObject lastText;
    public GameObject homebtn;
    public GameObject Submit;
    public GameObject InputObject;


    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    public static bool validateEmail(string email){
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }

    private string Email;


    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSf6lz4hove9X3CeIB4mo7y-y8apzJUWBiEgdtszvIqVbU4AmQ/formResponse";


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (string.IsNullOrEmpty(InputObject.GetComponent<InputField>().text))
        {
            Submit.SetActive(false);
        }
        else
        {
            Submit.SetActive(true);
        }
    }

    public void OnYesClick()
    {
        //var calendarEvent = new CalendarEvent();
        //calendarEvent.Title = "TEST";
        //calendarEvent.StartTime = DateTime.Now;
        //calendarEvent.IsAllDayEvent = true;
        //calendarEvent.Description = "TEST Description";

        //var url = string.Empty;
        //switch (Application.platform)
        //{
        //    case RuntimePlatform.tvOS:
        //    case RuntimePlatform.IPhonePlayer:
        //    case RuntimePlatform.OSXEditor:
        //    case RuntimePlatform.OSXPlayer:
        //        break;

        //    case RuntimePlatform.Android:
        //    case RuntimePlatform.WindowsPlayer:
        //    case RuntimePlatform.WindowsEditor:
        //    default:
        //        url = CalendarHelper.GenerateGoogleCalendarUrl(calendarEvent);
        //        Application.OpenURL(url);
        //        break;
        //}
        ResetEnd_B();
    }

    public void ResetGame()
    {
        GameManager.Instance.Reset();
        Detector.Reset();
        Logo.Reset();
    }

    public void OnNoClick()
    {
        ResetEnd_B();
    }

    public void OnHomeClick()
    {
        gameObject.SetActive(false);
        ResetGame();
    }


    public void ResetEnd_A(){
        content.SetActive(true);
        yesbtn.SetActive(true);
        nobtn.SetActive(true);
        lastText.SetActive(false);
        homebtn.SetActive(false);
        Submit.SetActive(false);
        InputObject.SetActive(false);

    }

    public void ResetEnd_B()
    {
        content.SetActive(false);
        yesbtn.SetActive(false);
        nobtn.SetActive(false);
        lastText.SetActive(true);
        homebtn.SetActive(true);
        Submit.SetActive(false);
        InputObject.SetActive(true);
    }




    public void OnSubscribeClick(){
        if(validateEmail(InputObject.GetComponent<InputField>().text)){
            Debug.Log("yes email is good");
            Send();
        }
        else{
            Debug.Log("no email is not good");
        }

    }

    IEnumerator Post(string email){
        WWWForm form = new WWWForm();
        form.AddField("entry.639346835", email);
        
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);

        //byte[] rawData = form.data;
        //string url = BASE_URL;

        //// Post a request to an URL with our custom headers
        //WWW www = new WWW(url, rawData);
        //yield return www;

        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
            gameObject.SetActive(false);
            ResetGame();
        }
        else
        {
            Debug.Log("Form upload complete!");
            gameObject.SetActive(false);
            ResetGame();
        }
    }

    public void Send(){
        Email = InputObject.GetComponent<InputField>().text;

        StartCoroutine(Post(Email));
    }

}
