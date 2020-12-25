using UnityEngine;
using UnityEngine.SceneManagement;

namespace Effects 
{
    public class SceneChanger : MonoBehaviour
    {
        private static Animator _animator;
        private static int _fadeOutHash;

        private void Start()
        {
            _fadeOutHash = Animator.StringToHash("FadeOut");
            _animator = GetComponent<Animator>();
        }

        public static void FadeToScene()
        {
            _animator.SetTrigger(_fadeOutHash);
        }
    }
}
