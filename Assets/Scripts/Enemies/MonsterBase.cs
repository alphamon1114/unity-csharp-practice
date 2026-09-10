using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 2일차 [3.1 추상화] [3.2 캡슐화] [3.3 상속] [3.4 다형성]
    //       [3.5 3장 예제 - 적군 구현]
    // 3일차 [4.1 추상 클래스] — 이 클래스를 abstract로 바꾸는 것이 과제입니다.
    //
    // 모든 몬스터가 공통으로 갖는 것을 여기 모읍니다.
    //   공통: 체력, 상태, 이동 속도, 플레이어 감지, 스턴, 피격
    //   다름: "어떻게 움직이는가" ← 이것만 자식이 다시 씁니다 (override)
    // ─────────────────────────────────────────────────────────────

    [RequireComponent(typeof(Rigidbody2D))]
    public class MonsterBase : MonoBehaviour
    {
        [Header("공통 능력치")]
        [SerializeField] protected int maxHp = 30;
        [SerializeField] protected int currentHp = 30;
        [SerializeField] protected float moveSpeed = 2f;
        [SerializeField] protected float detectRange = 6f;
        [SerializeField] protected int attackDamage = 12;
        [SerializeField] protected float attackCooldown = 1.5f;

        [Header("상태")]
        [SerializeField] protected MonsterState state = MonsterState.Idle;

        protected Rigidbody2D rb;
        protected Transform player;
        protected float stunTimer;
        protected float attackTimer;

        // [3.2 캡슐화] 바깥에서는 읽기만 가능합니다.
        public MonsterState State => state;
        public bool IsAlive => currentHp > 0;
        public float DistanceToPlayer =>
            player == null ? float.MaxValue : Vector2.Distance(transform.position, player.position);

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            var found = GameObject.FindGameObjectWithTag("Player");
            if (found != null) player = found.transform;
        }

        protected virtual void Update()
        {
            if (!IsAlive) return;

            attackTimer -= Time.deltaTime;

            // ── 스턴 처리 ──
            if (stunTimer > 0f)
            {
                stunTimer -= Time.deltaTime;
                state = MonsterState.Stunned;
                rb.linearVelocity = Vector2.zero;
                return;
            }

            // TODO [2.6 제어문] + [3.1 추상화]
            //   플레이어가 detectRange 안에 있으면 state를 Chase로,
            //   아니면 Wander로 바꾸세요.
            // 힌트: state = DistanceToPlayer <= detectRange ? MonsterState.Chase : MonsterState.Wander;

            // [3.4 다형성] 여기서는 "행동해라"라고만 말합니다.
            // 실제로 어떻게 움직일지는 Stalker냐 Wanderer냐에 따라 달라집니다.
            Behave();
        }

        /// <summary>
        /// 몬스터마다 다른 행동. 자식 클래스에서 override 합니다.
        /// </summary>
        // TODO [4.1 추상 클래스] — 3일차
        //   MonsterBase는 그 자체로 씬에 놓을 이유가 없습니다.
        //   1) 클래스 선언을 `public abstract class MonsterBase`로 바꾸고
        //   2) 아래 메서드를 `protected abstract void Behave();` 로 (본문 없이) 바꾸세요.
        //   3) 컴파일 에러가 나는 곳을 따라가며 자식이 반드시 구현하게 만드세요.
        protected virtual void Behave()
        {
            // 기본 동작: 가만히 있습니다.
            rb.linearVelocity = Vector2.zero;
        }

        /// <summary>지정한 방향으로 이동합니다. 자식들이 공통으로 씁니다.</summary>
        protected void MoveTowards(Vector2 target)
        {
            // TODO [2.5 연산자] target까지의 방향 벡터를 구해 정규화하고 속도를 곱하세요.
            // 힌트:
            //   Vector2 dir = ((Vector2)target - (Vector2)transform.position).normalized;
            //   rb.linearVelocity = dir * moveSpeed;
        }

        // ── [3.5.3 적군의 피격] ───────────────────────────────
        public virtual void TakeDamage(int amount)
        {
            if (!IsAlive) return;

            currentHp = Mathf.Max(0, currentHp - amount);

            if (currentHp <= 0)
            {
                Die();
            }
        }

        // [3.5.5 메서드 오버로드] 이름은 같고 매개변수만 다른 메서드
        public void TakeDamage(int amount, Vector2 knockbackFrom)
        {
            TakeDamage(amount);

            // TODO [3.5.5 오버로드] knockbackFrom 반대 방향으로 밀려나게 하세요.
            // 힌트: rb.AddForce(((Vector2)transform.position - knockbackFrom).normalized * 6f, ForceMode2D.Impulse);
        }

        /// <summary>손전등 섬광에 맞았을 때.</summary>
        public virtual void Stun(float duration)
        {
            stunTimer = Mathf.Max(stunTimer, duration);
            state = MonsterState.Stunned;
        }

        protected virtual void Die()
        {
            state = MonsterState.Idle;
            rb.linearVelocity = Vector2.zero;

            // GameEvents.RaiseMonsterDown(this);   // 4일차에 주석 해제
            gameObject.SetActive(false);
        }

        protected virtual void OnCollisionStay2D(Collision2D collision)
        {
            if (attackTimer > 0f || !IsAlive || stunTimer > 0f) return;

            // TODO [2.6 제어문] 부딪힌 것이 플레이어라면 PlayerStats.TakeDamage를 부르세요.
            // 힌트:
            //   if (collision.collider.TryGetComponent<PlayerStats>(out var stats))
            //   {
            //       stats.TakeDamage(attackDamage);
            //       attackTimer = attackCooldown;
            //   }
        }

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectRange);
        }
    }
}
