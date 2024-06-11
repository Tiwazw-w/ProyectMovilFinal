using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciadorDelMapa : MonoBehaviour
{
    [SerializeField] SceneControler ElControlador;
    private void Awake()
    {
        for(int i = 0; i<8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(Math.Abs(i-3)<=1 && Mathf.Abs(j - 3) <= 1)
                {
                    ElControlador.ListaDeListas[i].LasEscenas[j].CargarEscena();
                }
                else
                {
                    ElControlador.ListaDeListasSimple[i].LasEscenas[j].CargarEscena();
                }
            }
        }
    }
}
