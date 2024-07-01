using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueFinal : MonoBehaviour
{
    [SerializeField] Timer ElTimer;
    [SerializeField] EnemigoScreamer EnemigoScreamer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jugador")
        {
            if (ElTimer.TiempoFinal)
            {
                EnemigoScreamer.Perdio = true;
            }
        }
    }
}
