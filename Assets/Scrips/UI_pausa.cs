using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class UI_pausa : MonoBehaviour
{
    public static UI_pausa instance;

    [SerializeField] List<Button> ListaDeObjetosUIButon = new List<Button>();
    [SerializeField] List<Image> ListaDeObjetosUIImage = new List<Image>();
    [SerializeField] List<TMP_Text> ListaDeObjetosUITextMeshPro = new List<TMP_Text>();

    [SerializeField] float Duracion;
    public SOSceneControler ControladorDeEscenas;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Si ya hay una instancia y no es esta, destruye la instancia anterior
            Destroy(instance.gameObject);
        }

        // Asigna esta instancia a la variable estática
        instance = this;

    }

    public void DesactivarObjetos(int EscenaQueActivara)
    {
        for(int i = 0; i < ListaDeObjetosUIButon.Count; i++)
        {
            ListaDeObjetosUIButon[i].interactable = false;
            /*
            else if (ListaDeObjetosUIInteractuables[i].GetComponent<Button>())
            {

            }
            */
        }


        for(int i = 0; i < ListaDeObjetosUIImage.Count; i++)
        {
            if (i == 0)
            {
                ListaDeObjetosUIImage[i].DOFade(0, Duracion).OnComplete(() => ControladorDeEscenas.CargarEscena(EscenaQueActivara));
            }
            else
            {
                ListaDeObjetosUIImage[i].DOFade(0, Duracion);
            }
        }

        for (int i = 0; i < ListaDeObjetosUITextMeshPro.Count; i++)
        {
            if (i == 0)
            {
                ListaDeObjetosUITextMeshPro[i].DOFade(0, Duracion).OnComplete(() => ControladorDeEscenas.CargarEscena(EscenaQueActivara));
            }
            else
            {
                ListaDeObjetosUITextMeshPro[i].DOFade(0, Duracion);
            }
        }


    }





    public void ActivarObjetos()
    {
        for (int i = 0; i < ListaDeObjetosUIButon.Count; i++)
        {
            ListaDeObjetosUIButon[i].interactable = true;
            /*
            else if (ListaDeObjetosUIInteractuables[i].GetComponent<Button>())
            {

            }
            */
        }

        for (int i = 0; i < ListaDeObjetosUIImage.Count; i++)
        {
            if (i == 0)
            {
                ListaDeObjetosUIImage[i].DOFade(1, Duracion);
            }
            else
            {
                ListaDeObjetosUIImage[i].DOFade(1, Duracion);
            }
        }

        for (int i = 0; i < ListaDeObjetosUITextMeshPro.Count; i++)
        {
            if (i == 0)
            {
                ListaDeObjetosUITextMeshPro[i].DOFade(1, Duracion);
            }
            else
            {
                ListaDeObjetosUITextMeshPro[i].DOFade(1, Duracion);
            }
        }



    }


}
