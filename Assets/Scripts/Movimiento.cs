using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    public float velocidadMovimiento = 5f;

    public float fuerzaSalto = 10f;

    void Update()
    {
        // Obtener las entradas de teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;

        // Aplicar el movimiento al jugador
        transform.Translate(movimiento);

        // Verificar si el jugador quiere saltar
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    void Saltar()
    {
        // Aplicar una fuerza vertical para simular el salto
        GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
}

