using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class detector : MonoBehaviour
{
    public Camera cam;
    public GameObject LB1A;
    public GameObject LB1B;
    public GameObject LB2A;
    public GameObject LB2B;
    public GameObject LB3A;
    public GameObject LB3B;
    public GameObject LB4A;
    public GameObject LB4B;
    public GameObject RB1A;
    public GameObject RB1B;
    public GameObject RB2A;
    public GameObject RB2B;
    public GameObject RB3A;
    public GameObject RB3B;
    public GameObject RB4A;
    public GameObject RB4B;

    public AudioClip[] clips;

    public AudioSource fxSound;

    private QaManager _qaManager;



    // Start is called before the first frame update
    void Start()
    {
        var qaManager = GameObject.Find("QuestionManager");
        _qaManager = qaManager.GetComponent<QaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (_qaManager.InQuestion)
                {
                    Debug.Log("InQuestion");
                    return;
                }

                var hitName = hit.collider.name;
                var hitted = false;

                #region left

                if (hitName == "L_Brain_01_A")
                {
                    Debug.Log("Triger LB01A");
                    LB1A.SetActive(false);
                    LB1B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "L_Brain_02_A")
                {
                    Debug.Log("Triger LB02A");
                    LB2A.SetActive(false);
                    LB2B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "L_Brain_03_A")
                {
                    Debug.Log("Triger LB03A");
                    LB3A.SetActive(false);
                    LB3B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "L_Brain_04_A")
                {
                    Debug.Log("Triger LB04A");
                    LB4A.SetActive(false);
                    LB4B.SetActive(true);
                    hitted = true;
                }

                #endregion

                #region right

                if (hitName == "R_Brain_01_A")
                {
                    Debug.Log("Triger RB01A");
                    RB1A.SetActive(false);
                    RB1B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "R_Brain_02_A")
                {
                    Debug.Log("Triger RB02A");
                    RB2A.SetActive(false);
                    RB2B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "R_Brain_03_A")
                {
                    Debug.Log("Triger RB03A");
                    RB3A.SetActive(false);
                    RB3B.SetActive(true);
                    hitted = true;
                }

                if (hitName == "R_Brain_04_A")
                {
                    Debug.Log("Triger RB04A");
                    RB4A.SetActive(false);
                    RB4B.SetActive(true);
                    hitted = true;
                }

                #endregion

                if (hitted)
                {
                    OnHitBrain();
                }
            }
        }
    }

    public void Reset()
    {
        LB1A.SetActive(true);
        LB1B.SetActive(false);
        LB2A.SetActive(true);
        LB2B.SetActive(false);
        LB3A.SetActive(true);
        LB3B.SetActive(false);
        LB4A.SetActive(true);
        LB4B.SetActive(false);
        RB1A.SetActive(true);
        RB1B.SetActive(false);
        RB2A.SetActive(true);
        RB2B.SetActive(false);
        RB3A.SetActive(true);
        RB3B.SetActive(false);
        RB4A.SetActive(true);
        RB4B.SetActive(false);
    }

    public void OnHitBrain()
    {
        Debug.Log("OnHitBrain");
        PlayClip(RandomClip);
        _qaManager.NextQuestion();
    }


    private AudioClip RandomClip
    {
        get
        {
            return clips[(int)(Random.value * clips.Length)];
        }
    }

    void StopPlaying()
    {
        fxSound.Stop();
    }

    void PlayClip(AudioClip clip)
    {
        fxSound.clip = clip;
        fxSound.Play();
    }

}
