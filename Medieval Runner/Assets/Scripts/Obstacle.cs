
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.back * (20 * Time.deltaTime));
    }
}
