using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace EventCallbacks
{
    public class PlayerController : MonoBehaviour
    {
        public float movespeed = 5;
        public PlayerControlInput input;
        public SmoothCameraTransistion camera;
        public SwitchTrigger[] switchTriggers;
        public AudioClip interactSound;
        public AudioClip deathSound;


        private Rigidbody2D rb2D;
        private InputAction move;
        private InputAction interact;
        private InputAction reset;
        private VictoryController victoryController;
        private Vector2 moveDirection = Vector2.zero;
        private GameObject child;
        private Transform startPosition;

        private void Awake()
        {
            startPosition = GameObject.Find("StartPosition").transform;
            startPosition.parent = null;
            child = GameObject.Find("PlayerChild");
            input = new PlayerControlInput();
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
            foreach (SwitchTrigger switchTrigger in switchTriggers)
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

        private void ResetScene(InputAction.CallbackContext context)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("White") || collision.gameObject.layer == child.layer)
            {
                SoundEvent soundEvent = new SoundEvent(deathSound);
                EventHandler.Current.FireEvent(soundEvent);
                transform.position = startPosition.position;
                StartCoroutine(camera.TeleportCamera());
            }
        }
    }
}
