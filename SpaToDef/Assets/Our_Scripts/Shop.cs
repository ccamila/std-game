
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public ChangeColor changeColor;
    public GameObject stdT;
    public GameObject rdT;
    


    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        buildManager.enable = true;
        changeColor.SelectedColor(stdT);
        
    }

    public void PurchaseRadialTurret()
    {
        Debug.Log("Radial Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.radialTurretPrefab);
        buildManager.enable = true;
        changeColor.SelectedColor(rdT);
    }

}
