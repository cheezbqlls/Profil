using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Watersort : MonoBehaviour
{
    Vector2 lastPos;
    bool ya;
    [SerializeField] private GameObject self;
    bool rightArea;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >2 && transform.position.y < 2.3 && rightArea == false)
        {
            transform.position = new Vector3(2, transform.position.y, 0);

        }
        if(transform.position.x > 2)
        {
            rightArea = true;
            transform.position = new Vector3(3, transform.position.y, 0);

        }
        if (transform.position.y > 2.35 && rightArea == true && transform.position.x < 3)
        {
            rightArea = false;
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
