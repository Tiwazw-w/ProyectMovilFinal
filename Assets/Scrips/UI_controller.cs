using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_controller : MonoBehaviour
{
    [SerializeField] GameObject MovimientoPanel;
    [SerializeField] GameObject PosicionGuiaExterno;
    [SerializeField] GameObject PosicionGuiaCentral;
    [SerializeField] float Duracion;
    [SerializeField] SOSceneControler ElManagerDeEscenas;
    [SerializeField] SOScene EscenaDeSettings;





    private void Awake()
    {
        MovimientoPanel.transform.position = PosicionGuiaExterno.transform.position;
    }
    private void Start()
    {
        MovimientoPanel.transform.DOMove(PosicionGuiaCentral.transform.position, Duracion).SetEase(Ease.InOutBack);
    }

    public void CerrarSettings()
    {
        MovimientoPanel.transform.DOMove(PosicionGuiaExterno.transform.position, Duracion).SetEase(Ease.InOutBack).OnComplete(EliminarEscena);
    }

    void EliminarEscena()
    {
        UI_pausa.instance.ActivarObjetos();
        EscenaDeSettings.DescargarEscena();
    }
}
