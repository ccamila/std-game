using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRadial : MonoBehaviour
{

    //Atributos
    public float fireRate = 0.01f;
    float tempoTiro = 5f;

    //Unity
    private Transform target;
    private float range;
    public string enemyTag = "Enemy";
    
    
   
    public TurretUI turretUI;
    private ParticleSystem ps;
    public GameObject objCol;
    

    private void Start()
    {
        range = GetComponent<TurretStats>().range;
        GetComponentInChildren<RadialParticlesProperties>().setRange(range);
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop();
        GameObject turretUIobject = GameObject.FindGameObjectWithTag("TurretUI");
        turretUI = turretUIobject.GetComponent<TurretUI>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
    }


    void UpdateTarget()
    {
        //Metodo que procura um alvo, procura o mais próximo e checa se ele está no 'range'
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortDistance = Mathf.Infinity; //Guarda a menor distância
        GameObject nearestEnemy = null; //Inimigo mais próximo encontrado.
        foreach (GameObject enemy in enemies)
        {   //guarda a distancia
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && shortDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else target = null;

        }
    }
    void Update()
    {
        if (target == null) return;
        
        if (tempoTiro >= 0.5f)
        {
            Shoot();
            tempoTiro = 0f;
            
        }
        tempoTiro += Time.deltaTime;
    }

    void Shoot()
    {
        ps.Play();
        StartCoroutine("IncreaseSize"); 
    }

    IEnumerator IncreaseSize()
    {
        float tempo = 0f;
        while (tempo < 0.5f)
        {
            tempo += Time.deltaTime;
            objCol.GetComponent<SphereCollider>().radius = Mathf.Lerp(0,range,0.5f);
            yield return null;
            objCol.GetComponent<SphereCollider>().radius = 0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        //Função que desenha um range de tiro para a torre.       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        if (turretUI.getTarget() == gameObject)
        {
            turretUI.DeselectTurret();

            return;
        }
        Destroy(turretUI.circle);
        turretUI.setTarget(gameObject);
    }

}
