using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed =3f;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            if(playerTransform.position.y > (transform.position.y + 4))
            {
                isChasing = false;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        
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
