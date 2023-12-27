using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIMovement : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private float speed = 250f;
    public static int number;
    public GameObject AnnouceBoard;
    public GameObject replayButton;
    public GameObject quitButton;

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
            replayButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }
}
