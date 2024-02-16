using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private GameControls playerInput;

    [SerializeField] private float velocity;

    private Vector3 moveDirection;

    private void Awake()
    {
        playerInput = new GameControls();
        playerInput.Enable();
        SetUpInputs();
    }

    private void Update()
    {
        transform.Translate(moveDirection * velocity * Time.deltaTime);
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 inputDirection = context.ReadValue<Vector2>();

        moveDirection.x = inputDirection.x;
        moveDirection.y = 0f;
        moveDirection.z = inputDirection.y;
    }
    private void SetUpInputs()
    {
        playerInput.Player.Move.started += MovePlayer;
        playerInput.Player.Move.performed += MovePlayer;
        playerInput.Player.Move.canceled += MovePlayer;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.started -= MovePlayer;
        playerInput.Player.Move.performed -= MovePlayer;
        playerInput.Player.Move.canceled -= MovePlayer;
        playerInput.Disable();
    }

}
