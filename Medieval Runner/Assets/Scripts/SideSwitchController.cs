using System.Collections;
using UnityEngine;

public class SideSwitchController : MonoBehaviour
{
    private const float AnimationDurtaion = 1f;
    private const float OffsetX = 3.5f;

    public IEnumerator SwitchSide(Transform obj, AnimationCurve curve , Side side)
    {
        var expiredTime = 0f;

        while (expiredTime < AnimationDurtaion)
        {
            var currPositionByY = obj.position.y;
            var currPositionByZ = obj.position.z;

            expiredTime += Time.deltaTime;

            var progress = expiredTime / AnimationDurtaion;

            obj.position = new Vector3(
                curve.Evaluate(progress) * OffsetX * (int)side, 
                currPositionByY, 
                currPositionByZ);

            yield return null;
        }

    }
}