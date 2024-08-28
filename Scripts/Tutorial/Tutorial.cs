using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private AudioSource movement;
    [SerializeField] private AudioSource shotgun;
    [SerializeField] private AudioSource killZombies;
    [SerializeField] private AudioSource killSlimes;
    [SerializeField] private AudioSource infoGoal;
    [SerializeField] private AudioSource collectKeys;
    [SerializeField] private AudioSource minimap;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tutorialmovement")
        {
            movement.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialshotgun")
        {
            shotgun.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialkillzombies")
        {
            killZombies.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialkillslimes")
        {
            killSlimes.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialinfogoal")
        {
            infoGoal.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialcollectkeys")
        {
            collectKeys.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tutorialminimap")
        {
            minimap.Play();
            Destroy(collision.gameObject);
        }
    }
}
