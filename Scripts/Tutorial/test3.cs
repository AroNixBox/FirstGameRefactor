using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(DestroyPlattform1());
        }
    }
    IEnumerator DestroyPlattform1()
    {
        yield return new WaitForSeconds(18);
        Destroy(gameObject);
    }
}
