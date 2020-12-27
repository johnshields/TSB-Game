using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        private bool _paused;
        
        // Start is called before the first frame update
        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (_paused)
            {
                ResumeGame();
                AudioListener.volume = 1f;
            }
            else
            {
                PauseGame();
                AudioListener.volume = 0f;
            }

        }

        private void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.volume = 0f; // pause audio
            _paused = true; // game is paused
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _paused = false;
            AudioListener.volume = 1f;
        }
        
        public void BackMainMenu()
        {
            // to the main menu
            StartCoroutine(FadeOutMainMenu());           
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
            Debug.Log("Load Main Menu");
        }
        
        public void ExitGame()
        {
            // exit the game
            StartCoroutine(FadeOutExit());
            Debug.Log("Closing the Game");
        }
        
        private static IEnumerator FadeOutMainMenu()
        {
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainMenuBox");
        }

        private static IEnumerator FadeOutExit()
        {
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            Application.Quit();
        }
    }
}
