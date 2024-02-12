using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed =3f;
    [SerializeField] GameObject spelare;
    [SerializeField] GameObject self;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spelare.transform.position.x <( self.transform.position.x + 4) && spelare.transform.position.x > self.transform.position.x)
        {
            rb.velocity = new Vector2(0, 0);
        }
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       

        moveSpeed = -moveSpeed;
        FLipSprite();

    }
    void FLipSprite()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

}
