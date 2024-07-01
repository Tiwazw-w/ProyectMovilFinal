using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScreamer : MonoBehaviour
{
    [SerializeField] Timer ElTimer;
    [SerializeField] GameObject LaNiña;
    [SerializeField] GameObject ElJugador;
    [SerializeField] GameObject ImagenFinal;
    [SerializeField] EventoSonido Reproductor;
    [SerializeField] EventoSonidoHijo SonidoDelMinuto;
    [SerializeField] SOSceneControler ControladorDeEscenas;

    bool SeAcabo;
    public bool Perdio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ElTimer.Min <= 1 && !SeAcabo)
        {
            SonidoDelMinuto.Posicion = ElJugador.transform;
            SonidoDelMinuto.ElEvento(null, null);
            SeAcabo = true;
            StartCoroutine(activar());

        }

        if (Perdio)
        {
            ImagenFinal.SetActive(true);
            Perdio = false;
            StartCoroutine(PerdioMetodo());
            
        }
    }

    IEnumerator activar()
    {
        while(true)
        {
            LaNiña.transform.position = ElJugador.transform.position + ElJugador.transform.forward * 5;
            LaNiña.transform.rotation = Quaternion.LookRotation(LaNiña.transform.position - ElJugador.transform.position);
            //LaNiña.transform.rotation = new Quaternion(0, LaNiña.transform.rotation.y, 0, LaNiña.transform.rotation.w);

            Reproductor.Posicion = LaNiña.transform.position;
            Reproductor.ElEvento(null, null);
            LaNiña.SetActive(true);
            yield return new WaitForSeconds(3);
            LaNiña.SetActive(false);
            int x = Random.RandomRange(15, 21);
            yield return new WaitForSeconds(x);
            if(ElTimer.TiempoFinal)
                yield return null;

        }
    }
    IEnumerator PerdioMetodo()
    {
        yield return new WaitForSeconds(5);
        ControladorDeEscenas.CargaryDescargarEscena(0, 3);

    }

}
