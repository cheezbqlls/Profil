using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    Rigidbody2D rb;
    Vector2 moveInput;
    Collider2D coll;
    Animator ani;
    bool jump = false;
    float bullets;
    float timer;
    bool timerOn = false;
    public Image healthBar;
    public float healthAmount = 100f;
    [SerializeField] private GameObject sheild;
    public GameObject collDeath;
    bool isHurt;
    float timerSheild;
    float timerHurt;
    public GameObject self;
    bool god;
    float timer2;
    bool sheildActive = false;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (sheildActive == true)
        {
            timer += Time.deltaTime;
            if (timer >= 25)
            {
                sheild.SetActive(false);
                sheildActive = false;
            }
        }
        if (isHurt == false)
        {
            Jump();
            Run();
        }
        if(isHurt == true)
        {
            timerHurt += Time.deltaTime * 100;
            if(timerHurt > 0.5)
            {
                isHurt = false;
                timerHurt = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            god = true;
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        jump = true;      
    }

    void Jump()
    {
        if (coll.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            if (jump)
            {
                transform.position += new Vector3(0, 0.4f, 0);
                rb.velocity += new Vector2(0f, jumpSpeed);
                ani.SetBool("isJump", true);
            }
            else if (rb.velocity.y != jumpSpeed)
            {    
                ani.SetBool("isJump", false);
            }
        }
        jump = false;
    }

    void OnFire()
    {
        bullets += 1;
        if(bullets <= 10)
        {
            ani.SetTrigger("LongRange");
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            newBullet.GetComponent<bullet>().SetDir(Mathf.Sign(-transform.localScale.x));
        }
        if(bullets > 20)
        {
            Debug.Log("No left");
            timerOn = true;
        }
        if(timerOn == true)
        {
            timer += Time.deltaTime * 100;
            Debug.Log(timer);
        }
        if(timer > 10)
        {
            Debug.Log("done");
            bullets = 0;
            timer = 0;
            timerOn = false;
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (moveInput.x != 0)
        {
            transform.localScale = new Vector2(-moveInput.x, transform.localScale.y);
            ani.SetBool("isRunning", true);
        }
        else
        {
            ani.SetBool("isRunning", false);
        }
    }
    public void TakeDamage(float Damage)
    {
        if(god == true )
        {
            Damage = 0;
        }
        else if(sheildActive == true)
        {
            Damage = 0;
        }
        else
        {
            healthAmount -= Damage;
            healthBar.fillAmount = healthAmount / 100f;
            ani.SetTrigger("isDamaged");
            ani.SetBool("isRunning", false);
            isHurt = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(7);

        }
        if (other.gameObject.CompareTag("Hands"))
        {
            TakeDamage(13);

        }
        if (other.gameObject.CompareTag("deathZone"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("healingPotion"))
        {
            healthAmount += 25;
            Debug.Log("25 health+");
        }
        if (other.CompareTag("shieldPotion"))
        {
            sheild.SetActive(true);
        }

    }
    void Die()
    {
        ani.SetBool("isRunning", false);
        ani.SetTrigger("Death");
    }
}
