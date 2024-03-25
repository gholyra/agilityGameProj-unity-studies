using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;
    
    [SerializeField] private float velocity = 6f;

    private Vector3 moveDirection;
    private GameControls playerInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        playerInput = new GameControls();
        playerInput.Enable();
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
    
    private void RestartGame(InputAction.CallbackContext context)
    {
        SceneManager.Instance.RestartGameScene();
    }
    
    public void DisableInput()
    {
        playerInput.Player.Move.Disable();
    }

    private void OnEnable()
    {
        playerInput.Player.Move.started += MovePlayer;
        playerInput.Player.Move.performed += MovePlayer;
        playerInput.Player.Move.canceled += MovePlayer;
        
        playerInput.Player.RestartGame.performed += RestartGame;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.started -= MovePlayer;
        playerInput.Player.Move.performed -= MovePlayer;
        playerInput.Player.Move.canceled -= MovePlayer;
        DisableInput();
    }

}
