using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;

    // Direcciones de movimiento
    private Vector3 forwardDirection;
    private Vector3 backwardDirection;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Configurar direcciones de movimiento
        forwardDirection = transform.forward;
        backwardDirection = -transform.forward;
    }

    void Update()
    {
        // Obtener las entradas de teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento
        Vector3 movimiento = (forwardDirection * movimientoVertical + transform.right * movimientoHorizontal).normalized * velocidadMovimiento * Time.deltaTime;

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
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
}
