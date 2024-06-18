using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/ActivarEvento")]

public class EventoActivarEvento : Evento
{
    [SerializeField] float time;
    public override void ElEvento(GameObject x, Action action)
    {
        ActivarEvento(action);
    }

    IEnumerator ActivarEvento(Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}
