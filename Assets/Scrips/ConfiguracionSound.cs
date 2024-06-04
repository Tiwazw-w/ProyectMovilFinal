using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfiguracionSound : MonoBehaviour
{
    [SerializeField] AudioMixer ElAudioMixer;

    [SerializeField] Slider SliderMaster;
    [SerializeField] Slider SliderMusica;
    [SerializeField] Slider SliderEfectosDeSonido;
    void Start()
    {
        // Inicializa el slider con el valor del AudioMixer
        //master
        inicioSlider(SliderMaster, "Master");

        //Music
        inicioSlider(SliderMusica, "Music");

        //Efectos
        inicioSlider(SliderEfectosDeSonido, "EfectosDeSonido");


        // Añadir el listener para que el slider controle el volumen
        //SliderMaster.onValueChanged.AddListener(delegate { SetVolume(SliderMaster.value, ""); });

    }
    public void inicioSlider(Slider elSlider, string ElGrupo)
    {
        float volume;
        ElAudioMixer.GetFloat(ElGrupo, out volume);
        elSlider.value = Mathf.Pow(10, volume / 20); // Convertir dB a una escala lineal (0.0 a 1.0)
        elSlider.onValueChanged.AddListener(delegate { SetVolume(elSlider.value, ElGrupo); });
        print("El Slider: " + elSlider.value + "   ElVolumen: " + volume + "    Grupo: " + ElGrupo);
    }

    public void SetVolume(float sliderValue, string Grupo)
    {
        if (sliderValue < 0.0001f)
        {
            sliderValue = 0.0001f; // Evita el valor 0
        }
        float volume = Mathf.Log10(sliderValue) * 20; // Convertir escala lineal a dB
        ElAudioMixer.SetFloat(Grupo, volume);
        print("El Slider: " + sliderValue + "   ElVolumen: " + volume);
    }
}
