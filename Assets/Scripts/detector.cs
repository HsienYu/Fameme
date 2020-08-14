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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.name == "L_Brain_01_A"){
                    Debug.Log("Triger LB01A");
                    LB1A.SetActive(false);
                    LB1B.SetActive(true);

                }

                if (hit.collider.name == "L_Brain_02_A")
                {
                    Debug.Log("Triger LB02A");
                    LB2A.SetActive(false);
                    LB2B.SetActive(true);

                }

                if (hit.collider.name == "L_Brain_03_A")
                {
                    Debug.Log("Triger LB03A");
                    LB3A.SetActive(false);
                    LB3B.SetActive(true);

                }

                if (hit.collider.name == "L_Brain_04_A")
                {
                    Debug.Log("Triger LB04A");
                    LB4A.SetActive(false);
                    LB4B.SetActive(true);

                }
                ///***///
                if (hit.collider.name == "R_Brain_01_A")
                {
                    Debug.Log("Triger RB01A");
                    RB1A.SetActive(false);
                    RB1B.SetActive(true);

                }

                if (hit.collider.name == "R_Brain_02_A")
                {
                    Debug.Log("Triger RB02A");
                    RB2A.SetActive(false);
                    RB2B.SetActive(true);

                }

                if (hit.collider.name == "R_Brain_03_A")
                {
                    Debug.Log("Triger RB03A");
                    RB3A.SetActive(false);
                    RB3B.SetActive(true);

                }

                if (hit.collider.name == "R_Brain_04_A")
                {
                    Debug.Log("Triger RB04A");
                    RB4A.SetActive(false);
                    RB4B.SetActive(true);

                }
            }
        }
    }
}
