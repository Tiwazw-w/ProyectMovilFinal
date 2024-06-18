using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicionadorPistas : MonoBehaviour
{
    List<ListaDeEventosGuardados> ListaDeEventos;

    public void ActivarEvento()
    {
        for(int i = 0; i < ListaDeEventos.Count; i++)
        {
            ListaDeEventos[i].evento.ElEvento(ListaDeEventos[i].ElObjeto, ListaDeEventos[i].Action);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pista>())
        {
            ListaDeEventos = other.GetComponent<Pista>().ElEvento;
            ActivarEvento();
            Destroy(other.gameObject);
        }
    }
}
