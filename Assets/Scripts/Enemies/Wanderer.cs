using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 2일차 [3.3 상속] [3.4 다형성] [3.5.4 적군의 종류 추가]
    // 1일차 [2.4 배열] — 순찰 지점을 배열로 관리합니다.
    //
    // 배회형. 정해진 지점을 돌다가 플레이어를 보면 빠르게 달려듭니다.
    // ─────────────────────────────────────────────────────────────

    public class Wanderer : MonsterBase
    {
        [Header("Wanderer 고유")]
        // [2.4 배열] 순찰 지점들. 인스펙터에서 빈 오브젝트를 끌어다 넣으세요.
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private float arriveThreshold = 0.3f;
        [SerializeField] private int currentIndex = 0;

        protected override void Awake()
        {
            base.Awake();

            // TODO [3.3 상속] Wanderer는 빠르지만 시야가 좁습니다.
            //   moveSpeed = 3.2f;  detectRange = 4f;
        }

        protected override void Behave()
        {
            if (state == MonsterState.Chase)
            {
                // TODO [3.4 다형성] 플레이어에게 곧장 달려듭니다.
                // 힌트: MoveTowards(player.position);
                return;
            }

            Patrol();
        }

        private void Patrol()
        {
            // TODO [2.4 배열] + [2.6 제어문] 순찰을 구현하세요.
            //
            //   1) patrolPoints가 비어 있으면(null이거나 Length == 0) 멈추고 끝냅니다.
            //   2) patrolPoints[currentIndex] 로 이동합니다.
            //   3) 그 지점에 arriveThreshold보다 가까워지면 다음 인덱스로 넘어갑니다.
            //   4) 마지막 지점 다음은 다시 0번으로 돌아갑니다.
            //
            // 힌트: 4)번은 나머지 연산자 한 번이면 됩니다.
            //   currentIndex = (currentIndex + 1) % patrolPoints.Length;

            rb.linearVelocity = Vector2.zero;
        }

        private void OnDrawGizmos()
        {
            if (patrolPoints == null) return;

            Gizmos.color = Color.cyan;
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (patrolPoints[i] == null) continue;
                Gizmos.DrawWireCube(patrolPoints[i].position, Vector3.one * 0.3f);

                Transform next = patrolPoints[(i + 1) % patrolPoints.Length];
                if (next != null) Gizmos.DrawLine(patrolPoints[i].position, next.position);
            }
        }
    }
}
