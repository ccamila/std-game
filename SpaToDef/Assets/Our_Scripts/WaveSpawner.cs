using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform starterPoint;

    public float timeWaves = 5f; //Tempo entre as waves
    private float countdown = 2f;
    private int waveNumber = 0;

    public Text waveCount;

    private void Start()
    {
        countdown = timeWaves;
    }

    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = timeWaves;
        }

        countdown -= Time.deltaTime;
        waveCount.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawn()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, starterPoint.position, starterPoint.rotation);

    }

}

