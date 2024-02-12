using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Watersort : MonoBehaviour
{
    bool ya;
    [SerializeField] private GameObject self;
    bool rightArea;
    Rigidbody2D rb;
    Vector3 lastPos;
    [SerializeField] int type;
    [SerializeField] float xCord;
    [SerializeField] float yCord;
    [SerializeField] float xCord2;

    [Header("Done")]
    [SerializeField] private GameObject exit;


    int antalRätt; 

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        lastPos = rb.position;
        transform.position = new Vector3(xCord2, -0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Tub 1
        if(transform.position.x > (xCord -1) && transform.position.y < yCord && rightArea == false)
        {
            transform.position = new Vector3((xCord-1), transform.position.y, 0);

        }
        if(transform.position.x > (xCord-1))
        {
            rightArea = true;
            transform.position = new Vector3(xCord, transform.position.y, 0);

        }
        if (transform.position.y > (yCord+0.5) && rightArea == true && transform.position.x < xCord)
        {
            rightArea = false;
        }

        //Tub 2
        if (transform.position.x > (xCord2 - 1) && transform.position.y < yCord && rightArea == false)
        {
            transform.position = new Vector3((xCord2 - 1), transform.position.y, 0);

        }
        if (transform.position.x > (xCord2 - 1) && transform.position.x < (xCord2 + 1))
        {
            rightArea = true;
            transform.position = new Vector3(xCord2, transform.position.y, 0);

        }
        if (transform.position.y > (yCord + 0.5) && rightArea == true && transform.position.x < xCord2)
        {
            rightArea = false;
        }
       
        if(antalRätt == 4)
        {
            Done();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("1") && type == 1)
        {
            Debug.Log("Rätt!");
            antalRätt += 1;
        }
        else if(other.gameObject.CompareTag("1") && type == 2)
        {
            rb.position = lastPos;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        ya = false;
    }

    private void Done()
    {
        exit.SetActive(true);
    }
}
