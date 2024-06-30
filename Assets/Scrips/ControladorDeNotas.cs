using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ControladorDeNotas : MonoBehaviour
{
    [SerializeField] int CantidadMaxPistas;
    [SerializeField] int CantidadPistasObtenidas;
    [SerializeField] TMP_Text Texto;
    [SerializeField] UnityEvent ElEvento;

    public void SeObtuvoUnaPista()
    {
        CantidadPistasObtenidas += 1;
        Texto.text = CantidadPistasObtenidas + "/" + CantidadMaxPistas;
        if(CantidadPistasObtenidas == CantidadMaxPistas)
        {
            ElEvento.Invoke();
        }
    }
}
