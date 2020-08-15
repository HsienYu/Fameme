using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnAnswerClick(string answer)
    {
        Debug.Log(answer);

        gameObject.SetActive(false);
    }
}
