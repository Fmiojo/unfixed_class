using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   public  static MusicManager instance;
   AudioSource source;
   [SerializeField]
   AudioClip [] musics;

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
   public void Pregame()
   {
       source.clip = musics[0];
       Play();
   }
   public void Game()
   {
       source.clip = musics[1];
       Play();
   }
   public void EndGame()
   {
       source.clip = musics[2];
       Play();
   }
}
