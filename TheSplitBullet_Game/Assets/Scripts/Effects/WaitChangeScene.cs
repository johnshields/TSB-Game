using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Effects
{
    public class WaitChangeScene : MonoBehaviour
    {
        public float waitTime;
        // Start is called before the first frame update
        public void Start()
        {
            StartCoroutine(WaitCut());
        }

        private IEnumerator WaitCut()
        {
            yield return new WaitForSeconds(waitTime);
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}
