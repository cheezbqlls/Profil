using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleStart : MonoBehaviour
{
    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject self;
    bool yes = false;
    BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
       coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(yes == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startObject.gameObject.SetActive(true);
                Debug.Log("snälla");
                self.gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("inside");
        if (other.CompareTag("Player"))
        {
            Debug.Log("correct tag");
            yes = true;
        }
        
    }




}
