using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private AnimationCurve _xAnimation;

    private Rigidbody _rigidbody;
    private SideSwitchController _switchController;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
        _switchController = GameObject.Find(nameof(SideSwitchController)).GetComponent<SideSwitchController>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _movementSpeed));
        
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(_switchController.SwitchSide(transform, _xAnimation , Side.Right));
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(_switchController.SwitchSide(transform, _xAnimation , Side.Left));
        }

        if (transform.position.y < -5) { transform.position = Vector3.zero; }
    }
}
