using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light flashlight;
    public Button flashlightButton;
    private bool isFlashlightOn = false;

    [Header("Energia")]

    public float energia_Actual = 100f;
    public float energia_Maxima = 100f;
    public float ConsumodeEnergia = 0.5f;

    [Header("Interfaz")]

    public Image BarradeVida;

    void Start()
    {

        flashlight.enabled = false;
        flashlightButton.onClick.AddListener(ToggleFlashlight);
        
    }
    private void Update()
    {
        NivelEnergia();
    }

    void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
    }

    void NivelEnergia()
    {
        if(flashlight.enabled == true)
        {
            energia_Actual -= Time.deltaTime * ConsumodeEnergia;

            if(energia_Actual <= 0)
            {
                energia_Actual = 0;
                flashlight.enabled = false;
            }
        }

        BarradeVida.fillAmount = energia_Actual / energia_Maxima;
    }
}

