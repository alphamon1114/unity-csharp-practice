using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 1일차 [2.2 변수] · [2.3 형변환] · [2.5 연산자] · [2.6 제어문]
    //
    // 이 게임에서 손전등은 무기이자 자원이자 시계입니다.
    // 켜 두면 안전하지만 배터리가 줄고, 꺼 두면 공포가 쌓입니다.
    // ─────────────────────────────────────────────────────────────

    public class Flashlight : MonoBehaviour
    {
        [Header("배터리")]
        [SerializeField] private float maxBattery = 100f;
        [SerializeField] private float battery = 100f;
        [SerializeField] private float drainPerSecond = 2.5f;
        [SerializeField] private float flashCost = 8f;      // 한 번 강하게 비출 때 드는 양

        [Header("빛")]
        [SerializeField] private bool isOn = true;
        [SerializeField] private float coneRange = 5f;
        [SerializeField] private float coneAngle = 45f;     // 좌우 합쳐 90도
        [SerializeField] private float stunDuration = 2f;

        [Header("연출")]
        [SerializeField] private SpriteRenderer beamSprite; // 없어도 동작합니다

        /// <summary>지금 실제로 빛이 나오고 있는가? (켜져 있고 배터리도 남아 있어야 true)</summary>
        public bool IsLit
        {
            get
            {
                // TODO [2.5 연산자] isOn 이면서 battery가 0보다 클 때만 true를 반환하세요.
                // 힌트: return isOn && battery > 0f;
                return false;
            }
        }

        public float BatteryRatio => battery / maxBattery;
        public float Battery => battery;

        private void Update()
        {
            // TODO [2.6 제어문] IsLit일 때만 배터리를 줄이세요.
            // TODO [2.5 연산자] battery -= drainPerSecond * Time.deltaTime;
            // TODO [2.6 제어문] battery가 0 아래로 내려가면 0으로 고정하세요.

            // GameEvents.RaiseBatteryChanged(battery, maxBattery);   // 4일차에 주석 해제

            if (beamSprite != null)
            {
                beamSprite.enabled = IsLit;
            }
        }

        public void Toggle()
        {
            isOn = !isOn;
        }

        public void Recharge(float amount)
        {
            // TODO [2.5 연산자] battery를 amount만큼 늘리되 maxBattery를 넘지 않게 하세요.
            // 힌트: battery = Mathf.Min(maxBattery, battery + amount);
        }

        /// <summary>
        /// 교재의 "미사일 발사"에 해당합니다.
        /// 앞쪽 부채꼴 안의 몬스터를 잠시 멈추게 만듭니다.
        /// </summary>
        public void Flash()
        {
            if (!IsLit)
            {
                Debug.Log("[Flashlight] 배터리가 없습니다.");
                return;
            }

            battery = Mathf.Max(0f, battery - flashCost);

            // ── 1일차: 여기까지만 해도 됩니다. 아래는 2일차 몬스터가 생긴 뒤 채웁니다. ──

            // TODO [2.4 배열] + [2.6 제어문] — 1일차 후반 / 2일차
            //   앞쪽 원 안의 콜라이더를 모두 가져와 배열에 담고,
            //   그중 부채꼴 각도 안에 들어온 것만 골라 Stun을 겁니다.
            //
            // 힌트:
            //   Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, coneRange);
            //   for (int i = 0; i < hits.Length; i++)
            //   {
            //       Vector2 toTarget = hits[i].transform.position - transform.position;
            //       float angle = Vector2.Angle(transform.up, toTarget);
            //       if (angle > coneAngle) continue;
            //
            //       // 2일차 [3.4 다형성]: 어떤 몬스터든 MonsterBase로 받아 처리합니다.
            //       if (hits[i].TryGetComponent<MonsterBase>(out var monster))
            //           monster.Stun(stunDuration);
            //   }

            Debug.Log("[Flashlight] 섬광!");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1f, 1f, 0.4f, 0.35f);
            Gizmos.DrawRay(transform.position, transform.up * coneRange);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0,  coneAngle) * transform.up * coneRange);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up * coneRange);
        }
    }
}
