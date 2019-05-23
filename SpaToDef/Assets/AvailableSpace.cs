
using UnityEngine;


public class AvailableSpace : MonoBehaviour
{
    GameObject turret;
    
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Não pode construir");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        this.transform.gameObject.SetActive(false);

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
}
