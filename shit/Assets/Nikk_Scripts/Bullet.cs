using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rB;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] GameObject self;

    // Start is called before the first frame update
    float dir;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = new Vector2(dir * bulletSpeed, 0f);
    }
    public void SetDir( float xdir)
    {
        dir = xdir;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(self);
        }
        
    }
}
