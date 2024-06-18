using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "EventoMove", menuName = "ScriptableObject/Eventos/Sonido")]


public class EventoSonido : Evento
{
    [SerializeField] AudioSourcePoolling ElGeneradorDeAudios;
    [SerializeField] AudioClip ElClip;
    [SerializeField] AudioMixerGroup nuevoGrupo;
    [SerializeField] Vector2 Posicion;
    [SerializeField] bool EsLoop;
    [SerializeField] float time;
    // Start is called before the first frame update
    public override void ElEvento(GameObject x, Action action)
    {
        ActivarEvento();
    }
    IEnumerator ActivarEvento()
    {
        yield return new WaitForSeconds(time);
        ElGeneradorDeAudios.ActivarSonido(ElClip, nuevoGrupo, Posicion, EsLoop);
    }
}
