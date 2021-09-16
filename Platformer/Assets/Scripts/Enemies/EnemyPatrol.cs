using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private int targetPoint = 2;
    Vector2 targetPosition;

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
            targetPosition = new Vector2(point1.transform.position.x, this.transform.position.y);
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (targetPoint == 2)
        {
            targetPosition = new Vector2(point2.transform.position.x, this.transform.position.y);
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
