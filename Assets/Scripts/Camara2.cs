using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(2, 1.7f, -2);
    public float velocidadSeguimiento = 5f;
    public float velocidadRotacion = 2f;

    void Start()
    {
        // Establecer la posici�n y rotaci�n inicial de la c�mara
        transform.position = jugador.position + offset;
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcular la posici�n deseada de la c�mara
            Vector3 nuevaPosicion = jugador.position - jugador.forward * offset.z + jugador.up * offset.y + jugador.right * offset.x;

            // Suavizar el movimiento de la c�mara hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidadSeguimiento * Time.deltaTime);
        }

        // Rotar la c�mara con el mouse
        float rotacionMouseX = Input.GetAxis("Mouse X") * velocidadRotacion;
        jugador.Rotate(Vector3.up, rotacionMouseX);

        // Mantener la c�mara mirando al jugador
        transform.LookAt(jugador.position + jugador.up * offset.y - jugador.forward * 2 * offset.z, jugador.up);
    }
}
