using System;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    public Text RedText;
    public Text WhiteText;
    public Text YellowText;
    public Text PinkText;

    public Image RedBar;
    public Image WhiteBar;
    public Image YellowBar;
    public Image PinkBar;

    public Action OnContinue;

    private float _targetWidth = 0;

    // Start is called before the first frame update
    void Start()
    {
        RedText.text = "0";
        WhiteText.text = "0";
        YellowText.text = "0";
        PinkText.text = "0";

        //RedBar.type = Image.Type.Filled;
        //RedBar.fillMethod = Image.FillMethod.Horizontal;
        //RedBar.fillOrigin = 0;

        //WhiteBar.type = Image.Type.Filled;
        //WhiteBar.fillMethod = Image.FillMethod.Horizontal;
        //WhiteBar.fillOrigin = 0;

        //YellowBar.type = Image.Type.Filled;
        //YellowBar.fillMethod = Image.FillMethod.Horizontal;
        //YellowBar.fillOrigin = 0;

        //PinkBar.type = Image.Type.Filled;
        //PinkBar.fillMethod = Image.FillMethod.Horizontal;
        //PinkBar.fillOrigin = 0;

        var cpm = transform.Find("Layout").GetComponent<RectTransform>();
        _targetWidth = cpm == null ? 800f : cpm.rect.width;
    }

    public void SetPill(float red, float white, float yellow, float pink)
    {
        //Debug.LogFormat("{0} {1} {2} {3}", red, white, yellow, pink);

        RedText.text = red.ToString();
        WhiteText.text = white.ToString();
        YellowText.text = yellow.ToString();
        PinkText.text = pink.ToString();

        RedBar.rectTransform.sizeDelta = new Vector2(red / 100f * _targetWidth, RedBar.rectTransform.sizeDelta.y);
        WhiteBar.rectTransform.sizeDelta = new Vector2(white / 100f * _targetWidth, WhiteBar.rectTransform.sizeDelta.y);
        YellowBar.rectTransform.sizeDelta = new Vector2(yellow / 100f * _targetWidth, YellowBar.rectTransform.sizeDelta.y);
        PinkBar.rectTransform.sizeDelta = new Vector2(pink / 100f * _targetWidth, PinkBar.rectTransform.sizeDelta.y);
    }

    public void OnContinueClick()
    {
        if (OnContinue != null)
        {
            OnContinue.Invoke();
        }
    }
}
