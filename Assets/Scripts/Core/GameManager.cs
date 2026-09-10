using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 4~5일차 [5.2 static] [5.6 이벤트] [5.8.1 UI와 GameManager]
    //         [5.8.2 점수 기능] [5.8.4 게임 데이터 저장]
    //
    // 게임 전체에 하나만 있어야 하는 것들을 여기서 관리합니다.
    // static 필드 Instance 덕분에 어디서든 GameManager.Instance 로 부를 수 있습니다.
    //
    // 주의: static은 편하지만 남용하면 모든 게 서로 얽힙니다.
    //       "정말 하나뿐인가?"를 먼저 물어보세요.
    // ─────────────────────────────────────────────────────────────

    public class GameManager : MonoBehaviour
    {
        // [5.2 static]
        public static GameManager Instance { get; private set; }

        [Header("규칙")]
        [SerializeField] private int keysToEscape = 3;

        [Header("진행 상황")]
        [SerializeField] private GamePhase phase = GamePhase.Ready;
        [SerializeField] private float survivedSeconds;
        [SerializeField] private int keysCollected;
        [SerializeField] private int score;

        public GamePhase Phase => phase;
        public float SurvivedSeconds => survivedSeconds;
        public int Score => score;
        public int KeysToEscape => keysToEscape;

        private void Awake()
        {
            // TODO [5.2 static] 싱글턴을 완성하세요.
            //   이미 Instance가 있는데 또 생겼다면 새로 생긴 쪽을 파괴합니다.
            // 힌트:
            //   if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            //   Instance = this;
        }

        private void OnEnable()
        {
            // TODO [5.6 델리게이트와 이벤트] 이벤트를 구독하세요.
            //   GameEvents.OnKeyCollected += HandleKeyCollected;
            //   GameEvents.OnMonsterDown  += HandleMonsterDown;
            //   GameEvents.OnGameOver     += HandleGameOver;
            //   GameEvents.OnEscaped      += HandleEscaped;
            //
            // 중요: 구독했으면 OnDisable에서 반드시 해제해야 합니다.
            //       안 하면 파괴된 오브젝트가 계속 호출되어 에러가 납니다.
        }

        private void OnDisable()
        {
            // TODO [5.6] 위에서 구독한 것을 전부 -= 로 해제하세요.
        }

        private void Start()
        {
            phase = GamePhase.Playing;
        }

        private void Update()
        {
            if (phase != GamePhase.Playing) return;

            // TODO [2.5 연산자] 생존 시간을 누적하세요.
            // 힌트: survivedSeconds += Time.deltaTime;
        }

        // ── [5.8.2 static, 델리게이트, 이벤트를 이용한 점수 기능] ──

        private void HandleKeyCollected(int total)
        {
            keysCollected = total;

            // TODO [5.8.2] 열쇠 하나당 500점을 주세요.
        }

        private void HandleMonsterDown(MonsterBase monster)
        {
            // TODO [5.8.2] 몬스터를 쓰러뜨리면 200점.
        }

        private void HandleGameOver(string reason)
        {
            phase = GamePhase.GameOver;
            Debug.Log($"[GameManager] 게임 오버 — {reason}");
            Time.timeScale = 0f;
        }

        private void HandleEscaped()
        {
            phase = GamePhase.Escaped;

            // TODO [5.8.2] 탈출 보너스: 빨리 나갈수록 높은 점수.
            // 힌트: score += Mathf.Max(0, 3000 - Mathf.RoundToInt(survivedSeconds) * 5);

            Debug.Log($"[GameManager] 탈출 성공! 점수 {score}");
            Time.timeScale = 0f;
        }

        // ── [5.8.4 게임 데이터 저장] ─────────────────────────

        public void SaveProgress(PlayerStats stats, Flashlight light, Inventory inventory)
        {
            // TODO [5.8.4] SaveData를 채워 SaveSystem.Save에 넘기세요.
            // 힌트:
            //   var data = new SaveData
            //   {
            //       hp = stats.CurrentHp,
            //       battery = light.Battery,
            //       survivedSeconds = survivedSeconds,
            //       keyCount = keysCollected,
            //       items = inventory.SnapshotTypes()
            //   };
            //   SaveSystem.Save(data);
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            GameEvents.ClearAll();   // 유령 구독자 정리
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
