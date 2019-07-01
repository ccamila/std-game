using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    
    int segments = 50;
    
    public float radius;
    
    LineRenderer line;

    void Start()
    {
        radius = GameObject.FindGameObjectWithTag("TurretUI").GetComponent<TurretUI>().turretRange;
        line = gameObject.GetComponent<LineRenderer>();

        
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius ;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius ;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }
}