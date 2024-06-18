using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/EventoTP")]

public class EventoTP : Evento
{
    [SerializeField] float time;
    [SerializeField] Vector3 Posicion;
    public override void ElEvento(GameObject x, UnityEvent action)
    {
        ActivarEvento(x, action);
    }
    IEnumerator ActivarEvento(GameObject x, UnityEvent action)
    {
        yield return new WaitForSeconds(time);
        x.transform.position = Posicion;
        action?.Invoke();
    }
}