using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private GameObject target;
    public GameObject ui;
    public GameObject CircleRange;
    public GameObject circle;
    public float turretRange = 1f;
    BuildManager buildManager;
    public Text upgradeCost;
    public Text sellCost;
    public GameObject sellFX;
    


    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void setTarget(GameObject _target)
    {
        target = _target;
        transform.position = target.transform.position;
        turretRange = target.GetComponent<TurretStats>().range;
        if(!target.GetComponent<TurretStats>().isUpgraded)
        {
            upgradeCost.text = "$" + target.GetComponent<TurretStats>().blueprint.upgradeCost;
        }
        else
        {
            upgradeCost.text = "MAXED";
        }
        
        sellCost.text = "$" + target.GetComponent<TurretStats>().sellCost;
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
        GameObject fxInst = (GameObject)Instantiate(sellFX, transform.position, transform.rotation);
        Destroy(target);
        DeselectTurret();
    }

    public void UpgradeSelected()
    {
        if(!target.GetComponent<TurretStats>().isUpgraded && PlayerStats.money >= target.GetComponent<TurretStats>().blueprint.upgradeCost)
        {
            Vector3 pos = target.transform.position;
            buildManager.SelectTurretToBuild(target.GetComponent<TurretStats>().blueprint);
            Destroy(target);
            DeselectTurret();
            buildManager.UpgradeTurret(pos);
        }
    }
}
