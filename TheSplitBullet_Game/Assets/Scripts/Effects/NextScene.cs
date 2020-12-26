using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class NextScene : MonoBehaviour
    {
        public void SkipCutScene()
        {
            StartCoroutine(SkipScene());
        }

        private static IEnumerator SkipScene()
        {
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}

