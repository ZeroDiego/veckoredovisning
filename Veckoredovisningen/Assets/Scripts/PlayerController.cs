using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    public float movespeed = 5;
    public PlayerControlInput input;
    private InputAction move;
    private InputAction interact;
    private SwitchTrigger switchTrigger;
    private SwitchController switchController;

    Vector2 moveDirection = Vector2.zero;

	private void Awake()
	{
		input = new PlayerControlInput();
        switchTrigger = GameObject.Find("Switch").GetComponent<SwitchTrigger>();
        switchController = GameObject.Find("Switch").GetComponent<SwitchController>();
    }

	private void OnEnable()
	{
        move = input.Player.Move;
        move.Enable();

        interact = input.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
	}

    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

	private void FixedUpdate()
	{
		rb2D.velocity = new Vector2 (moveDirection.x * movespeed, moveDirection.y * movespeed);
	}

    private void Interact(InputAction.CallbackContext context)
    {
        if (switchTrigger.isTriggered)
        {
            switchController.FlipTheColors();
            Debug.Log("Interact");
        }
    }
}
