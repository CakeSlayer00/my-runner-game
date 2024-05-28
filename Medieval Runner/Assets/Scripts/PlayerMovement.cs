using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _moveUnit;
    [SerializeField] private AnimationCurve _jumpAnimation; 
    [SerializeField] private float _jumpHeight = 3;
    
    private const float JumpDuration = 1.1f;
    
    private float _currentLane;
    private float _targetLane;
    
    public bool IsRunning { get; private set; }
    public bool IsOnJump { get; private set; }

    private void Start()
    {
        IsRunning = true;
    }

    private void Update()
    {
        if (!IsRunning) return;

        OnSwipe();
    }

    private IEnumerator Jump()
    {
        IsOnJump = true;

        var t = 0f;
        while (t < 1)
        {
            transform.position = new Vector3(0, _jumpAnimation.Evaluate(t / JumpDuration), 0) * _jumpHeight;
            t += Time.deltaTime;
            yield return null;
        }

        IsOnJump = false;
    }

    private void OnSwipe()
    {
        var t = 0f;
        t += Time.deltaTime;
        transform.position = Vector3.MoveTowards(
            transform.position,
            Vector3.right * (_moveUnit * _targetLane), t / 0.1f);

        _currentLane = _targetLane;
    }

    public void SwipeLane(Lane dir)
    {
        if (_currentLane + (float)dir is < -1 or > 1) return;

        _targetLane = _currentLane + (float)dir;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            IsRunning = false;
        }
    }
}