using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    EnemyAttack enemyAttack;
    RangeEnemyAttack rangeEnemyAttack;
    PlayerController player;
    public int enemyHP = 100;
    Animator animator;
    const string ENEMY_WALK = "Enemy_Walk";
    const string ENEMY_DEATH = "Enemy_Death";
    const string RANGED_ENEMY_DEATH = "Ranged_Enemy_Death";
    string currentAnimState;
    public Slider enemyHealthBar;

    //LookAtPlayer
    public Transform targetToLookAt;
    private Vector3 v_diff;
    private float atan2;

    [SerializeField] private AudioSource zombieAliveSound;
    [SerializeField] private AudioSource rangeZombieAliveSound;
    [SerializeField] private AudioSource zombieDeathSound;
    [SerializeField] private AudioSource RangezombieDeathSound;

    GameObject target;
    void Start()
    {
        if (tag == "Enemy")
        { 
            zombieAliveSound.Play(); 
        }
        if (tag == "RangedEnemy")
        {
            rangeZombieAliveSound.Play();
        }
        //this line ignores collision with enemy, but when I enable, attack system doesnt work... target = GameObject.FindGameObjectWithTag("Player").transform;
        //this also Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        player = FindObjectOfType<PlayerController>();
        enemyHealthBar.value = enemyHP;
        enemyAttack = GetComponent<EnemyAttack>();
        rangeEnemyAttack = GetComponent<RangeEnemyAttack>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (enemyHP > 0)
        {
            //lookAtPlayer
            v_diff = (targetToLookAt.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }
    void ChangeAnimationState(string newState)
    {
        //stop animation from interrupting itself
        if (currentAnimState == newState)
        {
            return;
        }

        //Play new anitmation
        animator.Play(newState);

        currentAnimState = newState;

    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            //Add get hit animation here!!!
            //animator.SetTrigger("damage");
        }
        else
        {
            ScoreManager.instance.AddPoint();
            //Add death animation here
            //animator.SetTrigger("death");
            GetComponent<BoxCollider2D>().enabled = false;
            //remove this line, if we want the corpses of the zombies to stack on the ground...
            Object.Destroy(gameObject, 3.0f);
            if(tag == "Enemy")
            {
                ChangeAnimationState(ENEMY_DEATH);
                enemyAttack.enabled = false;
                zombieAliveSound.Stop();
                zombieDeathSound.Play();
            }
            if (tag == "RangedEnemy")
            {
                ChangeAnimationState(RANGED_ENEMY_DEATH);
                rangeEnemyAttack.enabled = false;
                rangeZombieAliveSound.Stop();
                RangezombieDeathSound.Play();
            }
        }
    }
}
