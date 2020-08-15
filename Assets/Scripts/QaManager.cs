﻿using UnityEngine;

public class QaManager : MonoBehaviour
{
    public GameObject BgGameObject;
    public GameObject[] Questions;

    public bool InQuestion = false;

    public ProgressRate Progress;
    public ResultVideoManager ResultVideo;

    public GameObject[] DisabledOnResultVideoEnd;

    public TitleManager Title;
    public RaycastClick PillRaycastClick;
    public RankManager Rank;
    public EndManager EndView;

    // Start is called before the first frame update
    void Start()
    {
        ResultVideo.OnVideoEnd = OnResultVideoEnd;
        PillRaycastClick.OnRaycastHit = OnPillClick;
        Rank.OnContinue = OnRankContinue;
    }

    private void OnRankContinue()
    {
        Rank.gameObject.SetActive(false);
        EndView.gameObject.SetActive(true);
    }

    private void OnPillClick()
    {
        Title.ChangeToRanking();

        PillRaycastClick.gameObject.SetActive(false);

        Rank.SetPill(GameManager.Instance.GetPillScore(PillType.Red),
            GameManager.Instance.GetPillScore(PillType.White),
            GameManager.Instance.GetPillScore(PillType.Yellow),
            GameManager.Instance.GetPillScore(PillType.Pink));
        Rank.gameObject.SetActive(true);
    }

    private void OnResultVideoEnd()
    {
        Title.ChangeToTakeYourMst();

        var count = DisabledOnResultVideoEnd.Length;
        for (int i = 0; i < count; i++)
        {
            if (DisabledOnResultVideoEnd[i] == null)
            {
                continue;
            }
            DisabledOnResultVideoEnd[i].SetActive(false);
        }

        PillRaycastClick.gameObject.SetActive(true);
    }

    public bool NextQuestion()
    {
        if (InQuestion)
        {
            return false;
        }

        if (Questions.Length <= GameManager.Instance.CurrentStep)
        {
            Debug.LogWarningFormat("No more question {0} / {1}", GameManager.Instance.CurrentStep, Questions.Length);
            return false;
        }

        if (Questions[GameManager.Instance.CurrentStep] == null)
        {
            return false;
        }

        BgGameObject.SetActive(true);
        Questions[GameManager.Instance.CurrentStep].SetActive(true);

        InQuestion = true;

        return true;
    }

    // Call from Qa's answer click(Setting by Button Component on Editor's Inspector)
    public void OnAnswer()
    {
        if (!InQuestion)
        {
            return;
        }

        InQuestion = false;

        BgGameObject.SetActive(false);
        GameManager.Instance.EatPill();

        GameManager.Instance.DumpInfo();

        Progress.UpdateProgress(GameManager.Instance.CurrentStepPercent);
        DoGameOver();
    }

    private void DoGameOver()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            return;
        }

        Debug.Log("DoGameOver");

        // Appear and play the result video
        ResultVideo.Play();
    }
}
