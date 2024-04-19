using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    private GameObject _road;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _road = GameObject.Find("Road");
    }

    private void Update()
    {
        var playerPositionByZ = _player.transform.position.z;

        if (Mathf.Round(playerPositionByZ) % 50 == 0)
        {
            _road.transform.position = new Vector3(0f, 0f, playerPositionByZ);
        }
    }
}
