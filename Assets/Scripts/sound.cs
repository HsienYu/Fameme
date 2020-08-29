using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    AudioSource fxSound;
    public AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
