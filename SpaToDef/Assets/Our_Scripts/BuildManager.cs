using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private List<GameObject> turretList = new List<GameObject>();
    public GameObject selectedTurret;
    private TurretBlueprint turretToBuild;
    public bool enable;

    void Awake()
    {
        instance = this;
    }

    

    public bool CanBuild { get { return turretToBuild != null; } }
    

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }

    public void BuildTurretOn(Vector3 pos)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Build Manager: Tratar falta de dinheiro");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, pos, Quaternion.identity);
        turret.GetComponent<TurretStats>().blueprint = getTurretToBuild();
        turretToBuild = null;
        turretList.Add(turret);
        enable = false;
    }

    public void UpgradeTurret(Vector3 pos)
    {
        if (PlayerStats.money < turretToBuild.upgradeCost)
        {
            Debug.Log("Build Manager: Tratar falta de dinheiro");
            return;
        }
        PlayerStats.money -= turretToBuild.upgradeCost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.upgradePrefab, pos, Quaternion.identity);
        turret.GetComponent<TurretStats>().isUpgraded = true;
        turretToBuild = null;
        turretList.Add(turret);
        enable = false;
    }

    public void setSelectedTurret(GameObject turret)
    {
        selectedTurret = turret;
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }
}
