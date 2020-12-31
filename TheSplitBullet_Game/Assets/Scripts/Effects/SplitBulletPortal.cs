using System.Collections;
using UnityEngine;

namespace Effects
{
    public class SplitBulletPortal : MonoBehaviour
    {
        [SerializeField] public AudioClip portalSound;
        [SerializeField] public float cutTime;
        [SerializeField] public Camera portalCamera;
        [SerializeField] public GameObject ryder;
        private void OnTriggerEnter(Collider other)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(PortalAbsorb());
        }

        private IEnumerator PortalAbsorb()
        {
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(portalSound, portalCamera.transform.position);
            Destroy(ryder);
            Time.timeScale = 1f;
            yield return new WaitForSeconds(cutTime);
            FadeMusic.FadeOutMusic();
            SceneChanger.FadeToScene();
            yield return new WaitForSeconds(1);
            SceneChanger.NextScene();
        }
    }
}