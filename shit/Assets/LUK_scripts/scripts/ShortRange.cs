using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRange : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1f;
    public string compareTag;
    public GameObject sword;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
        if (Input.GetMouseButtonDown(0))
        {
            sword.SetActive(false);
        }
    }

    void Attack()
    {
        sword.gameObject.SetActive(true);
        // Play attack animation
        animator.SetTrigger("ShortRange");


        // Detect enemies in range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        // Damage enemies
        foreach (Collider c in hitColliders)
        {
            if (c.CompareTag(compareTag))
            {
                c.GetComponent<Health>()?.Damage(10);
            }
        }
    }
 }
