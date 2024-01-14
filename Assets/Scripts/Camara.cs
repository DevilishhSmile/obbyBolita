using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 1.6f, 4); // Cambi� el orden de los valores
    public float velocidadSeguimiento = 5f;
    public float velocidadRotacion = 2f;

    void Update()
    {
        // Seguir al jugador
        if (jugador != null)
        {
            // Calcular la posici�n deseada de la c�mara
            Vector3 nuevaPosicion = jugador.position - jugador.forward * offset.z + jugador.up * offset.y + jugador.right * offset.x;

            // Suavizar el movimiento de la c�mara hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidadSeguimiento * Time.deltaTime);
        }

        // Rotar la c�mara con el mouse
        float rotacionMouseX = Input.GetAxis("Mouse X") * velocidadRotacion;
        Quaternion rotacionDeseada = Quaternion.Euler(0, rotacionMouseX, 0);
        jugador.Rotate(Vector3.up, rotacionMouseX);

        // Mantener la c�mara mirando al jugador
        transform.LookAt(jugador.position + jugador.up * offset.y, jugador.up);
    }
}

