using System;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 4일차 [5.2 static] [5.6 델리게이트와 이벤트] [5.7 람다식]
    //
    // 문제:
    //   PlayerStats가 HP를 깎을 때마다 UI를 직접 찾아서 갱신하면
    //   PlayerStats가 UI를 알아야 합니다. 서로 엉킵니다.
    //
    // 해결:
    //   PlayerStats는 "HP가 바뀌었다"고 방송만 합니다. (Raise)
    //   듣고 싶은 쪽이 알아서 구독합니다. (+=)
    //   서로 존재를 몰라도 됩니다.
    //
    // static이라 어디서든 GameEvents.OnHpChanged 로 접근할 수 있습니다.
    // ─────────────────────────────────────────────────────────────

    public static class GameEvents
    {
        // Action<T> 는 "T를 받고 아무것도 반환하지 않는 메서드"를 담는 델리게이트입니다.
        public static event Action<int, int> OnHpChanged;        // (현재, 최대)
        public static event Action<float, float> OnBatteryChanged; // (현재, 최대)
        public static event Action<int> OnKeyCollected;          // (지금까지 모은 개수)
        public static event Action<MonsterBase> OnMonsterDown;
        public static event Action<string> OnGameOver;           // (사유)
        public static event Action OnEscaped;

        // ── 방송하는 쪽이 부르는 메서드들 ──────────────────────
        // ?.Invoke() 의 ? 는 "구독자가 아무도 없으면 그냥 넘어가라"는 뜻입니다.

        public static void RaiseHpChanged(int current, int max) => OnHpChanged?.Invoke(current, max);
        public static void RaiseBatteryChanged(float current, float max) => OnBatteryChanged?.Invoke(current, max);
        public static void RaiseKeyCollected(int total) => OnKeyCollected?.Invoke(total);
        public static void RaiseMonsterDown(MonsterBase monster) => OnMonsterDown?.Invoke(monster);
        public static void RaiseGameOver(string reason) => OnGameOver?.Invoke(reason);
        public static void RaiseEscaped() => OnEscaped?.Invoke();

        /// <summary>
        /// 씬을 다시 로드해도 이벤트 구독이 남아 있으면 유령 구독자가 생깁니다.
        /// 게임을 새로 시작할 때 반드시 부르세요.
        /// </summary>
        public static void ClearAll()
        {
            OnHpChanged = null;
            OnBatteryChanged = null;
            OnKeyCollected = null;
            OnMonsterDown = null;
            OnGameOver = null;
            OnEscaped = null;
        }
    }
}
