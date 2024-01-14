using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    
    private Rigidbody rb;
    //Vector para varias gravedad
    public Vector3 gravedad = new Vector3(0, -9.8f, 0);

    void Start()
    {
        //Obtener componente riyidbodi del obj
        rb= GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Aplicar propia gravedad al objeto
        rb.AddForce(gravedad, ForceMode.Acceleration);

    }
}
