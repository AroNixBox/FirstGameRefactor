using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    PlayerController playercon;
    Rigidbody2D rb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float pickupZone = 0.5f;

    private void Awake()
    {
        playercon = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            StartCoroutine(UnlockChest());
        }

    }
    private void UseTool()
    {
        Vector2 pos = rb.position + playercon.lastPost * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, pickupZone);

        foreach (Collider2D c in colliders)
        {
            Tool hit = c.GetComponent<Tool>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
    IEnumerator UnlockChest()
    {
        yield return new WaitForSeconds(2);
        UseTool();
    }
}