using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Santa")
        {
            StartCoroutine(SetParentCoroutine(collision.gameObject.transform, transform));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Santa")
        {
            StartCoroutine(SetParentCoroutine(collision.gameObject.transform, null));
        }
    }

    private IEnumerator SetParentCoroutine(Transform child, Transform parent)
    {
        yield return new WaitForEndOfFrame(); // Wait until the end of the frame

        child.SetParent(parent);
    }
}