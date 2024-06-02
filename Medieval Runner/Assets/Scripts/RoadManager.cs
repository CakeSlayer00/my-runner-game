using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private float _speed = 15;

    private void Update()
    {
        if (transform.position.z < -50f) transform.position = Vector3.zero;
        transform.Translate(Vector3.back * (_speed * Time.deltaTime));
    }
}