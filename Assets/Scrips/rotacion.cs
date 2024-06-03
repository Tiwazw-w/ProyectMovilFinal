using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    [SerializeField] private Quaternion qx = Quaternion.identity; //(0,0,0,1)
    [SerializeField] private Quaternion qy = Quaternion.identity; //(0,0,0,1)
    [SerializeField] private Quaternion qz = Quaternion.identity; //(0,0,0,1)


    [SerializeField] private Quaternion r = Quaternion.identity; //(0,0,0,1)
    private float anguloSen;
    private float anguloCos;


    // Start is called before the first frame update
    void Start()
    {

    }

    public static Quaternion CalcularRotacion(Vector3 angulos)
    {
        Quaternion qz = Quaternion.Euler(0, 0, angulos.z);
        Quaternion qx = Quaternion.Euler(angulos.x, 0, 0);
        Quaternion qy = Quaternion.Euler(0, angulos.y, 0);

        Quaternion r = qy * qx * qz;

        return r;
    }
}