using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    [SerializeField] private float speed = 1f;

    private int targetPoint = 2;

    void Start()
    {
        this.transform.position = point1.position;
    }

    void Update()
    {
        if(this.transform.position.x <= point1.position.x)
        {
            targetPoint = 2;
            transform.Rotate(0f, 180f, 0f);
        }
        else if(this.transform.position.x >= point2.position.x)
        {
            targetPoint = 1;
            transform.Rotate(0f, 180f, 0f);
        }

        if(targetPoint == 1)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, point1.position, speed * Time.deltaTime);
        }
        else if (targetPoint == 2)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, point2.position, speed * Time.deltaTime);
        }
    }
}
