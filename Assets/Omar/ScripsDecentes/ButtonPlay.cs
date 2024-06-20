using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{

    public string gameSceneName = "GmePru";


    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
