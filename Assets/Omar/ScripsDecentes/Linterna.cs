using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light flashlight;  
    public Button flashlightButton;

    private bool isFlashlightOn = false;

    void Start()
    {

        flashlight.enabled = false;


        flashlightButton.onClick.AddListener(ToggleFlashlight);
    }

    void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
    }
}

