using System;
using System.Collections;
using Effects;
using UnityEngine;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            AudioListener.volume = 1f;        
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
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}
