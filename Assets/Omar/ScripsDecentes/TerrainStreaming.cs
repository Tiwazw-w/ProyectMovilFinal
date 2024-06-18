using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainStreaming : MonoBehaviour
{
    public Transform player;
    public float loadDistance = 100f; // Distancia en la que los sectores se cargarán
    public float unloadDistance = 120f; // Distancia en la que los sectores se descargarán
    public List<GameObject> sectors; // Lista de sectores
    private Dictionary<GameObject, bool> sectorStates; // Estado de los sectores (cargados o no)

    void Start()
    {
        sectorStates = new Dictionary<GameObject, bool>();
        foreach (GameObject sector in sectors)
        {
            sectorStates.Add(sector, false);
            sector.SetActive(false);
        }
    }

    void Update()
    {
        foreach (GameObject sector in sectors)
        {
            float distance = Vector3.Distance(player.position, sector.transform.position);
            if (distance < loadDistance && !sectorStates[sector])
            {
                sector.SetActive(true);
                sectorStates[sector] = true;
            }
            else if (distance > unloadDistance && sectorStates[sector])
            {
                sector.SetActive(false);
                sectorStates[sector] = false;
            }
        }
    }
}

