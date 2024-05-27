using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !_playerMovement.isCoroutineRunning)
        {
            StopAllCoroutines();
            StartCoroutine(_playerMovement.SwitchSide(Side.Right));
        }

        if (Input.GetKeyDown(KeyCode.A) && !_playerMovement.isCoroutineRunning)
        {
            StopAllCoroutines();
            StartCoroutine(_playerMovement.SwitchSide(Side.Left));
        }
    }
}