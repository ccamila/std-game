using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 2f;
    public float speed;

    private Transform target;
    public int wavepointIndex = 0;
    public GameObject nextEnemy;
    public int value;
    

    void Start(){

        target = Waypoints.points[wavepointIndex]; //Vetor de "Ways"
        speed = startSpeed;

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * (1f-.75f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f){

            GetNextWayPoint();

        }
        speed = startSpeed;

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
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;

    }

    public void Die()
    {
        if(nextEnemy != null)
        {
            GameObject newEnemy= Instantiate(nextEnemy,transform.position,transform.rotation);
            newEnemy.GetComponent<Enemy>().wavepointIndex = wavepointIndex;
            
        }
        else
        {
            WaveSpawner.enemiesAlive--;
        }
        
        PlayerStats.money += value;
        Destroy(gameObject);

    }

    public void Slow(float slowAmount)
    {
        speed = speed * (1f - slowAmount);
    }
}


