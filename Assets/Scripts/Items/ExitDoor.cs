using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 3일차 [4.2 인터페이스] [4.6 열거형]
    //
    // 문은 아이템이 아니지만 IInteractable은 똑같이 구현합니다.
    // PlayerController 입장에서는 열쇠나 문이나 "E키로 뭔가 되는 것"일 뿐입니다.
    // 이게 인터페이스의 힘입니다.
    // ─────────────────────────────────────────────────────────────

    public class ExitDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private int requiredKeys = 3;
        [SerializeField] private DoorState state = DoorState.Locked;

        public DoorState State => state;

        public string GetPrompt()
        {
            // TODO [4.6 열거형] + [2.6 제어문] state에 따라 다른 문구를 반환하세요.
            //   Locked   → "열쇠가 부족하다"
            //   Unlocked → "E — 문 열기"
            //   Opened   → ""
            //
            // 힌트: switch 식을 쓰면 세 줄이면 됩니다.
            //   return state switch { DoorState.Locked => "...", ... };
            return "…";
        }

        public void Interact(PlayerController player)
        {
            var inventory = player.GetComponent<Inventory>();
            if (inventory == null) return;

            // TODO [4.6 열거형] + [2.6 제어문]
            //   1) 열쇠 개수가 requiredKeys 이상이면 state를 Unlocked로 바꿉니다.
            //   2) Unlocked라면 Opened로 바꾸고 탈출 처리를 합니다.
            //
            // 힌트:
            //   int keys = inventory.CountOf(ItemType.Key);
            //   if (keys >= requiredKeys) state = DoorState.Unlocked;
            //
            // 4일차에 이벤트를 배우면:
            //   if (state == DoorState.Unlocked)
            //   {
            //       state = DoorState.Opened;
            //       GameEvents.RaiseEscaped();
            //   }

            Debug.Log("[ExitDoor] 문을 만졌다.");
        }
    }
}
