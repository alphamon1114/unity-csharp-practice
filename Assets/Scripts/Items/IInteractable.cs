namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 3일차 [4.2 인터페이스]
    //
    // 인터페이스는 "이런 일을 할 수 있다"는 약속입니다.
    // 열쇠도, 배터리도, 문도, 사물함도 서로 전혀 다른 클래스지만
    // 전부 "E키로 상호작용할 수 있다"는 점은 같습니다.
    //
    // 그래서 PlayerController는 상대가 무엇인지 몰라도 됩니다.
    //   IInteractable 만 있으면 Interact()를 부를 수 있습니다.
    // ─────────────────────────────────────────────────────────────

    public interface IInteractable
    {
        /// <summary>화면에 띄울 안내문. 예: "E — 열쇠 줍기"</summary>
        string GetPrompt();

        /// <summary>실제로 상호작용했을 때 일어나는 일.</summary>
        void Interact(PlayerController player);
    }
}
