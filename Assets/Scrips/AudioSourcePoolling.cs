using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourcePoolling : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject PrefabAudioSource;

    [SerializeField] float fadeDuration;

    List<AudioSource> ListaDeAudios = new List<AudioSource>();

    int CantidadDeAudiosActivos;
    #endregion



    #region desactivarSonidos
    public void DescactivarTodo()
    {
        for (int i = 0; i < ListaDeAudios.Count; i++)
        {
            //StartCoroutine(FadeOutCoroutine(ListaDeAudios[i]));
            AudioSource audioSource = ListaDeAudios[i];
            ListaDeAudios[i].DOFade(0, fadeDuration).SetEase(Ease.Linear).OnComplete(() => FadeOutDoTween(audioSource));
        }
    }

    public void DescactivarTodo(AudioMixerGroup nuevoGrupo)
    {
        for (int i = 0; i < ListaDeAudios.Count; i++)
        {
            if (ListaDeAudios[i].outputAudioMixerGroup == nuevoGrupo)
            {
                //StartCoroutine(FadeOutCoroutine(ListaDeAudios[i]));
                AudioSource audioSource = ListaDeAudios[i];
                ListaDeAudios[i].DOFade(0, fadeDuration).SetEase(Ease.Linear).OnComplete(() => FadeOutDoTween(audioSource));
            }
        }
    }

    public void DescactivarTodo(AudioMixerGroup[] nuevoGrupo)
    {
        for (int i = 0; i < ListaDeAudios.Count; i++)
        {
            for (int j = 0; j < nuevoGrupo.Length; j++)
            {
                if (ListaDeAudios[i].outputAudioMixerGroup == nuevoGrupo[j])
                {
                    //StartCoroutine(FadeOutCoroutine(ListaDeAudios[i]));
                    AudioSource audioSource = ListaDeAudios[i];
                    ListaDeAudios[i].DOFade(0, fadeDuration).SetEase(Ease.Linear).OnComplete(() => FadeOutDoTween(audioSource));
                }
            }

        }
    }

    IEnumerator FadeOutCoroutine(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        // Gradualmente reduce el volumen del AudioSource hasta llegar a 0
        float timer = 0.0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, timer / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Restaura el volumen original
        CantidadDeAudiosActivos += 1;
    }
    void FadeOutDoTween(AudioSource audioSource)
    {
        print("seParo");
        audioSource.Stop();
        audioSource.volume = 1;
        CantidadDeAudiosActivos += 1;
    }
    #endregion





    #region ActivarSonido
    public void ActivarSonido(AudioClip ElClip, AudioMixerGroup nuevoGrupo, bool EsLoop)
    {
        if (CantidadDeAudiosActivos > 0)
        {
            for (int i = 0; i < ListaDeAudios.Count; i++)
            {
                if (!ListaDeAudios[i].isPlaying)
                {
                    CantidadDeAudiosActivos -= 1;
                    ListaDeAudios[i].clip = ElClip;
                    ListaDeAudios[i].loop = EsLoop;
                    ListaDeAudios[i].outputAudioMixerGroup = nuevoGrupo;
                    ListaDeAudios[i].Play();
                    StartCoroutine(DesactivarObjeto(ListaDeAudios[i].clip.length));
                    return;
                }

            }
        }
        else
        {
            GameObject ElReproductor = Instantiate(PrefabAudioSource);
            ListaDeAudios.Add(ElReproductor.GetComponent<AudioSource>());
            ListaDeAudios[ListaDeAudios.Count - 1].clip = ElClip;
            ListaDeAudios[ListaDeAudios.Count - 1].loop = EsLoop;
            ListaDeAudios[ListaDeAudios.Count - 1].outputAudioMixerGroup = nuevoGrupo;
            ListaDeAudios[ListaDeAudios.Count - 1].Play();
            StartCoroutine(DesactivarObjeto(ListaDeAudios[ListaDeAudios.Count - 1].clip.length));
        }
    }
    public void ActivarSonido(AudioClip ElClip, AudioMixerGroup nuevoGrupo, Transform Objeto, bool EsLoop)
    {
        if (CantidadDeAudiosActivos > 0)
        {
            for (int i = 0; i < ListaDeAudios.Count; i++)
            {
                if (!ListaDeAudios[i].isPlaying)
                {
                    CantidadDeAudiosActivos -= 1;
                    ListaDeAudios[i].gameObject.transform.parent = Objeto;
                    ListaDeAudios[i].gameObject.transform.position = Objeto.position;
                    ListaDeAudios[i].clip = ElClip;
                    ListaDeAudios[i].loop = EsLoop;
                    ListaDeAudios[i].outputAudioMixerGroup = nuevoGrupo;
                    ListaDeAudios[i].Play();
                    StartCoroutine(DesactivarObjeto(ListaDeAudios[i].clip.length));
                    return;
                }

            }
        }
        else
        {
            GameObject ElReproductor = Instantiate(PrefabAudioSource);
            ListaDeAudios.Add(ElReproductor.GetComponent<AudioSource>());
            ListaDeAudios[ListaDeAudios.Count - 1].gameObject.transform.parent = Objeto;
            ListaDeAudios[ListaDeAudios.Count - 1].gameObject.transform.position = Objeto.position;
            ListaDeAudios[ListaDeAudios.Count - 1].clip = ElClip;
            ListaDeAudios[ListaDeAudios.Count - 1].loop = EsLoop;
            ListaDeAudios[ListaDeAudios.Count - 1].outputAudioMixerGroup = nuevoGrupo;
            ListaDeAudios[ListaDeAudios.Count - 1].Play();
            StartCoroutine(DesactivarObjeto(ListaDeAudios[ListaDeAudios.Count - 1].clip.length));
        }
    }
    public void ActivarSonido(AudioClip ElClip, AudioMixerGroup nuevoGrupo, Vector2 posicion, bool EsLoop)
    {
        if (CantidadDeAudiosActivos > 0)
        {
            for (int i = 0; i < ListaDeAudios.Count; i++)
            {
                if (!ListaDeAudios[i].isPlaying)
                {
                    CantidadDeAudiosActivos -= 1;
                    ListaDeAudios[i].gameObject.transform.parent = null;
                    ListaDeAudios[i].gameObject.transform.position = posicion;
                    ListaDeAudios[i].clip = ElClip;
                    ListaDeAudios[i].loop = EsLoop;
                    ListaDeAudios[i].outputAudioMixerGroup = nuevoGrupo;
                    ListaDeAudios[i].Play();
                    StartCoroutine(DesactivarObjeto(ListaDeAudios[i].clip.length));
                    return;
                }

            }
        }
        else
        {
            GameObject ElReproductor = Instantiate(PrefabAudioSource);
            ListaDeAudios.Add(ElReproductor.GetComponent<AudioSource>());
            ListaDeAudios[ListaDeAudios.Count - 1].gameObject.transform.parent = null;
            ListaDeAudios[ListaDeAudios.Count - 1].gameObject.transform.position = posicion;
            ListaDeAudios[ListaDeAudios.Count - 1].clip = ElClip;
            ListaDeAudios[ListaDeAudios.Count - 1].loop = EsLoop;
            ListaDeAudios[ListaDeAudios.Count - 1].outputAudioMixerGroup = nuevoGrupo;
            ListaDeAudios[ListaDeAudios.Count - 1].Play();
            StartCoroutine(DesactivarObjeto(ListaDeAudios[ListaDeAudios.Count - 1].clip.length));
        }
    }

 
    private IEnumerator DesactivarObjeto(float ElClip)
    {
        yield return new WaitForSeconds(ElClip);
        CantidadDeAudiosActivos += 1;
    }
    #endregion

}
