using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private float _swipeUnit;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private AnimationCurve _jumpAnimation;
    
    private const float JumpBorderY = 2f;
    
    public bool isGrounded = true;

    private float _targetLane;
    private float _currentLane;
    private float _expiredSecondsForJump;

    private void Update()
    {
        OnSwipe();
        OnJump();
    }

    private void OnJump()
    {
        if (!isGrounded && _expiredSecondsForJump < 1)
        {
            _expiredSecondsForJump += Time.deltaTime;
            transform.position = new Vector3(transform.position.x,
                _jumpAnimation.Evaluate(_expiredSecondsForJump / _jumpDuration) * JumpBorderY, transform.position.z);
            return;
        }

        isGrounded = true;
        _expiredSecondsForJump = 0;
    }

    private void OnSwipe()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(_swipeUnit * _targetLane, transform.position.y, transform.position.z),
            _swipeSpeed * Time.deltaTime);

        _currentLane = _targetLane;
    }

    public void SwipeLane(Lane dir)
    {
        if (_currentLane + (float)dir is < -1 or > 1) return;

        _targetLane = _currentLane + (float)dir;
    }

    public void Jump()
    {
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }

        isGrounded = true;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
    }
}