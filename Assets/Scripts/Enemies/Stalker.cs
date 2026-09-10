using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 2일차 [3.3 상속] [3.4 다형성] [3.5.4 적군의 종류 추가]
    //
    // 추격형. 한 번 보면 끝까지 따라옵니다. 대신 느립니다.
    // MonsterBase가 가진 것은 전부 물려받고, "어떻게 움직이는가"만 다시 씁니다.
    // ─────────────────────────────────────────────────────────────

    public class Stalker : MonsterBase
    {
        [Header("Stalker 고유")]
        [SerializeField] private float memoryDuration = 5f;   // 놓쳐도 쫓는 시간
        [SerializeField] private Vector2 lastKnownPosition;
        [SerializeField] private float memoryTimer;

        protected override void Awake()
        {
            base.Awake();   // 부모의 Awake를 먼저 실행하는 걸 잊지 마세요.

            // TODO [3.3 상속] Stalker는 느리지만 멀리서도 알아챕니다.
            //   moveSpeed를 1.4f, detectRange를 9f로 바꾸세요.
            //   (protected 필드라 자식에서 접근할 수 있습니다 — 3.2 캡슐화)
        }

        // [3.4 다형성] 같은 Behave() 호출인데 Stalker는 이렇게 움직입니다.
        protected override void Behave()
        {
            if (state == MonsterState.Chase)
            {
                // TODO [3.4 다형성] 플레이어 위치를 기억하고 그쪽으로 이동하세요.
                // 힌트:
                //   lastKnownPosition = player.position;
                //   memoryTimer = memoryDuration;
                //   MoveTowards(lastKnownPosition);
                return;
            }

            // TODO [2.6 제어문] 놓친 뒤에도 memoryTimer 동안은 마지막 위치로 계속 갑니다.
            // 힌트:
            //   if (memoryTimer > 0f)
            //   {
            //       memoryTimer -= Time.deltaTime;
            //       MoveTowards(lastKnownPosition);
            //   }
            //   else rb.linearVelocity = Vector2.zero;
        }

        // [3.5.5 메서드 오버라이드] 부모와 다르게 반응합니다.
        public override void Stun(float duration)
        {
            // TODO [3.5.5 오버라이드] Stalker는 빛에 강해서 스턴이 절반만 걸립니다.
            // 힌트: base.Stun(duration * 0.5f);
            base.Stun(duration);
        }
    }
}
