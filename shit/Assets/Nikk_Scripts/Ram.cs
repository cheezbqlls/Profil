using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

       
    }


}
