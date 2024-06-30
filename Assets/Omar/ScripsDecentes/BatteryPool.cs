using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPool : MonoBehaviour
{
    public GameObject batteryPrefab;
    public int poolSize = 5;
    public float respawnTime = 10f;
    public Transform[] spawnPoints; // Arreglos de puntos de referencia para las baterias
    private List<GameObject> batteries;

    void Start()
    {
        batteries = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject battery = Instantiate(batteryPrefab);
            battery.SetActive(false);
            batteries.Add(battery);
        }

        PlaceBatteriesRandomly();
    }

    public GameObject GetBattery()
    {
        foreach (GameObject battery in batteries)
        {
            if (!battery.activeInHierarchy)
            {
                return battery;
            }
        }

        return null;
    }

    private void PlaceBatteriesRandomly()
    {
        foreach (GameObject battery in batteries)
        {
            Transform randomSpawnPoint = GetRandomSpawnPoint();
            battery.transform.position = randomSpawnPoint.position;
            battery.SetActive(true);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        while (IsSpawnPointOccupied(spawnPoint))
        {
            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
        return spawnPoint;
    }

    private bool IsSpawnPointOccupied(Transform spawnPoint)
    {
        foreach (GameObject battery in batteries)
        {
            if (battery.activeInHierarchy && battery.transform.position == spawnPoint.position)
            {
                return true;
            }
        }
        return false;
    }

    public void ReactivateBattery(GameObject battery)
    {
        StartCoroutine(ReactivateBatteryAfterTime(battery));
    }

    private IEnumerator ReactivateBatteryAfterTime(GameObject battery)
    {
        yield return new WaitForSeconds(respawnTime);
        Transform randomSpawnPoint = GetRandomSpawnPoint();
        battery.transform.position = randomSpawnPoint.position;
        battery.SetActive(true);
    }
    /*public GameObject batteryPrefab;
    public int poolSize = 5;
    public float respawnTime = 10f;
    private List<GameObject> batteries;

    void Start()
    {
        batteries = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject battery = Instantiate(batteryPrefab);
            battery.SetActive(false);
            batteries.Add(battery);
        }

        PlaceBatteriesRandomly();
    }

    public GameObject GetBattery()
    {
        foreach (GameObject battery in batteries)
        {
            if (!battery.activeInHierarchy)
            {
                return battery;
            }
        }

        return null;
    }

    private void PlaceBatteriesRandomly()
    {
        foreach (GameObject battery in batteries)
        {
            Vector3 randomPosition = GetRandomPosition();
            battery.transform.position = randomPosition;
            battery.SetActive(true);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = 1f; 
        float z = Random.Range(-10f, 10f);

        return new Vector3(x, y, z);
    }

    public void ReactivateBattery(GameObject battery)
    {
        StartCoroutine(ReactivateBatteryAfterTime(battery));
    }

    private IEnumerator ReactivateBatteryAfterTime(GameObject battery)
    {
        yield return new WaitForSeconds(respawnTime);
        battery.transform.position = GetRandomPosition();
        battery.SetActive(true);
    }*/
}
