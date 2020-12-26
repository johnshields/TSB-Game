using UnityEngine;

namespace Effects
{
    public class FadeMusic : MonoBehaviour
    {

        private static Animator _animator;

        private static int _fadeOutHash;

        // Start is called before the first frame update
        private void Start()
        {
            _fadeOutHash = Animator.StringToHash("FadeOut");
            _animator = GetComponent<Animator>();
        }
        
        public static void FadeOutMusic()
        {
            _animator.SetTrigger(_fadeOutHash);
        }
    }
}
