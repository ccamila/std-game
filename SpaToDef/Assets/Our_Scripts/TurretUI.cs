using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    private GameObject target;
    public GameObject ui;

    public void SetTarget(GameObject _target)
    {
        target = _target;

        transform.position = target.transform.position;
        ui.SetActive(true);
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public void DeselectTurret()
    {
        target = null;
        Hide();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

   
}
