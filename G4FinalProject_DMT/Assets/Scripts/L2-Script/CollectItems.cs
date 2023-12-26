using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectItmes : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CollectItems"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
        }
    }
}
