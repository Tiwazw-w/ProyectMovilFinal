using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/ActivarEvento")]

public class EventoActivarEvento : Evento
{
    [SerializeField] float time;
    public override void ElEvento(GameObject x, UnityEvent action)
    {
        ActivarEvento(action);
    }

    IEnumerator ActivarEvento(UnityEvent action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}
