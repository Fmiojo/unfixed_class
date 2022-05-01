using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    public AudioMixer mixer;    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadVolumes();
    }
    public void LoadVolumes()
    {
        
    }
    public void SetMaster(float vol)
    {
        mixer.SetFloat("Master",Mathf.Log10(vol) * 20);
    }
    public void SetSFX(float vol)
    {
        mixer.SetFloat("SFX",Mathf.Log10(vol) * 20);
    }
    public void SetMusic(float vol)
    {
        mixer.SetFloat("MUSIC",Mathf.Log10(vol) * 20);
    }
    public void SetUI(float vol)
    {
        mixer.SetFloat("UI",Mathf.Log10(vol) * 20);
    }
}
