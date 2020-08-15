using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QaManager : MonoBehaviour
{
    public GameObject BgGameObject;
    public GameObject[] Questions;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("QaManager");
    }

    public void NextQuestion()
    {
        Debug.Log("NextQuestion");


        if (Questions.Length <= GameManager.Instance.CurrentStep)
        {
            Debug.LogWarningFormat("No more question {0} / {1}", GameManager.Instance.CurrentStep, Questions.Length);
            return;
        }

        if (Questions[GameManager.Instance.CurrentStep] == null)
        {
            return;
        }

        BgGameObject.SetActive(true);
        Questions[GameManager.Instance.CurrentStep].SetActive(true);
    }

    public void OnAnswer()
    {
        BgGameObject.SetActive(false);
        GameManager.Instance.EatPill();
        GameManager.Instance.DumpInfo();
    }
}
