using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyController refScript;
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    public float speed;
    public Transform target;
    public float minimumDistance;

    private void Start()
    {
        this.enabled = false;
        refScript = GetComponent<EnemyController>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, target.position) < minimumDistance && attackSpeed <= canAttack)
        {
            playerHealth.UpdateHealth(-attackDamage);
            canAttack = 0f;
            StartCoroutine(DisableScript());
        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }

    //remove this if I want the enemy to keep following instantly.
    IEnumerator DisableScript()
    {
        this.enabled = false;
        yield return new WaitForSeconds(1f);
        if (refScript.enemyHP > 0)
        {
            this.enabled = true;
        }
        else if (refScript.enemyHP < 0)
        {
            this.enabled = false;
        }
    }
}
