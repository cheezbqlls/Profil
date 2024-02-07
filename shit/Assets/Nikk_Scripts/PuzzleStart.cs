using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleStart : MonoBehaviour
{
    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject self;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            startObject.gameObject.SetActive(true);
            Debug.Log("snälla");
            self.gameObject.SetActive(false);
        }

    }




}
