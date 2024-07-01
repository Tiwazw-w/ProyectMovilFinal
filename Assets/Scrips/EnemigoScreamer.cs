using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScreamer : MonoBehaviour
{
    [SerializeField] Timer ElTimer;
    [SerializeField] GameObject LaNi�a;
    [SerializeField] GameObject ElJugador;

    bool SeAcabo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ElTimer.Min <= 1 && !SeAcabo)
        {
            SeAcabo = true;
            StartCoroutine(activar());
        }
    }

    IEnumerator activar()
    {
        while(true)
        {
            LaNi�a.transform.position = ElJugador.transform.position + ElJugador.transform.forward * 5;
            LaNi�a.SetActive(true);
            yield return new WaitForSeconds(2);
            LaNi�a.SetActive(false);
            int x = Random.RandomRange(17, 21);
            yield return new WaitForSeconds(x);
            if(ElTimer.TiempoFinal)
                yield return null;

        }
    }


}
