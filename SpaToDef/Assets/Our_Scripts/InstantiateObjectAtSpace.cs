using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectAtSpace : MonoBehaviour
{
    Vector3 mousePosition;
    BuildManager buildManager;
    public Camera camera;
    public ChangeColor changeColor;
    public LayerMask m_LayerMask;

    private void Start()
    {
        buildManager = BuildManager.instance;
        buildManager.enable = false;
    }

 
    void Update()
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
      
        if (Physics.Raycast(ray, out hit) && buildManager.CanBuild )
        {
            Collider[] hitColliders = Physics.OverlapBox(hit.point, buildManager.getTurretToBuild().prefab.transform.localScale/2, Quaternion.identity, layerMask);
            if (hitColliders.Length == 0 && !hit.collider.transform.gameObject.GetComponentInChildren<MeshCollider>() )
            {
                buildManager.BuildTurretOn(hit.point);
                changeColor.DefaultColor();
            }
            
        }
    }

}
