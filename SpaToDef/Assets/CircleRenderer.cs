using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    
    int segments = 50;
    [Range(0, 5)]
    public float xradius;
    [Range(0, 5)]
    public float zradius;
    LineRenderer line;

    void Start()
    {
        xradius = gameObject.GetComponentInParent<Turret>().range;
        zradius = xradius;
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
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius / transform.parent.lossyScale.x;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * zradius / transform.parent.lossyScale.z;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }
}