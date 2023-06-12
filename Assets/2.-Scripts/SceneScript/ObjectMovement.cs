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

        // Comprobar que el objeto no ha llegado al punto A
        if (distanceToA > 0.1f && moveToA)
        {
            // Generamso el movimiento del objeto hacia el punto A
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

            // Cuando llega al limite cambiamos para que se dirija hacia el punto B
            if ( distanceToA < 0.3f)
            {
                moveToA = false;
                moveToB = true;
            }
        }

        // Comprobar que el objeto no ha llegado al punto B
        if (distanceToB > 0.1f && moveToB)
        {
            // Generamso el movimiento del objeto hacia el punto B
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

            // Cuando llega al limite cambiamos para que se dirija hacia el punto A
            if (distanceToB < 0.3f)
            {
                moveToA = true;
                moveToB = false;
            }
        }

    }

}
