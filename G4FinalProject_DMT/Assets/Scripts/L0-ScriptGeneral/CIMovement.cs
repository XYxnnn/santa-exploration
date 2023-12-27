using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIMovement : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private float speed = 200f;
    public static int number;
    public GameObject AnnouceBoard;

    // Start is called before the first frame update
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);

        if (transform.position == destination.transform.position)
        {
            gameObject.SetActive(false);
            number++;
            Debug.Log("number: "+number);
        }

        if (number == 3)
        {
            AnnouceBoard.SetActive(true);
        }
    }
}
