using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L4ItemCollector : MonoBehaviour
{
    public static int ring = L3ItemCollector.ring;
    public static int cookie = L3ItemCollector.cookie;
    public static int wreath = L3ItemCollector.wreath;

    [SerializeField] private Text ringText;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text wreathText;

    [SerializeField] private AudioSource collectionSoundEffect;

    
    void Awake()
    {
        ringText.text = "x" + ring;
        cookieText.text = "x" + cookie;
        wreathText.text = "x" + wreath;
    }

    void Update()
    {
        Recollect();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            ring++;
            ringText.text = "x" + ring;
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

        if (collision.gameObject.CompareTag("Trap"))
        {
            ring = L3ItemCollector.ring;
            cookie = L3ItemCollector.cookie;
            wreath = L3ItemCollector.wreath;
        }
    }

    private void Recollect()
    {
        if (GameManager.recollect == true)
        {
            ring = L3ItemCollector.ring;
            cookie = L3ItemCollector.cookie;
            wreath = L3ItemCollector.wreath;
            GameManager.recollect = false;
        }
    }
}
