using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3ItemCollector : MonoBehaviour
{
    public static int ring = L2ItemCollector.ring;
    public static int cookie = L2ItemCollector.cookie;
    public static int wreath = L2ItemCollector.wreath;

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
            ring = L2ItemCollector.ring;
            cookie = L2ItemCollector.cookie;
            wreath = L2ItemCollector.wreath;
        }
    }

    private void Recollect()
    {
        if (GameManager.recollect == true)
        {
            ring = L2ItemCollector.ring;
            cookie = L2ItemCollector.cookie;
            wreath = L2ItemCollector.wreath;
            GameManager.recollect = false;
        }
    }
}
