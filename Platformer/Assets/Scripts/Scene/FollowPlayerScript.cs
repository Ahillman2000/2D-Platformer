using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
