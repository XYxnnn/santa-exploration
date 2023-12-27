using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int ring = 0;
    public static int present = 0;
    public static int cookie = 0;
    public static int wreath = 0;

    [SerializeField] private Text ringText;
    [SerializeField] private Text presentText;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text wreathText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            ring++;
            ringText.text = "x" + ring;
        }
        if (collision.gameObject.CompareTag("Present"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            present++;
            presentText.text = "x" + present;
        }
        if (collision.gameObject.CompareTag("Cookie"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cookie++;
            cookieText.text = "x" + cookie;
        }
        if (collision.gameObject.CompareTag("Wreath"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            wreath++;
            wreathText.text = "x" + wreath;
        }
    }
}
