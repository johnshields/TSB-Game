using System;
using System.Collections;
using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        private static int _nextSceneToLoad;
        private static Animator _animator;
        private static int _fadeOutHash;
        
        private void Start()
        {
            _nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            _fadeOutHash = Animator.StringToHash("FadeOut");
            _animator = GetComponent<Animator>();
        }

        public void StartGame()
        {
            // Start the game
            StartCoroutine(NextScene());

            // console output
            Debug.Log("Gameplay Started");
        }
        
        public void ExitGame()
        {
            // exit the game
            Application.Quit();
            Debug.Log("Closing the Game");
        }

        private static IEnumerator NextScene()
        {
            _animator.SetTrigger(_fadeOutHash);
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(_nextSceneToLoad);
        }
    }
}
