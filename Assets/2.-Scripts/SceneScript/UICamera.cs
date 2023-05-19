using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{

    public Transform player;
    public float Xpos;
    public float Ypos;
    public float Zpos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x + Xpos, player.position.y + Ypos, Zpos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + Xpos, player.position.y + Ypos, Zpos);
    }
}
