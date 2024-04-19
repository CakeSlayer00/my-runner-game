using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private AnimationCurve _xAnimation;

    private Rigidbody _rigidbody;

    private const float AnimationDurtaion = 1f;
    private const float OffsetX = 3.5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _movementSpeed));

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(SwitchSide(transform, _xAnimation, Side.Right));
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(SwitchSide(transform, _xAnimation, Side.Left));
        }

        if (transform.position.y < -5) transform.position = Vector3.zero;
    }

    public IEnumerator SwitchSide(Transform obj, AnimationCurve curve, Side side)
    {
        var expiredTime = 0f;
        var startPosition = obj.position;

        while (expiredTime < 1)
        {
            expiredTime += Time.deltaTime;
            var progress = expiredTime / AnimationDurtaion;
            obj.position = startPosition + new Vector3(curve.Evaluate(progress) * OffsetX * (int)side, 0, 0);

            yield return null;
        }
    }
}
