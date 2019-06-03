
using UnityEngine;

public class Bullet : MonoBehaviour{

    private Transform target;
    public float speed = 70f;
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

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            Hit();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World); //Mover a umavelocidade constante
    }

    void Hit()
    {
        Destroy(gameObject);
    }
}
