using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed =3f;
    public Transform[] patrolPoints;
    public int patrolDestination;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 0;
            }
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

    void Shoot()
    {

    }
}
