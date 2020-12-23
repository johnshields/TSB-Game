
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] AudioClip clickSound;
        public void StartGame()
        {

            // Start the game
            SceneManager.LoadScene("PrologueBox");

            // console output
            Debug.Log("Gameplay Started");
            
            AudioSource.PlayClipAtPoint(clickSound, Camera.current.transform.position);
            DontDestroyOnLoad(clickSound);
        }
        
        public void ExitGame()
        {
            // exit the game
            Application.Quit();
            Debug.Log("Closing the Game");
        }
    }
}
