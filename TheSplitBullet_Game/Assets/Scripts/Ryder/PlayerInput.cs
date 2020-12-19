using UnityEngine;

namespace Ryder
{
    [RequireComponent(typeof(RyderController))]
    public class PlayerInput : MonoBehaviour
    {
        private RyderController _ryder;
        
        // Start is called before the first frame update
        void Start()
        {
            _ryder = GetComponent<RyderController>();
        }

        // Update is called once per frame
        void Update()
        {
            _ryder.ActionInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
