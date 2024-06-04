using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicionadorMapa : MonoBehaviour
{
    [SerializeField] Vector2 posicion;

    public Vector2 Posicion
    {
        get { return posicion; }
    }
}
