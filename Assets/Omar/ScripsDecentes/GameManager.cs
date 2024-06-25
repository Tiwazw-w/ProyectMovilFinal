using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int notesCollected = 0;
    public Text notesCollectedText; // Asignar esto en el inspector de Unity
    public Vector3[] notePositions; // Posiciones de las notas a asignar en el Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnNotes();
    }

    private void SpawnNotes()
    {
        foreach (Vector3 position in notePositions)
        {
            // Instancia el prefab de la nota en cada posición especificada
            GameObject notePrefab = Resources.Load<GameObject>("Prefabs/Note"); // Asegúrate de tener el prefab en una carpeta Resources
            Instantiate(notePrefab, position, Quaternion.identity);
        }
    }

    public void NoteCollected(Vector3 notePosition)
    {
        notesCollected++;
        Debug.Log("Notas recogidas: " + notesCollected);
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (notesCollectedText != null)
        {
            notesCollectedText.text = "Notas recogidas: " + notesCollected;
        }
    }
}
