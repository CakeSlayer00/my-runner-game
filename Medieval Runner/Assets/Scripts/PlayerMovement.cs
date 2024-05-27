using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private const float MoveUnit = 3f;
    private const float AnimationDuration = 0.2f;

    public bool isCoroutineRunning;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
    }

    public IEnumerator SwitchSide(Side side)
    {
        isCoroutineRunning = true;
        Vector3 currPosition = transform.position;
        Vector3? targetPosition = GetTargetPosition(side);
        if (targetPosition.Equals(Vector3.zero))
        {
            isCoroutineRunning = false;
            yield break;
        }
        
        float t = 0;
        while (t < 1)
        {
            if (targetPosition != null)
            {
                transform.position = Vector3.Lerp(currPosition, targetPosition.Value, t);
                t += Time.deltaTime / AnimationDuration;
            }
            yield return null;
        }

        transform.position = targetPosition.Value;
        isCoroutineRunning = false;
    }

    private Vector3? GetTargetPosition(Side side)
    {
        var currPosition = new Vector3(Mathf.Round(transform.position.x) , transform.position.y , transform.position.z);

        Vector3? targetPosition = side switch
        {
            Side.Left => currPosition.x is >= 0 and <= 3
                ? new Vector3(currPosition.x - MoveUnit, currPosition.y, currPosition.z)
                : Vector3.zero,
            Side.Right => currPosition.x is >= -3 and <= 0
                ? new Vector3(currPosition.x + MoveUnit, currPosition.y, currPosition.z)
                : Vector3.zero,
            _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
        };

        return targetPosition;
    }
}

public enum Side
{
    Left, Right
}