using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    private void Start()
    {
        targetPosition = FindObjectOfType<PlayerController>().transform.position;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerHealth>().UpdateHealth(-5);
        }
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
