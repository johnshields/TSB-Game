using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapters
{
    public class ChapterScreen : MonoBehaviour
    {
        private static int _nextSceneToLoad;

        // Start is called before the first frame update
        private void Start()
        {
            _nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

            Debug.Log("Chapter Started");
            StartCoroutine(NextScene());
        }

        private static IEnumerator NextScene()
        {
            yield return new WaitForSeconds(6);
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(_nextSceneToLoad);
        }
    }
}
