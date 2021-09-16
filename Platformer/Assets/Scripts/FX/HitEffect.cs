using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
