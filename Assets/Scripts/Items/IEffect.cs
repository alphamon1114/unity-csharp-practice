namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 3일차 [4.7.3 IEffect 인터페이스]
    //
    // "주웠을 때 무슨 일이 일어나는가"를 따로 떼어낸 약속입니다.
    // 회복 아이템, 충전 아이템, 열쇠가 각자 다르게 구현합니다.
    // ─────────────────────────────────────────────────────────────

    public interface IEffect
    {
        /// <summary>플레이어에게 효과를 적용합니다.</summary>
        void Apply(PlayerController player);

        /// <summary>로그와 UI에 남길 한 줄.</summary>
        string Describe();
    }
}
