using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;
    public int wavepointIndex = 0;
    public GameObject nextEnemy;
    public int value;

    void Start(){

        target = Waypoints.points[wavepointIndex]; //Vetor de "Ways"

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

    public void Die()
    {
        if(nextEnemy != null)
        {
            GameObject newEnemy= Instantiate(nextEnemy,transform.position,transform.rotation);
            newEnemy.GetComponent<Enemy>().wavepointIndex = wavepointIndex;
            
        }
        Destroy(gameObject);
        PlayerStats.money += value;
    }
}


