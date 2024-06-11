using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicinadorPrueba : MonoBehaviour
{
    public SceneControler ElControlador;
    Vector2 PosActual = new Vector2(3, 3);


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ColicionadorMapa>())
        {
            Vector2 pos = other.GetComponent<ColicionadorMapa>().Posicion;
            if (pos != PosActual)
            {
                ElControlador.CargarEscenaMapa(pos, PosActual);
                PosActual = pos;
            }
        }
    }
}
