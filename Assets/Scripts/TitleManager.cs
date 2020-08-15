using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Image Value;

    public Sprite TouchMyBrain;
    public Sprite TakeYourMst;
    public Sprite Ranking;
    public Sprite TheEnd;

    // Start is called before the first frame update
    void Start()
    {
        ChangeToTouchMyBrain();
    }

    public void ChangeToTouchMyBrain()
    {
        Value.sprite = TouchMyBrain;
    }

    public void ChangeToTakeYourMst()
    {
        Value.sprite = TakeYourMst;
    }

    public void ChangeToRanking()
    {
        Value.sprite = Ranking;
    }

    public void ChangeToTheEnd()
    {
        Value.sprite = TheEnd;
    }
}
