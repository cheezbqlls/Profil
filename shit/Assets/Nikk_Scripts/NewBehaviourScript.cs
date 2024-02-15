using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float posX;
    [SerializeField] float posY;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(camera.transform.position.x + posX, camera.transform.position.y + posY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
