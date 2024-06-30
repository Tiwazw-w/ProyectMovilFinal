using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoMov : MonoBehaviour
{
    [SerializeField] GameObject ElJugador;
    [SerializeField] float velocidad;
    bool Persecucion;
    public void IniciarPersecucion()
    {
        Persecucion = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Persecucion)
        {
            Vector3 Direccion = (ElJugador.transform.position - transform.position).normalized;
            transform.position += Direccion * velocidad * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "jugador")
        {

        }
    }
}
