using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    private GameObject target;
    public GameObject ui;
    public GameObject CircleRange;
    public GameObject circle;
    public float turretRange = 1f;
    

    public void setTarget(GameObject _target)
    {
        target = _target;
        transform.position = target.transform.position;
        turretRange = target.GetComponent<TurretStats>().range;
        circle = Instantiate(CircleRange, new Vector3(target.transform.position.x, target.transform.position.y + 0.25f, target.transform.position.z), Quaternion.identity);
        ui.SetActive(true);
    }

    public GameObject getTarget()
    {
        return target;
    }

    public void DeselectTurret()
    {
        Destroy(circle);
        target = null;
        Hide();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void SellSelected()
    {
        TurretStats turretStats = target.GetComponent<TurretStats>();
        PlayerStats.money += turretStats.sellCost;
        Destroy(target);
        DeselectTurret();



    }
}
