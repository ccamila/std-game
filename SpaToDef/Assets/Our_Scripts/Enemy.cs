using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start(){

        target = Waypoints.points[0]; //Vetor de "Ways"

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * (1f-.75f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f){

            GetNextWayPoint();

        }

    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length-1){
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lifes = PlayerStats.Lifes - 1;
        Debug.Log(PlayerStats.Lifes);
        Destroy(gameObject);
    }

}


