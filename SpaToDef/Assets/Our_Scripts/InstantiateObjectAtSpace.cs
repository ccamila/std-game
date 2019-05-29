using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectAtSpace : MonoBehaviour
{
    Vector3 mousePosition;
    BuildManager buildManager;
    GameObject turret;
    public Camera camera;
    public ChangeColor changeColor;
    public LayerMask m_LayerMask;

    private void Start()
    {
        buildManager = BuildManager.instance;
        buildManager.enable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (buildManager.enable && Input.GetMouseButtonDown(0))
        {
            BuildTurret();
        }
        
    }
    void BuildTurret()
    {
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Turrets");
        int layerMaskPath = LayerMask.GetMask("Ground");
        
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hit, layerMask) && buildManager.getTurretToBuild() != null)
        {
            GameObject turretToBuild = buildManager.getTurretToBuild();
            
            
            Collider[] hitColliders = Physics.OverlapBox(hit.point, turretToBuild.transform.localScale , Quaternion.identity, layerMask);
            Debug.Log(hitColliders.Length);
            if (hitColliders.Length == 0 && !hit.collider.transform.gameObject.GetComponentInChildren<MeshCollider>() )
            {
                
                turret = (GameObject)Instantiate(turretToBuild, hit.point, Quaternion.identity);
                buildManager.SetTurretToBuild(null);
                buildManager.enable = false;
                changeColor.DefaultColor();
            }
            
        }
    }

}
