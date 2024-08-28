using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    EnemyAttack enemyAttack;
    RangeEnemyAttack rangeEnemyAttack;

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        rangeEnemyAttack = GetComponent<RangeEnemyAttack>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attention")
        {
            if (tag == "Enemy")
            {
                enemyAttack.enabled = true;
                this.enabled = false;
            }
            if (tag == "RangedEnemy")
            {
                rangeEnemyAttack.enabled = true;
                this.enabled = false;
            }
           
        }
    }
}
