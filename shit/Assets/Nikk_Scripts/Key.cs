using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Self;
    public GameObject rat;
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = rat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            exit.SetActive(true);
            Destroy(Self);
        }
    }
}
