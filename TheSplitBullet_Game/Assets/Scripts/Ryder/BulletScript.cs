using System.Collections;
using Effects;
using UnityEngine;

namespace Ryder
{
    public class BulletScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(BulletChangeScene());
        }

        private static IEnumerator BulletChangeScene()
        {
            yield return new WaitForSeconds(10);
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}
