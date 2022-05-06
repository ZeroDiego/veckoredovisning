using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float movespeed = 5;
    public PlayerControlInput input;
    private InputAction move;
    private InputAction interact;

    Vector2 moveDirection = Vector2.zero;

	private void Awake()
	{
		input = new PlayerControlInput();
	}

	private void OnEnable()
	{
        move = input.Player.Move;
        move.Enable();

        interact = input.Player.Interact;
        interact.Enable();
	}

    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

	private void FixedUpdate()
	{
		rb.velocity = new Vector2 (moveDirection.x * movespeed, moveDirection.y * movespeed);
	}

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}
