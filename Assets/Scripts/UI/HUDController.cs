using UnityEngine;
using UnityEngine.UI;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 4~5일차 [5.6 델리게이트와 이벤트] [5.7 람다식] [5.8.1 UI와 GameManager]
    //
    // 이 스크립트에는 Update()가 없습니다. 일부러 그렇게 만들었습니다.
    // 매 프레임 값을 확인하는 대신, "바뀌었을 때만" 연락을 받습니다.
    //
    // 씬 세팅:
    //   Canvas 아래에 Slider 2개(HP/배터리), Text 3개(열쇠/점수/메시지)를 만들고
    //   인스펙터에서 끌어다 연결하세요.
    // ─────────────────────────────────────────────────────────────

    public class HUDController : MonoBehaviour
    {
        [Header("게이지")]
        [SerializeField] private Slider hpBar;
        [SerializeField] private Slider batteryBar;

        [Header("글자")]
        [SerializeField] private Text keyText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text messageText;

        [Header("패널")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject escapePanel;

        private void OnEnable()
        {
            // TODO [5.6 델리게이트와 이벤트] 이벤트를 구독하세요.
            //   GameEvents.OnHpChanged      += UpdateHp;
            //   GameEvents.OnBatteryChanged += UpdateBattery;
            //   GameEvents.OnKeyCollected   += UpdateKeys;
            //
            // TODO [5.7 익명 메서드와 람다식]
            //   메서드를 따로 만들 만큼 길지 않은 처리는 람다로 바로 씁니다.
            //   GameEvents.OnGameOver += reason => ShowEnding(gameOverPanel, reason);
            //   GameEvents.OnEscaped  += () => ShowEnding(escapePanel, "3층을 빠져나왔다.");
            //
            //   주의: 람다로 구독하면 -= 로 정확히 해제하기 어렵습니다.
            //         그래서 아래 OnDisable에서는 ClearAll을 쓰거나,
            //         람다를 변수에 담아 두었다가 해제해야 합니다. 왜 그런지 생각해 보세요.
        }

        private void OnDisable()
        {
            // TODO [5.6] 구독을 해제하세요.
        }

        private void UpdateHp(int current, int max)
        {
            // TODO [2.3 형변환] Slider.value는 0~1 사이 float입니다.
            // 힌트: if (hpBar != null) hpBar.value = (float)current / max;
        }

        private void UpdateBattery(float current, float max)
        {
            // TODO [2.5 연산자] 배터리 비율을 게이지에 반영하세요.
        }

        private void UpdateKeys(int total)
        {
            int need = GameManager.Instance != null ? GameManager.Instance.KeysToEscape : 3;

            // TODO [5.1 문자열 다루기] "열쇠 2 / 3" 형태로 표시하세요.
            // 힌트: keyText.text = $"열쇠 {total} / {need}";
        }

        private void ShowEnding(GameObject panel, string message)
        {
            if (panel != null) panel.SetActive(true);
            if (messageText != null) messageText.text = message;

            if (scoreText != null && GameManager.Instance != null)
            {
                scoreText.text = $"점수 {GameManager.Instance.Score}";
            }
        }
    }
}
