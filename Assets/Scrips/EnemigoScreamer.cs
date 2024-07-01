using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScreamer : MonoBehaviour
{
    [SerializeField] Timer ElTimer;
    [SerializeField] GameObject LaNiña;
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
            LaNiña.transform.position = ElJugador.transform.position + ElJugador.transform.forward * 5;
            LaNiña.SetActive(true);
            yield return new WaitForSeconds(2);
            LaNiña.SetActive(false);
            int x = Random.RandomRange(17, 21);
            yield return new WaitForSeconds(x);
            if(ElTimer.TiempoFinal)
                yield return null;

        }
    }


}
