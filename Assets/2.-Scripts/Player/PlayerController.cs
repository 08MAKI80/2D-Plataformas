using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, FuerzaSalto;
    float velX, velY;
    new Rigidbody2D rigidbody;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundcheckRadius;
    public LayerMask whatIsGround;
    Animator anim;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatIsGround);



        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        FlipPersonaje();
        Ataque();
    }

    private void FixedUpdate()
    {
        Movimiento();
        Salto();
    }

    //Movimiento del personaje
    public void Movimiento()
    {
       
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigidbody.velocity.y;

        rigidbody.velocity = new Vector2(velX * speed, velY);

        if(rigidbody.velocity.x != 0) anim.SetBool("Walk", true);
        else anim.SetBool("Walk", false);
    }

    public void Salto()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, FuerzaSalto);
        }
    }

    // Direccion del movimiento del personaje
    public void FlipPersonaje()
    {
        if (rigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Ataque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }else
        {
            anim.SetBool("Attack", false);
        }
    }
}
