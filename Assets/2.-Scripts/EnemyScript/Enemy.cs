using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    public float maxhealth;
    public float healtpoint;
    public float speed;
    public float knocbackForceX;
    public float knocbackForceY;
    public float damageToGive;
    public float ExpToGive;

    public static implicit operator GameObject(Enemy v)
    {
        throw new NotImplementedException();
    }
}
