using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int Min = 3;
    int segundos = 0;
    float tiempo = 0;
    [SerializeField] TMP_Text TiempoText;
    [SerializeField] GameObject ElJugador;
    [SerializeField] List<EventoSonido> ListaDeSonidos;
    [SerializeField] List<Vector3> ListaDePosicion;
    public bool TiempoFinal;
    public bool yaHayUnSonido;

    private void Update()
    {
        tiempo += Time.deltaTime;
        if (!yaHayUnSonido)
        {
            yaHayUnSonido = true;
            StartCoroutine(ActivarSonidoDeFondo());

        }
        if (tiempo > 1)
        {
            tiempo = 0;
            if (Min == 0 && segundos == 0)
            {
                TiempoFinal = true;
            }
            else if (segundos == 0 && Min != 0)
            {
                Min -= 1;
                segundos = 59;
            }
            else
            {
                segundos -= 1;
            }

            TiempoText.text = segundos >= 10 ? Min + ":" + segundos : Min + ":0" + segundos;
        }
    }


    IEnumerator ActivarSonidoDeFondo()
    {
        int x = Random.Range(0, ListaDeSonidos.Count);
        int y = Random.Range(15, 25);

        yield return new WaitForSeconds(y);
        ListaDeSonidos[x].Posicion = ListaDePosicion[x] + ElJugador.transform.position;
        ListaDeSonidos[x].ElEvento(null, null);
        yaHayUnSonido = false;

    }
}
