using System;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private PlayerMovement _playerMovement;
    
    private void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Mathf.Round(_playerMovement.transform.position.z) % 50 == 0)
        {
            road.transform.position = new Vector3(0, 0, _playerMovement.transform.position.z);
        }
    }
}
