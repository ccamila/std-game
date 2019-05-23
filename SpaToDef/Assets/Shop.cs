
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
}
