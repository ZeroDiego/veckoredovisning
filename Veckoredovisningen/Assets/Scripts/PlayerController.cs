using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace EventCallbacks
{
    public class PlayerController : MonoBehaviour
    {
        public float movespeed = 5;
        public PlayerControlInput input;

        private Rigidbody2D rb2D;
        private InputAction move;
        private InputAction interact;
        private InputAction reset;
        private SwitchTrigger switchTrigger;
        public AudioClip interactSound;
        public AudioClip victorySound;
        private VictoryController victoryController;
        public Canvas victoryCanvas;

        Vector2 moveDirection = Vector2.zero;

        private void Awake()
        {
            input = new PlayerControlInput();
            switchTrigger = GameObject.Find("Switch").GetComponent<SwitchTrigger>();
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("White"), LayerMask.NameToLayer("Black"));
            victoryController = FindObjectOfType<VictoryController>();
        }

        private void OnEnable()
        {
            move = input.Player.Move;
            move.Enable();

            interact = input.Player.Interact;
            interact.Enable();
            interact.performed += Interact;

            reset = input.Player.Reset;
            reset.Enable();
            reset.performed += ResetScene;
        }

        private void OnDisable()
        {
            move.Disable();
            interact.Disable();
            reset.Disable();
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

            if (victoryController.isTriggered)
            {
                SoundEvent soundEvent = new SoundEvent(victorySound);
                EventHandler.Current.FireEvent(soundEvent);
                Debug.Log("Victory");
                gameObject.SetActive(false);
                victoryCanvas.gameObject.SetActive(true);
            }

        }

		private void ResetScene(InputAction.CallbackContext context)
		{
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
	}
}
