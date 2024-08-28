using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyController>().TakeDamage(25);
        }
        if (collision.tag == "RangedEnemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyController>().TakeDamage(25);
        }
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    
    private void Destroy()
    {
        Object.Destroy(gameObject, 0.2f);
    }

}
