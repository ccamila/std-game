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
    public Button nextWave;

    private void Start()
    {
        countdown = timeWaves;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (countdown <= 0f)
        {
            waveCount.gameObject.SetActive(false);
            StartCoroutine(Spawn());
            countdown = timeWaves;
            return;
        }
        if (enemies.Length == 0)
        {
            waveCount.gameObject.SetActive(true);
            countdown -= Time.deltaTime;
            nextWave.gameObject.SetActive(true);  
        }
        waveCount.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawn()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, starterPoint.position, starterPoint.rotation);

    }

    public void nextWaveTrigger()
    {
        nextWave.gameObject.SetActive(false);
        countdown = -1f;    
    }

}

