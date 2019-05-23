
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject radialTurretPrefab;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
