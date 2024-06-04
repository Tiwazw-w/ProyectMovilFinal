using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("NombreDeTuEscenaDeConfiguracion");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("NombreDeTuEscenaDeCreditos");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado");
    }
}
