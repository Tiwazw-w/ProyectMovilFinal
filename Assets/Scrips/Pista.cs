using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ListaDeEventosGuardados
{
    public Evento evento;
    public GameObject ElObjeto;
    public UnityEvent Action;
}

public class Pista : MonoBehaviour
{
    public List<ListaDeEventosGuardados> ElEvento;
}
