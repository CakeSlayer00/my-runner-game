using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private PlayerMovement _playerMovement;
    private float _speed = 15;

    private void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(_playerMovement.IsRunning)
            transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        
        if (Mathf.Approximately(Mathf.Round(_playerMovement.transform.position.z) / 50, -1))
        {
            road.transform.position = new Vector3(0, 0, 0);
        }
    }
}
