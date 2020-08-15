using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressRate : MonoBehaviour
{
    public Text ProgressText;

    // Start is called before the first frame update
    void Start()
    {
        ProgressText.text = "0";
    }

    public void UpdateProgress(int value)
    {
        ProgressText.text = value.ToString();
    }
}
