using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float spawnTime = 2f; //Tempo entre as waves
    private float countdown = 2f;
    private int nWave = 0; //Numero da wave
    public Transform enemyPlanet;
    

    void Update(){
        if (countdown <= 0f){
            StartCoroutine(Spawn());
            countdown = spawnTime;
        }
        countdown -= Time.deltaTime;

    }

    IEnumerator Spawn(){
        nWave++;

        for (int i = 0; i < nWave; i++){
            
            Instantiate(enemyPrefab, enemyPlanet.position, enemyPlanet.rotation);
            yield return new WaitForSeconds(0.5f);

        }

        
    }


}
