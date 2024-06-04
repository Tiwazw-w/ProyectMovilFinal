using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListaDeEscenas
{
    public SOScene[] LasEscenas;
}

public class SceneControler : MonoBehaviour
{
    public ListaDeEscenas[] ListaDeListas;
    public ListaDeEscenas[] ListaDeListasSimple;
    
    public void CargarEscenaMapa(Vector2 NuevaEscena, Vector2 AntiguaEscena)
    {
        if (NuevaEscena.x != AntiguaEscena.x)
        {
            int Diferencia = (int)(AntiguaEscena.x - NuevaEscena.x);
            for (int i = -1; i <= 1; i++)
            {
                if (AntiguaEscena.y + i <= ListaDeListas.Length - 1 && 
                    AntiguaEscena.y + i >= 0 &&
                    AntiguaEscena.x + Diferencia <= ListaDeListas[(int)(AntiguaEscena.y + i)].LasEscenas.Length - 1 && 
                    AntiguaEscena.x + Diferencia >= 0)
                {
                    ListaDeListas[(int)(AntiguaEscena.y + i)].LasEscenas[(int)(AntiguaEscena.x + Diferencia)].DescargarEscena();
                    ListaDeListasSimple[(int)(AntiguaEscena.y + i)].LasEscenas[(int)(AntiguaEscena.x + Diferencia)].CargarEscena();
                    //mapa[PosicionJugadorY + i, PosicionJugadorX + Diferencia].LaCategoria = Categoria.vacio;
                }
                if(NuevaEscena.y + i <= ListaDeListas.Length - 1 && 
                   NuevaEscena.y + i >= 0 &&
                   NuevaEscena.x - Diferencia <= ListaDeListas[(int)(NuevaEscena.y + i)].LasEscenas.Length -1 &&
                   NuevaEscena.x - Diferencia >= 0)
                {
                    ListaDeListasSimple[(int)(NuevaEscena.y + i)].LasEscenas[(int)(NuevaEscena.x - Diferencia)].DescargarEscena();
                    ListaDeListas[(int)(NuevaEscena.y + i)].LasEscenas[(int)(NuevaEscena.x - Diferencia)].CargarEscena();
                }

            }

        }
        if (NuevaEscena.y != AntiguaEscena.y)
        {
            int Diferencia = (int)(AntiguaEscena.y - NuevaEscena.y);

            for (int i = -1; i <= 1; i++)
            {
                if(AntiguaEscena.x + i <= ListaDeListas[(int)(AntiguaEscena.y + Diferencia)].LasEscenas.Length - 1 &&
                   AntiguaEscena.x + i >= 0 &&
                   AntiguaEscena.y + Diferencia <= ListaDeListas.Length -1 &&
                   AntiguaEscena.y + Diferencia >= 0)
                {
                    ListaDeListas[(int)(AntiguaEscena.y + Diferencia)].LasEscenas[(int)(AntiguaEscena.x + i)].DescargarEscena();
                    ListaDeListasSimple[(int)(AntiguaEscena.y + Diferencia)].LasEscenas[(int)(AntiguaEscena.x + i)].CargarEscena();
                }
                if(NuevaEscena.x + i <= ListaDeListas[(int)(AntiguaEscena.y - Diferencia)].LasEscenas.Length - 1 &&
                   NuevaEscena.x + i >= 0 &&
                   NuevaEscena.y - Diferencia <= ListaDeListas.Length - 1 &&
                   NuevaEscena.y - Diferencia >= 0)
                {
                    ListaDeListasSimple[(int)(AntiguaEscena.y - Diferencia)].LasEscenas[(int)(AntiguaEscena.x + i)].DescargarEscena();
                    ListaDeListas[(int)(AntiguaEscena.y - Diferencia)].LasEscenas[(int)(AntiguaEscena.x + i)].CargarEscena();
                }
            }
        }
    }




}
