using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    private float _offsetByZ = -9.6f;
    private float _offsetByY = 5.5f;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x, _offsetByY, _player.position.z + _offsetByZ);
    }
}
