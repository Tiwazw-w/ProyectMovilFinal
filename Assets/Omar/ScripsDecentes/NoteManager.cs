using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NoteManager : MonoBehaviour
{
    public List<Transform> spawnPoints;

    void Start()
    {
        SpawnNotes();
    }

    void SpawnNotes()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            ObjectPooling.Instance.SpawnFromPool("Note", spawnPoint.position, spawnPoint.rotation);
        }
    }
}

