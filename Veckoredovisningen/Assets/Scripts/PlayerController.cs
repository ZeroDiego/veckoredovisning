using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventCallbacks
{
    public class PlayerController : MonoBehaviour
    {
        public float movespeed = 5;
        public PlayerControlInput input;

        private Rigidbody2D rb2D;
        private InputAction move;
        private InputAction interact;
        private SwitchTrigger switchTrigger;
        public AudioClip interactSound;

        Vector2 moveDirection = Vector2.zero;

<<<<<<< Updated upstream
	private void Awake()
	{
		input = new PlayerControlInput();
        switchTrigger = GameObject.Find("Switch").GetComponent<SwitchTrigger>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("White"), LayerMask.NameToLayer("Black"));
    }
=======
        private void Awake()
        {
            input = new PlayerControlInput();
            switchTrigger = GameObject.Find("Switch").GetComponent<SwitchTrigger>();
        }
>>>>>>> Stashed changes

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

        void Update()
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("White"), LayerMask.NameToLayer("Black"));
            moveDirection = move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            rb2D.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
        }

        private void Interact(InputAction.CallbackContext context)
        {
            if (switchTrigger.isTriggered)
            {
                SoundEvent soundEvent = new SoundEvent(interactSound);
                EventHandler.Current.FireEvent(soundEvent);
                switchTrigger.switchController.FlipTheColor();
                Debug.Log("Interact");
            }
        }
    }
}
