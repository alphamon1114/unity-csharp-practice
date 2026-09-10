using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 1일차 [2.2 변수와 자료형] · [2.3 형변환] · [2.5 연산자]
    // 2일차 [3.2 캡슐화]
    //
    // 플레이어의 "숫자"를 전부 여기에 모읍니다.
    // 다른 스크립트는 이 값을 직접 건드리지 못하고, 메서드를 통해서만 바꿉니다.
    // 그게 캡슐화입니다.
    // ─────────────────────────────────────────────────────────────

    public class PlayerStats : MonoBehaviour
    {
        // ── [2.2 변수와 자료형] ───────────────────────────────
        // 각 값에 어떤 자료형이 맞는지 생각하며 읽어 보세요.
        [Header("체력")]
        [SerializeField] private int maxHp = 100;
        [SerializeField] private int currentHp = 100;

        [Header("이동")]
        [SerializeField] private float moveSpeed = 4.0f;      // 초당 유닛
        [SerializeField] private float sprintMultiplier = 1.6f;

        [Header("공포")]
        [SerializeField] private float fear = 0f;             // 0 ~ 100
        [SerializeField] private float fearPerSecondInDark = 6f;

        [Header("상태")]
        [SerializeField] private bool isAlive = true;

        // ── [3.2 캡슐화] ─────────────────────────────────────
        // 읽기는 누구나, 쓰기는 이 클래스만. 그래서 get은 public, set은 private.
        public int CurrentHp => currentHp;
        public int MaxHp => maxHp;
        public bool IsAlive => isAlive;
        public float Fear => fear;

        /// <summary>0.0 ~ 1.0 사이의 체력 비율. UI 게이지에 씁니다.</summary>
        public float HpRatio
        {
            get
            {
                // TODO [2.3 형변환] currentHp / maxHp 는 int / int 라서 결과가 0 아니면 1입니다.
                //   float으로 형변환해서 0.0~1.0이 나오게 고치세요.
                // 힌트: (float)currentHp / maxHp
                return 1f;
            }
        }

        /// <summary>현재 이동 속도. 공포가 높으면 손이 떨려 조금 느려집니다.</summary>
        public float GetMoveSpeed(bool sprinting)
        {
            float speed = moveSpeed;

            // TODO [2.6 제어문] sprinting이 true면 speed에 sprintMultiplier를 곱하세요.

            // TODO [2.5 연산자] 공포가 70 이상이면 speed를 20% 줄이세요.
            // 힌트: speed *= 0.8f;

            return speed;
        }

        // ── 값을 바꾸는 유일한 통로 ───────────────────────────

        public void TakeDamage(int amount)
        {
            if (!isAlive) return;

            // TODO [2.5 연산자] currentHp에서 amount만큼 빼세요.
            // TODO [2.6 제어문] currentHp가 0보다 작아지면 0으로 고정하세요.
            // 힌트: Mathf.Max(0, currentHp - amount) 한 줄로도 됩니다.

            // 4일차에 이 줄의 주석을 풀면 UI가 자동으로 갱신됩니다. [5.6 델리게이트와 이벤트]
            // GameEvents.RaiseHpChanged(currentHp, maxHp);

            if (currentHp <= 0)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            if (!isAlive) return;

            // TODO [2.5 연산자] currentHp를 amount만큼 늘리되 maxHp를 넘지 않게 하세요.
            // 힌트: Mathf.Min(maxHp, currentHp + amount)

            // GameEvents.RaiseHpChanged(currentHp, maxHp);
        }

        /// <summary>매 프레임 호출. 어두운 곳에 있으면 공포가 쌓입니다.</summary>
        public void TickFear(bool inDarkness, float deltaTime)
        {
            // TODO [2.6 제어문] + [2.5 연산자]
            //   inDarkness가 true면  fear를 fearPerSecondInDark * deltaTime 만큼 올리고,
            //   false면 같은 속도의 절반으로 내리세요.
            //   fear는 항상 0 ~ 100 사이여야 합니다.
            // 힌트: fear = Mathf.Clamp(fear, 0f, 100f);
        }

        private void Die()
        {
            isAlive = false;
            Debug.Log("[PlayerStats] 사망");

            // 4일차에 주석을 풉니다.
            // GameEvents.RaiseGameOver("당신은 3층을 나가지 못했습니다.");
        }
    }
}
