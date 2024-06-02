using UnityEngine;

public class CharacterKeyboardInput : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Start()
    {
        _movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _movement.SwipeLane(Lane.Left);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movement.SwipeLane(Lane.Right);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _movement.isGrounded)
        {
            _movement.Jump();
        }
    }
}
