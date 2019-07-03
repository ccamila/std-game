
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint radialTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;


    public ChangeColor changeColor;
    public GameObject standardTurretButton;
    public GameObject radialTurretButton;
    public GameObject laserTurretButton;
    


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        
        buildManager.SelectTurretToBuild(standardTurret);
        buildManager.enable = true;
        changeColor.SelectedColor(standardTurretButton);
        
    }

    public void SelectRadialTurret()
    {
        
        buildManager.SelectTurretToBuild(radialTurret);
        buildManager.enable = true;
        changeColor.SelectedColor(radialTurretButton);
    }

    public void SelectlLaserTurret()
    {

        buildManager.SelectTurretToBuild(laserTurret);
        buildManager.enable = true;
        changeColor.SelectedColor(laserTurretButton);
    }

    
}
