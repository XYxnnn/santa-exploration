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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            Destroy(collision.gameObject);
            ring++;
            ringText.text = "" + ring;
        }
        if (collision.gameObject.CompareTag("Present"))
        {
            Destroy(collision.gameObject);
            present++;
            presentText.text = "" + present;
        }
        if (collision.gameObject.CompareTag("Cookie"))
        {
            Destroy(collision.gameObject);
            cookie++;
            cookieText.text = "" + cookie;
        }
        if (collision.gameObject.CompareTag("Wreath"))
        {
            Destroy(collision.gameObject);
            wreath++;
            wreathText.text = "" + wreath;
        }
    }
}
