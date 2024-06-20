using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


[CreateAssetMenu(fileName = "NuevoObjeto", menuName = "SO/Escenas/LaEscena")]
public class SOScene : ScriptableObject
{
    public SceneAsset Escena;
    public bool EstaActivo;
    public void CargarEscena()
    {
        Debug.Log("2");
        if (!EstaActivo)
        {
            SceneManager.LoadSceneAsync(Escena.name, LoadSceneMode.Additive);
            EstaActivo = true;
            Debug.Log("3");
        }
    }

    public void DescargarEscena()
    {
        if (EstaActivo)
        {
            SceneManager.UnloadSceneAsync(Escena.name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            EstaActivo = false;
        }
        // Descargar la escena por su nombre

    }

    private void OnDisable()
    {
        EstaActivo = false;
    }
}