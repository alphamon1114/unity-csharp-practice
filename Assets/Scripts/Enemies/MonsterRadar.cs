using System.Collections.Generic;
using System.Linq;              // ← LINQ를 쓰려면 이 한 줄이 필요합니다.
using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 5일차 [6 LINQ (Language Integrated Query)]
    //
    // LINQ는 "목록에서 조건에 맞는 것 고르기"를 문장처럼 쓰게 해 줍니다.
    //
    //   foreach로 쓰면          →  10줄
    //   LINQ로 쓰면             →  1줄
    //
    // 단, 매 프레임 부르면 쓰레기(garbage)가 쌓입니다.
    // 이 스크립트는 0.2초에 한 번만 계산하게 만들어 두었습니다. 이유도 같이 배우세요.
    // ─────────────────────────────────────────────────────────────

    public class MonsterRadar : MonoBehaviour
    {
        [SerializeField] private MonsterSpawner spawner;
        [SerializeField] private Transform player;
        [SerializeField] private float dangerRadius = 7f;
        [SerializeField] private float refreshInterval = 0.2f;

        private float timer;

        // 계산 결과를 담아 두는 곳. 다른 스크립트는 이것만 읽습니다.
        public MonsterBase Nearest { get; private set; }
        public int ChasingCount { get; private set; }
        public bool AnyStalkerNearby { get; private set; }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer > 0f) return;
            timer = refreshInterval;

            Refresh();
        }

        private void Refresh()
        {
            if (spawner == null || player == null) return;

            // 살아 있는 몬스터만 추린 원본 목록
            List<MonsterBase> monsters = spawner.Alive
                .Where(m => m != null && m.IsAlive)
                .ToList();

            // ── 아래 세 개를 LINQ 한 줄씩으로 채우세요 ──────────

            // TODO [6 LINQ] 가장 가까운 몬스터 찾기
            // 힌트: monsters.OrderBy(m => m.DistanceToPlayer).FirstOrDefault();
            Nearest = null;

            // TODO [6 LINQ] 지금 나를 쫓고 있는 몬스터의 수
            // 힌트: monsters.Count(m => m.State == MonsterState.Chase);
            ChasingCount = 0;

            // TODO [6 LINQ] 위험 반경 안에 Stalker가 하나라도 있는가?
            // 힌트: monsters.Any(m => m is Stalker && m.DistanceToPlayer <= dangerRadius);
            //   ( is 는 "이 타입이 맞니?"를 묻는 연산자입니다 — 다형성과 짝을 이룹니다 )
            AnyStalkerNearby = false;
        }

        /// <summary>
        /// [6 LINQ] 심화 — 종류별로 몇 마리인지 세어 문자열로 만들기.
        /// 예: "Stalker 2 · Wanderer 3"
        /// </summary>
        public string DescribeThreats()
        {
            if (spawner == null) return "";

            // TODO [6 LINQ] GroupBy와 Select, 그리고 string.Join을 조합해 보세요.
            // 힌트:
            //   var parts = spawner.Alive
            //       .Where(m => m != null && m.IsAlive)
            //       .GroupBy(m => m.GetType().Name)
            //       .Select(g => $"{g.Key} {g.Count()}");
            //   return string.Join(" · ", parts);      // [5.1 문자열 다루기]

            return "";
        }
    }
}
