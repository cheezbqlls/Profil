using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject sheild;
    bool sheildActive = false;
    float timer;

    private int MAX_HEALTH = 125;

    // Update is called once per frame
    void Update()
    {
        if(sheildActive == true)
        {
            timer += Time.deltaTime;
            if(timer >= 25)
            {
                sheild.SetActive(false);
            }
        }
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)

        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("DEAD");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("healingPotion"))
        {
            health += 25;
            Debug.Log("25 health+");
        }
        if (other.CompareTag("shieldPotion"))
        {
            sheild.SetActive(true);
            sheildActive = true;
        }

    }
}
