using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{
    [SerializeField] GameObject MovimientoPanel;
    [SerializeField] GameObject PosicionGuiaExterno;
    [SerializeField] GameObject PosicionGuiaCentral;
    [SerializeField] float Duracion;
    [SerializeField] SOSceneControler ElManagerDeEscenas;
    [SerializeField] SOScene EscenaDeSettings;
    [SerializeField] GameObject Buton;





    private void Awake()
    {
        MovimientoPanel.transform.position = PosicionGuiaExterno.transform.position;
        if(UI_pausa.instance != null)
        {
            if (UI_pausa.instance._EstaEnEljuego)
            {
                UI_pausa.instance.EstaEnEljuego();
                Buton.SetActive(true);
                //Time.timeScale = 0;
            }
        }
            
    }
    private void Start()
    {
        MovimientoPanel.transform.DOMove(PosicionGuiaCentral.transform.position, Duracion).SetEase(Ease.InOutBack);
    }

    public void CerrarSettings()
    {
        MovimientoPanel.transform.DOMove(PosicionGuiaExterno.transform.position, Duracion).SetEase(Ease.InOutBack).OnComplete(EliminarEscena);
    }
    public void VolverMenu()
    {
        MovimientoPanel.transform.DOMove(PosicionGuiaExterno.transform.position, Duracion).SetEase(Ease.InOutBack).OnComplete(EliminarEscena2);
    }
    void EliminarEscena()
    {
        UI_pausa.instance.ActivarObjetos();
        EscenaDeSettings.DescargarEscena();
    }
    void EliminarEscena2()
    {
        ElManagerDeEscenas.CargarEscena(0);
        ElManagerDeEscenas.DescargarEscena(3);
        EscenaDeSettings.DescargarEscena();
    }
}
