using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator anim;
    private GameObject player;

    public GameObject impactEffect;

    [SerializeField] float speed = 10f;
    public Rigidbody2D rb;
    [SerializeField] private int damage = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

        if (anim.GetBool("Up"))
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log(hit.name);

        if(hit.CompareTag("Enemy"))
        {
            Enemy enemyScript = hit.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
        }

        //Instantiate(impactEffect, hit.poi);

        Destroy(this.gameObject);
    }
}
