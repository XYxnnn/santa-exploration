using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L1ItemCollector : MonoBehaviour
{
    public static int ring = 0;
    public static int cookie = 0;
    public static int wreath = 0;

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
            ring = 0;
            cookie = 0;
            wreath = 0;
        }
    }

    private void Recollect()
    {
        if (GameManager.recollect == true)
        {
            ring = 0;
            cookie = 0;
            wreath = 0;
            GameManager.recollect = false;
        }
    }
}
