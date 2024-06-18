using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/SonidoHijo")]

public class EventoSonidoHijo : Evento
{
    [SerializeField] AudioSourcePoolling ElGeneradorDeAudios;
    [SerializeField] AudioClip ElClip;
    [SerializeField] AudioMixerGroup nuevoGrupo;
    [SerializeField] Transform Posicion;
    [SerializeField] bool EsLoop;
    [SerializeField] float time;
    // Start is called before the first frame update
    public override void ElEvento(GameObject x, UnityEvent action)
    {
        ActivarEvento();
    }
    IEnumerator ActivarEvento()
    {
        yield return new WaitForSeconds(time);
        ElGeneradorDeAudios.ActivarSonido(ElClip, nuevoGrupo, Posicion, EsLoop);
    }
}