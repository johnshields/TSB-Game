using System.Collections;
using Effects;
using UnityEngine;

namespace Ryder
{
    public class BulletScript : MonoBehaviour
    {   public float cutTime;
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(BulletChangeScene());
        }

        private IEnumerator BulletChangeScene()
        {
            yield return new WaitForSeconds(cutTime);
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}
