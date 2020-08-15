using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ResultVideoManager : MonoBehaviour
{
    public VideoPlayer Video;

    public Action OnVideoEnd;


    // Start is called before the first frame update
    void Start()
    {
        Video.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer source)
    {
        if (OnVideoEnd != null)
        {
            OnVideoEnd.Invoke();
        }
    }

    public void Play()
    {
        Video.Play();
    }
}
