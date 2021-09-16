using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float duration = 3f;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine((Pickup(other)));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Powerup picked up");
        // do something

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        Debug.Log("Powerup worn off");

        Destroy(this.gameObject);
    }
}
