using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        Run();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
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
                transform.position += new Vector3(0, 0, 0);
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
        GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
        newBullet.GetComponent<bullet>().SetDir(Mathf.Sign(-transform.localScale.x));
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
}
