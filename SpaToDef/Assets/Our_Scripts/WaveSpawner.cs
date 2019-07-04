using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    //public Transform enemyPrefab;
    public static int enemiesAlive;

    public Text waveAtual;


    public Wave[] waves;

    public Transform starterPoint;

    public float timeWaves = 5f; //Tempo entre as waves
    private float countdown = 2f;
    private int waveNumber = 0;

    public Text waveCount;
    public Button nextWave;

    public GameMananger gameManager;

    private void Start()
    {
        countdown = timeWaves;
    }

    void Update()
    {
        waveAtual.text = waveNumber.ToString();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
         
        }
        nextWave.gameObject.SetActive(false);
        if (countdown <= 0f)
        {
            waveCount.gameObject.SetActive(false);
            StartCoroutine(Spawn());
            countdown = timeWaves;
            
            return;
        }
        waveCount.gameObject.SetActive(true);
        countdown -= Time.deltaTime;
        nextWave.gameObject.SetActive(true);
        waveCount.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawn()
    {



        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {

            SpawnEnemy(wave.enemy);
            
            yield return new WaitForSeconds(1f/ wave.rate);
        }

        waveNumber++;



    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, starterPoint.position, starterPoint.rotation);
        enemiesAlive++;

    }

    public void nextWaveTrigger()
    {
        if (enemiesAlive > 0)
        {
            nextWave.gameObject.SetActive(false);
        }
        nextWave.gameObject.SetActive(false);
        waveNumber += 1;
        countdown = -1f;    
    }

}

