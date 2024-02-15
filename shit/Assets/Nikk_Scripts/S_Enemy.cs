using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    public Transform[] patrolPoints;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public float inRange;
    public bool isShooting;
    float timer;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;
    Animator ani;
    float health = 40;
    bool dead = false;
    float timer2;


    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("Walk", true);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, playerTransform.position) < inRange)
        {
            timer += Time.deltaTime;
            ani.SetBool("Walk", false);
            ani.SetTrigger("Shooting");
            isShooting = true;
            if (timer >1.5)
            {
                timer = 0;
                GameObject newBullet = Instantiate(bullet, bulletPos.position, transform.rotation);
                newBullet.GetComponent<Bullet>().SetDir(Mathf.Sign(transform.localScale.x));
            }

            
        }
        else
        {
            isShooting = false;
            ani.SetBool("Walk", true);
        }
        if (isShooting == false && dead == false)
        {
            if (isChasing)
            {
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
                if (patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
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
            
        }

        if(health <= 0)
        {
            dead = true;
            ani.ResetTrigger("Shooting");
            ani.SetBool("Walk", false);
            ani.SetTrigger("Death");
            
        }





    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("bullet"))
        {
            Damage(6);
            ani.ResetTrigger("Shooting");
            ani.SetBool("Walk", false);
            ani.SetTrigger("Damage");


        }
        if (other.gameObject.CompareTag("sword"))
        {
            Damage(10);
            ani.SetBool("Walk", false);
            ani.SetTrigger("Damage");
           Debug.Log("Hit");
        }
    }

    void Damage(float damage)
    {
        health -= damage;
    }

}
