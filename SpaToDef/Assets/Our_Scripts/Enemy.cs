using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;



    private void Start()
    {
        target = Waypoints.points[0]; //Vetor de "Ways"
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            getNextWayPoint();
        }

    }

    void getNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1) Destroy(gameObject);

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }


}


