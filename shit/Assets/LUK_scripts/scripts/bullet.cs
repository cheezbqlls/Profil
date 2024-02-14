using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 20f;
    public GameObject self;

    float dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dir * bulletSpeed, 0f);
    }

    public void SetDir(float xDir)
    {
        dir = xDir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(self);
    }
}
