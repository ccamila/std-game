using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
            col.gameObject.GetComponent<Enemy>().Die();
    }
}
