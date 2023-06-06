using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public Transform pointA, pointB;
    public float speed;
    public bool shouldMove;
    public bool shouldWait;

    bool moveToA;
    bool moveToB;

    // Start is called before the first frame update
    void Start()
    {
        moveToA = true;
        moveToB = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        float distanceToA = Vector2.Distance(transform.position, pointA.position);
        float distanceToB = Vector2.Distance(transform.position, pointB.position);

        if (distanceToA > 0.1f && moveToA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if ( distanceToA < 0.3f)
            {
                moveToA = false;
                moveToB = true;
            }
        }

        if (distanceToB > 0.1f && moveToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (distanceToB < 0.3f)
            {
                moveToA = true;
                moveToB = false;
            }
        }

    }

}
