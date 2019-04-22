using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_handler : MonoBehaviour
{
    public Vector2 velocidad;
    bool is_ground = false;
    public float vel_desp;
    public GameObject spr1; //declaro un game object como componente para agregarlo desde el editor
    public GameObject spr2; //declaro un game object como componente para agregarlo desde el editor


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 posicion = transform.position; //variable de tipo vector 3 con las posiciones de x,y,z iniciales

        if (Input.GetKeyDown(KeyCode.A)) //si presiono la tecla A.
        {
            GetComponent<Animator>().SetInteger("estado", 1);//cambio al estado 1 para cambiar la animacion a caminar
            velocidad.x = -vel_desp; //velocidad constante en x


            if (!spr1.GetComponent<SpriteRenderer>().flipX) //sino esta volteado
            {
                spr1.GetComponent<SpriteRenderer>().flipX = true; //esta volteado es false.Da vuelta el sprite
                spr2.GetComponent<SpriteRenderer>().flipX = true; //esta volteado es false.Da vuelta el sprite
                spr2.transform.position += new Vector3(-0.07f, 0, 0); //corrijo la mala posicion del sprite
             }


        }

        if (Input.GetKeyDown(KeyCode.D)) //si presiono la tecla D.
        {
            GetComponent<Animator>().SetInteger("estado", 1);//cambio al estado 1 para cambiar la animacion a caminar
            velocidad.x = vel_desp; //velocidad constante en x


            if (spr1.GetComponent<SpriteRenderer>().flipX) //si esta volteado
            {
                spr1.GetComponent<SpriteRenderer>().flipX = false; //esta volteado es false.Da vuleta el sprite
                spr2.GetComponent<SpriteRenderer>().flipX = false; //esta volteado es false.Da vuleta el sprite
                spr2.transform.position += new Vector3(0.07f, 0, 0); //corrijo la mala posicion del sprite
            }

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) //si suelto la tecla A o la tecla D
        {
            velocidad.x = 0.0f;
            GetComponent<Animator>().SetInteger("estado", 0);//cambio al estado 1 para cambiar la animacion a caminar

        }



        if (Input.GetKey(KeyCode.W)) //si presiono la tecla W.
        {

        }
        if (Input.GetKey(KeyCode.S)) //si presiono la tecla S.
        {

        }


    }
    private void FixedUpdate() //funcion actualixar con mejoras para fisicas.
    {
        if (!is_ground) //sino esta en el suelo
        {
            velocidad += Physics2D.gravity * Time.deltaTime; //multiplicamos gravedad por tiempo para obtener velocidad porque la velocidad es  = a aceleracion por tiempo
        }

        GetComponent<Rigidbody2D>().position += velocidad * Time.deltaTime; //tomo el componente rigging body 2D position y aplico la gravedad en "Y" y el desplazamiento en "X"
    }



    private void OnCollisionEnter2D(Collision2D collision) //si un cuerpo2D entra
    {
        if(collision.gameObject.tag == "suelo") //tag seria como los grupos de godot engine..Si esta en el grupo suelo
        {
            if (!is_ground)
            {
                is_ground = true;
                velocidad.y = 0;
            }
            
        }
        
    }

}
