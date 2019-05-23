using UnityEngine.EventSystems;
using UnityEngine;


public class AvailableSpace : MonoBehaviour
{
    GameObject turret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(buildManager.getTurretToBuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Não pode construir");
            return;
        }

        GameObject turretToBuild = buildManager.getTurretToBuild();
        this.transform.gameObject.SetActive(false);

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        buildManager.SetTurretToBuild(null);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }



}
