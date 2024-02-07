using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Watersort : MonoBehaviour
{
    Vector2 lastPos;
    bool ya;
    [SerializeField] private GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >4 && transform.position.y < 2.5)
        {
            transform.position = new Vector3(4, transform.position.y, 0);

        }
        if(transform.position.x > 5)
        {
            transform.position = new Vector3(5, transform.position.y, 0);
        }

    }

    private void OnMouseDrag()
    {



        transform.position = GetMousePos();
   
        
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            Debug.Log("hahah");
            ya = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        ya = false;
    }
}
