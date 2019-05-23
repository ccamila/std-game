
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

    public void PurchaseRadialTurret()
    {
        Debug.Log("Radial Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.radialTurretPrefab);
    }
}
