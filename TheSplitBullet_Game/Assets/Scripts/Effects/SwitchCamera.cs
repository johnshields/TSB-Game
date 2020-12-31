using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class SwitchCamera : MonoBehaviour
    {
        public GameObject camOne;
        public GameObject camTwo;
        public GameObject camThree;
        public float cameraSwitchTime;
        
        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(SwitchCameras());
        }

        private IEnumerator SwitchCameras()
        {
            yield return new WaitForSeconds(cameraSwitchTime);
            camTwo.SetActive(true);
            camOne.SetActive(false);
            yield return new WaitForSeconds(cameraSwitchTime);
            camThree.SetActive(true);
            camTwo.SetActive(false);
            
        }
    }
}
