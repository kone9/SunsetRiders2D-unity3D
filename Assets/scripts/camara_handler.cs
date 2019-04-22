using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_handler : MonoBehaviour
{
    public GameObject min;
    public GameObject max;
    public float moverCamara = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectsWithTag("nivel");
        GameObject billy = GameObject.Find("billy"); //busco al objeto billy
        if ((billy.transform.position.x > max.transform.position.x) //si posicion de billy es mayor a la posicion del borde de la camara
        {
            transform.position += new Vector3(moverCamara, 0 ,0); //aumenta posicion de vamara en 5 x
        }
    }
}
