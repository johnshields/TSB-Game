using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine.Audio;
using UnityEngine;

namespace Effects
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] gameAudio;

        private void Awake()
        {
            foreach (var ts in gameAudio)
            {
                ts.trackSource = gameObject.AddComponent<AudioSource>();
                
                ts.trackSource.clip = ts.trackClip;
                ts.trackSource.volume = ts.volume;
                ts.trackSource.pitch = ts.pitch;
                ts.trackSource.loop = ts.loop; 
            }
        }

        private void Start()
        {
            PlayAudio("gold");
            PlayAudio("engine");
        }
        
        private void PlayAudio (string name)
        {
            var ts = Array.Find(gameAudio, sound => sound.trackName == name);
            ts?.trackSource.Play();
        }
        
    }
}
