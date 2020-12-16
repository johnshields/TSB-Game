using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private int _isWalkingHash;
    private int _isRunningHash;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    private void Update()
    {

        bool runActive = _animator.GetBool(_isRunningHash);
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // Idle to Walk
        if (forwardPressed)
        {
            _animator.SetBool(_isWalkingHash, true);
        }
        
        if (isWalking && !forwardPressed)
        {
            _animator.SetBool(_isWalkingHash, false);
        }
        
        // Walk to Run
        if (!runActive && (forwardPressed && runPressed))
        {
            _animator.SetBool(_isRunningHash, true);
        }
        
        if (runActive && (!forwardPressed || !runPressed))
        {
            _animator.SetBool(_isRunningHash, false);
        }
    }
}
