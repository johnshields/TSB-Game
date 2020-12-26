using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;

namespace Change_Scene
{
    public class WaitChangeScene : MonoBehaviour
    {
        public static float waitTime;
        // Start is called before the first frame update
        public void Start()
        {
            StartCoroutine(WaitCut());
        }

        private static IEnumerator WaitCut()
        {
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(waitTime);
            SceneChanger.NextScene();
        }
    }
}
