using UnityEngine;

namespace Effects
{
    [System.Serializable]
    public class Sound
    {
        [SerializeField] public AudioClip trackClip;
        [SerializeField] public string trackName;
        [SerializeField] public bool loop;
        [Range(0f, 1f)] public float volume;
        [Range(0.1f, 3f)] public float pitch;
        
        [HideInInspector] public AudioSource trackSource;
    }
}
