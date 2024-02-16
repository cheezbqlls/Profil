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
    float timer;
    float timer2;
    bool stop;
    public GameObject key;
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
                
                if (transform.position.x > playerTransform.position.x)
                {
                    ani.SetBool("IsWalking", false);
                    timer2 = 0;
                    timer += Time.deltaTime;

                    if (timer >= 2)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                        ani.SetBool("IsWalking", true);
                    }
                    
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    ani.SetBool("IsWalking", false);
                    timer = 0;
                    timer2 += Time.deltaTime;
                    if (timer2 >= 0.5)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                        ani.SetBool("IsWalking", true);
                    }
                    
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

        if (health <= 0)
        {
            key.SetActive(true);
            dead = true;
            ani.SetTrigger("Death");
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            Damage(6);
            ani.SetTrigger("Damage");
            ani.SetBool("ISWalking", false);
            Debug.Log(health);
        }
        if (other.gameObject.CompareTag("sword"))
        {
            Damage(10);
            ani.SetTrigger("Damage");
            ani.SetBool("ISWalking", false);
            Debug.Log("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ColiderEnemy"))
        {
            stop = true;
            dead = true;
            ani.SetBool("IsWalking", false);
            moveSpeed = 0;
            if (transform.position.x < playerTransform.position.x)
            {
                dead = false;
            }


        }
        if (other.CompareTag("Player"))
        {
            ani.SetTrigger("Attack");
            ani.SetBool("IsWalking", false);
        }
    }

    void Damage(float damage)
    {
        health -= damage;
    }

}
