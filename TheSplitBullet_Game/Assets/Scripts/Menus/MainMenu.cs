
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            // Start the game
            SceneManager.LoadScene("PartOnePB");

            // console output
            Debug.Log("Gameplay Started");
        }
        
        public void ExitGame()
        {
            // exit the game
            Application.Quit();
            Debug.Log("Closing the Game");
        }
    }
}
