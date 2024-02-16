using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done : MonoBehaviour
{
    public GameObject watersort;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            watersort.SetActive(false);
        }
    }
}
