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

    public RectTransform LayoutRectTransform;

    public Action OnContinue;

    public void SetPill(float red, float white, float yellow, float pink)
    {
        var targetWidth = LayoutRectTransform.rect.width;

        Debug.LogFormat("{0} {1} {2} {3} | {4}", red, white, yellow, pink, targetWidth);

        RedText.text = red.ToString();
        WhiteText.text = white.ToString();
        YellowText.text = yellow.ToString();
        PinkText.text = pink.ToString();

        RedBar.rectTransform.sizeDelta = new Vector2(red / 100f * targetWidth, RedBar.rectTransform.sizeDelta.y);
        WhiteBar.rectTransform.sizeDelta = new Vector2(white / 100f * targetWidth, WhiteBar.rectTransform.sizeDelta.y);
        YellowBar.rectTransform.sizeDelta = new Vector2(yellow / 100f * targetWidth, YellowBar.rectTransform.sizeDelta.y);
        PinkBar.rectTransform.sizeDelta = new Vector2(pink / 100f * targetWidth, PinkBar.rectTransform.sizeDelta.y);
    }

    public void OnContinueClick()
    {
        if (OnContinue != null)
        {
            OnContinue.Invoke();
        }
    }
}
