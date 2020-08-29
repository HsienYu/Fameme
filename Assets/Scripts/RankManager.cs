using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        var duration = 1.2f;

        var targetWidth = LayoutRectTransform.rect.width;

        Debug.LogFormat("{0} {1} {2} {3} | {4}", red, white, yellow, pink, targetWidth);

        RedText.text = "0";
        WhiteText.text = "0";
        YellowText.text = "0";
        PinkText.text = "0";
        RedBar.rectTransform.sizeDelta = new Vector2(0, RedBar.rectTransform.sizeDelta.y);
        WhiteBar.rectTransform.sizeDelta = new Vector2(0, WhiteBar.rectTransform.sizeDelta.y);
        YellowBar.rectTransform.sizeDelta = new Vector2(0, YellowBar.rectTransform.sizeDelta.y);
        PinkBar.rectTransform.sizeDelta = new Vector2(0, PinkBar.rectTransform.sizeDelta.y);

        RedText.DOText(((int)red).ToString(), duration, false);
        WhiteText.DOText(((int)white).ToString(), duration, false);
        YellowText.DOText(((int)yellow).ToString(), duration, false);
        PinkText.DOText(((int)pink).ToString(), duration, false);

        RedBar.rectTransform.DOSizeDelta(new Vector2(red / 100f * targetWidth, RedBar.rectTransform.sizeDelta.y), duration);
        WhiteBar.rectTransform.DOSizeDelta(new Vector2(white / 100f * targetWidth, WhiteBar.rectTransform.sizeDelta.y), duration);
        YellowBar.rectTransform.DOSizeDelta(new Vector2(yellow / 100f * targetWidth, YellowBar.rectTransform.sizeDelta.y), duration);
        PinkBar.rectTransform.DOSizeDelta(new Vector2(pink / 100f * targetWidth, PinkBar.rectTransform.sizeDelta.y), duration);
    }

    public void OnContinueClick()
    {
        if (OnContinue != null)
        {
            OnContinue.Invoke();
        }
    }
}
