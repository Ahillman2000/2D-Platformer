using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private int damage = 1;

    public GameObject deathEffectPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("something entered trigger");

        if (other.CompareTag("Player"))
        {
            Debug.Log("attack player");

            PlayerCombat playerCombat = other.GetComponent<PlayerCombat>();
            playerCombat.TakeDamage(damage);
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject deathEffect = Instantiate(deathEffectPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
