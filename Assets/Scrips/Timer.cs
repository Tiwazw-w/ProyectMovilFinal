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
    public bool TiempoFinal;

    private void Update()
    {
        tiempo += Time.deltaTime;
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
            TiempoText.text = Min + ":" + segundos;
        }
    }
}
