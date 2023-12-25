using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3MoveFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    private int currentPointIndex = 0;

    public float speed = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(points[currentPointIndex].transform.position, transform.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= points.Length)
            {
                currentPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].transform.position, Time.deltaTime * speed);
    }
}
