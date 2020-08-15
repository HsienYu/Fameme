using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    public Action OnRaycastHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(_hit.collider.name);
                if (OnRaycastHit != null)
                {
                    OnRaycastHit.Invoke();
                }
            }
        }
    }
}
