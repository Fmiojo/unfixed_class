using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
   [SerializeField]
   Slider slider;
   void Awake()
   {
       //slider = gameObject.GetComponent<Slider>();
   }
   void OnEnable()
   {

   }
   public void SetMasterVolume()
   {
       AudioManager.instance.SetMaster(slider.value);
   }
   public void SetSFXVolume()
   {
       AudioManager.instance.SetSFX(slider.value);
   }
    public void SetMusicVolume()
    {
        AudioManager.instance.SetMusic(slider.value);
    }
}
