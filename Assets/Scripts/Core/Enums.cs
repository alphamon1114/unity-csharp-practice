namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // [4.6 열거형(Enum)] — 3일차
    //
    // "상태와 종류"를 숫자나 문자열이 아니라 이름으로 표현합니다.
    //   int itemType = 2;        →  무슨 뜻인지 알 수 없음
    //   ItemType.Battery         →  읽는 순간 이해됨
    // ─────────────────────────────────────────────────────────────

    /// <summary>주울 수 있는 물건의 종류.</summary>
    public enum ItemType
    {
        None = 0,
        Key,        // 출구를 여는 열쇠 (3개 필요)
        Battery,    // 손전등 충전
        Bandage,    // HP 회복

        // TODO [4.6 열거형] 아이템을 하나 더 추가해 보세요.
        //   예: Note(병원 기록지 — 주우면 이야기 조각이 열림)
        //   추가한 뒤 ItemBase를 상속한 새 클래스를 만들면 됩니다.
    }

    /// <summary>몬스터가 지금 무엇을 하고 있는지.</summary>
    public enum MonsterState
    {
        Idle,       // 멈춰 있음
        Wander,     // 배회 중
        Chase,      // 플레이어 추격 중
        Stunned,    // 손전등에 맞아 잠시 멈춤

        // TODO [4.6 열거형] 상태를 하나 더 추가해 보세요.
        //   예: Search(플레이어를 놓치고 마지막 위치를 뒤지는 상태)
    }

    /// <summary>문의 상태.</summary>
    public enum DoorState
    {
        Locked,     // 열쇠가 부족함
        Unlocked,   // 열 수 있음
        Opened      // 이미 열림
    }

    /// <summary>게임 전체의 흐름.</summary>
    public enum GamePhase
    {
        Ready,
        Playing,
        GameOver,
        Escaped
    }
}
