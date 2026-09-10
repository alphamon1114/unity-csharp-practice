using UnityEngine;
using UnityEngine.InputSystem;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 1일차 [2.7 2장 종합 예제 - 플레이어 구현]
    //   2.7.1 플레이어 게임 오브젝트
    //   2.7.2 플레이어의 이동 구현      ← 여기
    //   2.7.3 플레이어의 "공격" 구현    ← 이 게임에서는 손전등 비추기
    //   2.7.4 Unity 6 Input System
    //
    // 인스펙터에서 키를 설정할 필요가 없도록 바인딩을 코드로 만들어 두었습니다.
    // Input System이 어떻게 생겼는지 눈으로 익히세요.
    // ─────────────────────────────────────────────────────────────

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Flashlight flashlight;
        [SerializeField] private float interactRadius = 1.2f;

        private Rigidbody2D rb;
        private Vector2 moveInput;

        // ── [2.7.4 인풋 시스템] 액션 3개 ──────────────────────
        private InputAction moveAction;
        private InputAction sprintAction;
        private InputAction interactAction;
        private InputAction flashAction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (stats == null) stats = GetComponent<PlayerStats>();
            if (flashlight == null) flashlight = GetComponentInChildren<Flashlight>();

            // WASD와 방향키를 하나의 Vector2로 묶습니다.
            moveAction = new InputAction("Move", InputActionType.Value, expectedControlType: "Vector2");
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
                .With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow").With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow").With("Right", "<Keyboard>/rightArrow");

            sprintAction   = new InputAction("Sprint",   InputActionType.Button, "<Keyboard>/leftShift");
            interactAction = new InputAction("Interact", InputActionType.Button, "<Keyboard>/e");
            flashAction    = new InputAction("Flash",    InputActionType.Button, "<Keyboard>/space");
        }

        private void OnEnable()
        {
            moveAction.Enable();
            sprintAction.Enable();
            interactAction.Enable();
            flashAction.Enable();

            interactAction.performed += OnInteract;
            flashAction.performed += OnFlash;
        }

        private void OnDisable()
        {
            interactAction.performed -= OnInteract;
            flashAction.performed -= OnFlash;

            moveAction.Disable();
            sprintAction.Disable();
            interactAction.Disable();
            flashAction.Disable();
        }

        private void Update()
        {
            // TODO [2.7.2 플레이어의 이동] 입력을 읽어 moveInput에 넣으세요.
            // 힌트: moveInput = moveAction.ReadValue<Vector2>();

            if (stats != null && flashlight != null)
            {
                // 손전등이 꺼져 있거나 배터리가 없으면 어둠 속에 있는 것으로 칩니다.
                stats.TickFear(!flashlight.IsLit, Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (stats != null && !stats.IsAlive)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            bool sprinting = sprintAction.IsPressed();
            float speed = stats != null ? stats.GetMoveSpeed(sprinting) : 4f;

            // TODO [2.7.2 플레이어의 이동] 실제로 움직이세요.
            // 힌트: rb.linearVelocity = moveInput.normalized * speed;
            //   normalized를 쓰는 이유: 대각선으로 갈 때 √2배 빨라지는 걸 막습니다.

            // TODO [2.7.2] 이동 방향으로 몸을 돌리세요. (손전등이 향할 방향)
            // 힌트: moveInput이 0이 아닐 때만
            //   float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            //   rb.MoveRotation(angle - 90f);
        }

        // ── [2.7.3 "공격"] 손전등 비추기 ──────────────────────
        private void OnFlash(InputAction.CallbackContext ctx)
        {
            // TODO [2.7.3] flashlight.Flash() 를 호출하세요.
            //   교재의 "미사일 발사" 자리입니다. 앞쪽 몬스터를 잠깐 밀어냅니다.
        }

        // ── 상호작용 (3일차 인터페이스에서 진짜로 동작합니다) ──
        private void OnInteract(InputAction.CallbackContext ctx)
        {
            // TODO [4.2 인터페이스] — 3일차
            //   주변을 원으로 훑어서 IInteractable을 가진 것을 찾아 Interact(this)를 부르세요.
            //
            // 힌트:
            //   Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRadius);
            //   foreach (var h in hits)
            //   {
            //       if (h.TryGetComponent<IInteractable>(out var target))
            //       {
            //           target.Interact(this);
            //           break;
            //       }
            //   }
            Debug.Log("[Player] 상호작용 시도 — 아직 구현되지 않았습니다. (4.2 인터페이스)");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactRadius);
        }
    }
}
