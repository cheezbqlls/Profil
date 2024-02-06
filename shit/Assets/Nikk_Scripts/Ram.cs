using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    bool används = false;
    SpriteRenderer spritey;
    // Start is called before the first frame update
    void Start()
    {
        spritey = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (används == true)
        {
            spritey.gameObject.SetActive(true);
            
        }
    }

    public void InPuzzle(bool isTrue)
    {
        används = isTrue;
    }
}
