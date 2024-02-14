using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    [SerializeField] private GameObject sheild;
    public GameObject coll;
    void Start()
    {
        
    }

    void Update()
    {


    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
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
        Destroy(gameObject);
    }
}
