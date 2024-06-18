using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciador : MonoBehaviour
{
    public SOSceneControler ElControlador;
    private void Awake()
    {
        ElControlador.CargarEscena(0);
    }
}
