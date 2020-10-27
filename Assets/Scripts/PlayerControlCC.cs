using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCC : MonoBehaviour
{
    public Animator anim;

    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    public float multipSprint = 1.9f;


    private float turnSmoothVel;
    private bool active = true;

    private void Awake()
    {
        NarrativeManager.instance.PreviousInteraction.AddListener(DisableComponent);
        NarrativeManager.instance.PostInteraction.AddListener(EnableComponent);

    }
    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        var sprintVal = Input.GetAxis("Sprint") != 0 ? multipSprint : 1;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude >= 0.1f) // check constante
        {
            

            if (sprintVal != 1) // muuy primitivo pero ahora nos sirve para usar la misma animacion de caminar
                this.anim.speed = 1.3f;
            else
                this.anim.speed = 1;

            //calculo la rotacion que tiene que hacer el personaje
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; 
            // angulo + offset basado en como esta la camara
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //para mover en la direccion correcta
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * sprintVal * Time.deltaTime);
        }

        anim.SetFloat("VelX", horizontal);
        anim.SetFloat("VelY", vertical);
    }

    void DisableComponent()
    {
        anim.SetFloat("VelX", 0);
        anim.SetFloat("VelY", 0);

        this.active = false;
    }

    void EnableComponent()
    {
        this.active = true;
    }
}
