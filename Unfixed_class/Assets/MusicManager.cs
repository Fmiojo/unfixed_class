using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   public  static MusicManager instance;
   AudioSource source;

   void Awake()
   {
       instance = this;
       source = gameObject.GetComponent<AudioSource>();
   }
   public void Play()
   {
       source.Play();
   }
   public void Stop()
   {
       source.Stop();
   }
   public void Pause()
   {
       source.Pause();
   }
}
