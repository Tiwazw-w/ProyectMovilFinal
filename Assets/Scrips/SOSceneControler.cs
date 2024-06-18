using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoObjeto", menuName = "SO/Escenas/ElControladorDeEscenas")]

public class SOSceneControler : ScriptableObject
{
    public List<SOScene> ListaDeEscenas;

    public void CargarEscena(int i)
    {
        ListaDeEscenas[i].CargarEscena();
    }

    public void CargaryDescargarEscena(int cargar, int descargar)
    {
        ListaDeEscenas[descargar].DescargarEscena();
        ListaDeEscenas[cargar].CargarEscena();
    }

    public void DescargarEscena(int i)
    {
        ListaDeEscenas[i].DescargarEscena();
    }

}
