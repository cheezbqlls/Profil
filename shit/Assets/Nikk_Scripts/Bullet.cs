using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rB;
    [SerializeField] float bulletSpeed = 20f;
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
}
