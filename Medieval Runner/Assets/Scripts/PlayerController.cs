using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private AnimationCurve _xAnimation;

    private bool _isOnLeftEdge;
    private bool _isOnRightEdge;

    private const float AnimationDuration = 1f;
    private const float HorizontalBound = 3.5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _movementSpeed));

        if (Mathf.Abs(transform.position.x) - HorizontalBound != 0f && transform.position.x != 0f) return;

        UpdatePlayerStateOfCurrentSide();

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !_isOnRightEdge)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchSide(transform, Side.Right));
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !_isOnLeftEdge)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchSide(transform, Side.Left));
        }
    }

    private void UpdatePlayerStateOfCurrentSide()
    {
        if (Math.Abs(transform.position.x - HorizontalBound) < 0.001f)
        {
            _isOnRightEdge = true;
            _isOnLeftEdge = false;
        }

        if (Math.Abs(transform.position.x - (-HorizontalBound)) < 0.001f)
        {
            _isOnRightEdge = false;
            _isOnLeftEdge = true;
        }

        if (transform.position.x == 0)
        {
            _isOnRightEdge = false;
            _isOnLeftEdge = false;
        }
    }

    private IEnumerator SwitchSide(Transform obj, Side side)
    {
        var expiredTime = 0f;
        var startPosition = obj.position;

        while (expiredTime < 1)
        {
            expiredTime += Time.deltaTime;
            var progress = expiredTime / AnimationDuration;
            obj.position = startPosition + new Vector3(_xAnimation.Evaluate(progress) * HorizontalBound * (int)side, 0, 0);

            yield return null;
        }
    }
}
