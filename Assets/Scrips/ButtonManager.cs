using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public SOSceneControler ElControlador;

    public void activarEscena(int i, int j)
    {
        ElControlador.CargaryDescargarEscena(i, j);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado");
    }
}
