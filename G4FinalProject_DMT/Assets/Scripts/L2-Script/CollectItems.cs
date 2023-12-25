using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItmes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CollectItems"))
        {
            Destroy(collision.gameObject);
        }
    }
}
