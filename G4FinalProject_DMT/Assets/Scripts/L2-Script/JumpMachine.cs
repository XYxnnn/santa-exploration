using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private float speed = 5f;
    private int pointNum = 1;
    private float waitTime = 0.5f;
    
    // Start is called before the first frame update
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed*Time.deltaTime);

        if (Vector2.Distance(transform.position, points[pointNum].transform.position) < 0.1f){
            /*pointNum++;
            if (pointNum >= points.Length)
            {
                pointNum = 0;
            }*/

            if (waitTime < 0)
            {
                if (pointNum == 0)
                {
                    pointNum = 1;
                }
                else
                {
                    pointNum = 0;
                }
                waitTime = 0.5f;
            }
            else
                waitTime -= Time.deltaTime;
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Santa")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Santa")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }


}
