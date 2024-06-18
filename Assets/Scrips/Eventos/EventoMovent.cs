using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/EventoMovimiento")]

public class EventoMovent : Evento
{
    [SerializeField] Vector3 Posicion;
    [SerializeField] float time;
    [SerializeField] Ease EltipoDeMovimiento;
    public override void ElEvento(GameObject x, Action action)
    {
        x.transform.DOMove(Posicion, time).SetEase(EltipoDeMovimiento).OnComplete(() => action?.Invoke());
    }
}
