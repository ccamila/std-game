using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "turret")
            Destroy(gameObject);
    }
}
