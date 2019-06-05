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

    public GameObject standardTurretPrefab;
    public GameObject radialTurretPrefab;

    public bool CanBuild { get { return turretToBuild != null; } }
    

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }

    public void BuildTurretOn(Vector3 pos)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Tratar falta de dinheiro");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, pos, Quaternion.identity);
        turretToBuild = null;
        turretList.Add(turret);
        enable = false;
    }

    public void setSelectedTurret(GameObject turret)
    {
        selectedTurret = turret;
    }
}
