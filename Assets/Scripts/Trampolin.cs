using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    // Variable spublicas para ajustar desde el inspector
    public float ConstanteElastica = 10f;
    public float longitudNatural = 0.5f;
    //public float amortiguamiento = 0.5f;

    //Variables privadas para calculos internos
    private float posicionObjeto;
    private float velocidadObjeto;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjCae"))
        {
            AplicarFuerzaRestauradora(collision.gameObject);
        }

    }

    private void AplicarFuerzaRestauradora(GameObject ObjCae)
    {
        Rigidbody rbObjCae = ObjCae.GetComponent<Rigidbody>();

        if (rbObjCae != null)
        {
            //Calcular posicion relativa entre el obj y la superficie
            float posicionRelativa = rbObjCae.transform.position.y - transform.position.y;

            //calcular la fuerza elastica segun ley d hooke
            float fuerzaElastica = ConstanteElastica * (posicionRelativa - longitudNatural);

            //Aplicar fuerza parriba

            rbObjCae.AddForce(Vector3.up * fuerzaElastica, ForceMode.Impulse);
        }
    }
}

