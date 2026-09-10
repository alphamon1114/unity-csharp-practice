using System.Collections.Generic;
using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 2일차 [2.4 배열] [2.6 제어문] — 기본 스폰
    // 5일차 [5.3 컬렉션과 제네릭] [5.8.3 Enemy Spawn 개선] — 웨이브
    //
    // 처음에는 배열로 시작하고, 5일차에 List로 바꿔 보세요.
    // "왜 바꿔야 했는지"를 몸으로 느끼는 게 이 파일의 목적입니다.
    // ─────────────────────────────────────────────────────────────

    public class MonsterSpawner : MonoBehaviour
    {
        [Header("무엇을 / 어디에")]
        // [2.4 배열] 스폰 지점과 몬스터 원본
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private MonsterBase[] monsterPrefabs;

        [Header("언제")]
        [SerializeField] private float firstDelay = 5f;
        [SerializeField] private float interval = 12f;
        [SerializeField] private int maxAlive = 6;

        // [5.3 컬렉션과 제네릭] 살아 있는 몬스터 목록.
        // 배열과 달리 개수가 계속 바뀌어도 됩니다.
        private readonly List<MonsterBase> alive = new List<MonsterBase>();

        public IReadOnlyList<MonsterBase> Alive => alive;

        private float timer;

        private void Start()
        {
            timer = firstDelay;
        }

        private void Update()
        {
            // TODO [2.6 제어문] timer를 줄이고 0 이하가 되면 SpawnOne()을 부른 뒤 interval로 되돌리세요.

            // TODO [5.8.3 Enemy Spawn 개선] — 5일차
            //   죽어서 비활성화된 몬스터를 alive 목록에서 정리하세요.
            // 힌트: alive.RemoveAll(m => m == null || !m.IsAlive);
            //   ( m => ... 이 람다식입니다. [5.7 익명 메서드와 람다식] )
        }

        private void SpawnOne()
        {
            // TODO [2.6 제어문] 배열이 비어 있거나 alive.Count가 maxAlive 이상이면 그냥 돌아가세요.

            // TODO [2.4 배열] 스폰 지점과 몬스터 종류를 무작위로 하나씩 고르세요.
            // 힌트:
            //   Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //   MonsterBase prefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
            //
            // TODO [3.4 다형성] 어떤 종류든 MonsterBase 타입으로 받아 목록에 넣으세요.
            //   MonsterBase spawned = Instantiate(prefab, point.position, Quaternion.identity);
            //   alive.Add(spawned);
        }

        /// <summary>5일차 웨이브용. 난이도를 서서히 올립니다.</summary>
        public void ApplyWave(int waveIndex)
        {
            // TODO [5.8.3] 웨이브가 올라갈수록 interval을 줄이고 maxAlive를 늘리세요.
            // 힌트: interval = Mathf.Max(4f, 12f - waveIndex * 1.5f);
        }

        private void OnDrawGizmos()
        {
            if (spawnPoints == null) return;
            Gizmos.color = new Color(1f, 0.3f, 0.3f, 0.6f);
            foreach (var p in spawnPoints)
            {
                if (p != null) Gizmos.DrawWireSphere(p.position, 0.5f);
            }
        }
    }
}
