using UnityEngine;
using UnityEngine.SceneManagement;

namespace Effects
{
    public class SceneChanger : MonoBehaviour
    {
        private static Animator _animator;
        private static int _fadeOutHash;
        private static int _nextSceneToLoad;

        private void Start()
        {
            _fadeOutHash = Animator.StringToHash("FadeOut");
            _animator = GetComponent<Animator>();
            _nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

        public static void FadeToScene()
        {
            _animator.SetTrigger(_fadeOutHash);
        }

        public static void NextScene ()
        {
            SceneManager.LoadScene(_nextSceneToLoad);
        }
    }
}
