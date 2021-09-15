using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    [SerializeField] int maxLives = 3;
    public int currentLives;
    //public int damage = 1;

    [SerializeField] GameObject projectile;

    [SerializeField] Transform standingFirePoint;
    [SerializeField] Transform crouchingFirePoint;
    [SerializeField] Transform upFirePoint;

    [SerializeField] private float knockbackForce = 10f;

    void Start()
    {
        currentLives = maxLives;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(1);
        }
    }

    void Shoot()
    {
        anim.SetTrigger("Shoot");

        GameObject shot;
        if(anim.GetBool("Crouching"))
        {
            shot = Instantiate(projectile, crouchingFirePoint.position, standingFirePoint.rotation);
        }
        else if(anim.GetBool("Up"))
        {
            shot = Instantiate(projectile, upFirePoint.position, standingFirePoint.rotation);
        }
        else
        {
            shot = Instantiate(projectile, standingFirePoint.position, standingFirePoint.rotation);
        }

        Destroy(shot, 2.5f);
    }


    public void TakeDamage(int _damage)
    {
        anim.SetTrigger("Hurt");

        // face place towards attacking enemey
        // push character in opposite direction from attacking enemy

        rb.AddForce(this.transform.right * -1 * knockbackForce, ForceMode2D.Impulse);

        currentLives -= _damage;

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // die
        Debug.Log("GAME OVER");
    }
}
