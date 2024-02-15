using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public bool isChasing;
    public float chaseDistance;
    public Transform playerTransform;
    public float moveSpeed;
    public float inRange;
    public bool isShooting;
    bool dead = false;
    float health = 70;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < inRange)
        {
            isShooting = true;
            ani.SetBool("IsWalking", false);

        }
        else
        {
            isShooting = false;
        }
        if(isShooting == false && dead == false)
        {
            if (isChasing)
            {
                ani.SetBool("IsWalking", true);
                if (transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                {
                    isChasing = true;
                }
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Damage(6);
        }
        if (other.gameObject.CompareTag("sword"))
        {
            Damage(10);
        }
    }

    void Damage(float damage)
    {
        health -= damage;
    }

}
