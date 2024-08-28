using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawner : Tool
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropCount = 15;

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 pos = transform.position;
            GameObject go = Instantiate(drop);
            go.transform.position = pos;
        }
        Destroy(gameObject);
    }
}
