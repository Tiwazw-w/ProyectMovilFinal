using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float rotationSpeed;
    Vector3 Direccion;
    Vector3 DireccionFinal;
    Vector2 currentRotation; // Almacenar la rotación actual

    [SerializeField] Joystick JoystickMovimiento;
    [SerializeField] Joystick JoystickRotacion;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotar();
    }


    public void Movimiento()
    {
        Direccion = new Vector2
        {
            x = JoystickMovimiento.Horizontal + Input.GetAxis("Horizontal"),
            y = JoystickMovimiento.Vertical + Input.GetAxis("Vertical")
        };

        // Calcula el vector resultado combinando la dirección hacia adelante con la dirección de entrada
        DireccionFinal = transform.forward * Direccion.y + transform.right * Direccion.x;
        DireccionFinal.y = 0;
        DireccionFinal = DireccionFinal.normalized;
        transform.position += DireccionFinal * velocidad * Time.deltaTime;
    }


    public void Rotar()
    {
        Vector2 mouseDelta = new Vector2
        {
            x = JoystickRotacion.Horizontal,
            y = JoystickRotacion.Vertical
        };

        // Calcular la nueva rotación
        currentRotation.x -= mouseDelta.y * rotationSpeed * Time.deltaTime; // Invertir el valor para la rotación en el eje X
        currentRotation.y += mouseDelta.x * rotationSpeed * Time.deltaTime;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -40, 40);

        // Aplicar la rotación al objeto
        transform.rotation = rotacion.CalcularRotacion(currentRotation);
        DireccionFinal = transform.forward * Direccion.y + transform.right * Direccion.x;
        //DireccionFinal.y = 0;
        //DireccionFinal = DireccionFinal.normalized;
    }

}