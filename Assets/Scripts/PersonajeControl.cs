using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControl : MonoBehaviour
{

    public float multipSprint = 1.9f;
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    private Animator anim;
    private Rigidbody rbPlayer;

    public float x, y;

    //public bool tocandoRecuerdo;
    //public bool avanzarSolo;
    // ^ esto para que querian usarlo?

    void Start()
    {

        anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {
        
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        rbPlayer.MovePosition(transform.position + transform.forward * y * Time.deltaTime * velocidadMovimiento);
        
        #region Viejo
        //if(!tocandoRecuerdo)
        //{

        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        //}

        /*  if(avanzarSolo)
          {
              rb.velocicity = transform.forward
          }*/
        #endregion

    }


    void Update()
    {
        x = Input.GetAxis("Horizontal") ;

        var sprintVal = Input.GetAxis("Sprint") != 0 ? multipSprint : 1;
        y = Input.GetAxis("Vertical") * sprintVal; // movimiento * correr

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (sprintVal != 1) // muuy primitivo pero ahora nos sirve para usar la misma animacion de caminar
            this.anim.speed = 1.3f;
        else
            this.anim.speed = 1;

    }

    //public void DejoDeTocar()
    //{
    //    tocandoRecuerdo = false;
    //}

    //public void DejoDeAvanzar()
    //{
    //    avanzarSolo = false;
    //}
}
