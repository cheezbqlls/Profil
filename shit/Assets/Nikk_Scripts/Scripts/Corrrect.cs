using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrrect : MonoBehaviour
{
    [Header("Vials")]
    [SerializeField] private GameObject vial;
    [SerializeField] private float type;
    [SerializeField] private GameObject EXIT;

    [Header("position, + 0.45x +0.4y")]
    [SerializeField] private float xLed;
    [SerializeField] private float yLed;
    public GameObject camera;
    
    float corect;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(camera.transform.position.x + xLed, camera.transform.position.y + yLed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(corect == 8)
        {
            EXIT.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("red") && type == 1)
        {
            corect += 1;
            Debug.Log(corect);
        }
        if(other.gameObject.CompareTag("White")&& type == 2)
        {
            corect += 1;
        }
    }

}
