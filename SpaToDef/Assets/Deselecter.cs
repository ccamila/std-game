using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselecter : MonoBehaviour
{
    public GameObject aux;
    private void OnMouseDown()
    {
        if(aux.GetComponent<TurretUI>().getTarget() != null)
        {
            aux.GetComponent<TurretUI>().DeselectTurret();
        }
    }
}
