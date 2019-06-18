
using UnityEngine;

public class Bullet : MonoBehaviour{

    private Transform target;
    public float speed = 70f;
    public float explosionField 
    public GameObject impactFX;
    

    public void Chase(Transform t)
    {
        target = t;
    }

    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //fim - inicio
        float distance = speed * Time.deltaTime; //quanto 

        if (dir.magnitude <= distance){
            Hit();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World); //Mover a umavelocidade constante
        transform.LookAt(target);
    }

    void Hit(){
        GameObject fxInst = (GameObject)Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(fxInst, 2f);

        if (explosionField > 0f)
        {
            Explode();
        }
        else
        {
          
        }

        Destroy(target.gameObject);
        PlayerStats.money += 100;
    }

    void Damage (Transform enemy)
    {
        Destroy(target.gameObject);
    }


}
