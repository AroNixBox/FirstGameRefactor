using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour
{
    EnemyController refScript;
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;

    public float speed;
    public Transform target;
    public float shotDistance;
    public float minimumDistance;
    public float maximumDistance;

    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;

    private void Start()
    {
        this.enabled = false;
        refScript = GetComponent<EnemyController>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            if (Vector2.Distance(transform.position, target.position) < shotDistance)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                nextShotTime = Time.time + timeBetweenShots;
            }
            if (Vector2.Distance(transform.position, target.position) > maximumDistance)
            {
                StartCoroutine(MoveTowards());
            }
        }
        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            StartCoroutine(MoveAway());
        }
    }
    IEnumerator MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator MoveAway()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }
}
