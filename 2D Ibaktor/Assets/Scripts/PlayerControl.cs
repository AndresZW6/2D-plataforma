using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //Variables a declarar para utilizar en el script

    //Variable de velocidad de movimiento
    public float moveSpeed;
    //Variable del rigid body asignado al player
    public Rigidbody2D theRB;
    //Variable de salto
    public float jumpForce;
    public float doubleJumpForce;
    private bool canDoubleJump;

    //Variables para saber si mi personaje se encuentra en el piso
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask WhatIsGround;

    //Variable asignada al animator
    private Animator anim;

    //Variable para ejecutar un cambio de direccion
    private SpriteRenderer theSR;

    //Declaramos objetos para interaccion con colliders o disparadores
    public GameObject cuadrado, circulo, capsula, pressF;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();

        //Interacciones con  colliders/disparadores
        cuadrado.SetActive(false);
        circulo.SetActive(true);
        capsula.SetActive(false);
        pressF.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Desplazamiento lateral
        theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.linearVelocity.y);

        //Salto
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, WhatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump")) 
        {
            if(isGrounded)
            {
            theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
            }
            else
            {
                if(canDoubleJump)
                {
                    theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, doubleJumpForce);
                    canDoubleJump = false;
                }
            }
        }

        //Condicion para voltear el sprite 
        if(theRB.linearVelocity.x < 0)
        {
            theSR.flipX = true;
        } else if(theRB.linearVelocity.x > 0)
        {
            theSR.flipX = false;
        }

        //Ejecucion de animaciones de acuerdo a los parametros asignados
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    //Funcion al entrar a un disparador/collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "TriggerCuadrado")
        {
            Debug.Log("Estas entrando al Cuadrado");
        }
        if(other.name == "TriggerCirculo")
        {
            Debug.Log("Estas entrando al Circulo");
            cuadrado.SetActive(true);
            circulo.SetActive(false);
        }
        if(other.name == "TriggerCapsula")
        {
            Debug.Log("Estas entrando a la Capsula");          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if(other.name == "TriggerCuadrado")
        {
            Debug.Log("Estas saliendo del Cuadrado");
            capsula.SetActive(true);
            cuadrado.SetActive(false);
        }
        if(other.name == "TriggerCirculo")
        {
            Debug.Log("Estas saliendo del Circulo");
        }
        if(other.name == "TriggerCapsula")
        {
            Debug.Log("Estas saliendo de la Capsula");
            pressF.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
          if(other.name == "TriggerCuadrado")
        {
            Debug.Log("Estas dentro del Cuadrado");
        }
        if(other.name == "TriggerCirculo")
        {
            Debug.Log("Estas dentro del Circulo");
        }
        if(other.name == "TriggerCapsula")
        {
            Debug.Log("Estas dentro de la Capsula");
            pressF.SetActive(true);
             if(Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Game_002");
            }
        }
    }
} 
