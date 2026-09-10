using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 3일차 [4.7.1 Item 클래스] [4.1 추상 클래스] [4.2 인터페이스] [4.6 열거형]
    //
    // 한 클래스가 인터페이스를 여러 개 구현할 수 있습니다.
    //   IInteractable — E키로 주울 수 있다
    //   IEffect       — 주우면 무슨 일이 일어난다
    //
    // 상속은 하나만, 인터페이스는 여러 개. 이게 C#의 규칙입니다.
    // ─────────────────────────────────────────────────────────────

    public abstract class ItemBase : MonoBehaviour, IInteractable, IEffect
    {
        [SerializeField] protected ItemType itemType = ItemType.None;
        [SerializeField] protected string displayName = "이름 없는 물건";
        [SerializeField] protected bool consumeOnPickup = true;

        public ItemType Type => itemType;
        public string DisplayName => displayName;

        // [4.3 구조체] 이 아이템이 놓인 칸. 세이브할 때 씁니다.
        public GridPos Position => GridPos.FromWorld(transform.position);

        // ── IInteractable ─────────────────────────────────────
        public virtual string GetPrompt() => $"E — {displayName}";

        public virtual void Interact(PlayerController player)
        {
            // TODO [4.2 인터페이스] 효과를 적용하고, 소모품이면 사라지게 하세요.
            // 힌트:
            //   Apply(player);
            //   Debug.Log(Describe());
            //   if (consumeOnPickup) gameObject.SetActive(false);
        }

        // ── IEffect ───────────────────────────────────────────
        // abstract이므로 자식은 반드시 구현해야 합니다. [4.1 추상 클래스]
        public abstract void Apply(PlayerController player);

        public virtual string Describe() => $"{displayName}을(를) 주웠다.";
    }
}
