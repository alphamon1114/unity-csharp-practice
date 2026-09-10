using UnityEngine;

namespace HorrorEscape
{
    // 3일차 [4.7.5 Player, Enemy, Item으로 게임의 모습 갖추기]
    //
    // 열쇠 3개를 모아야 출구가 열립니다. 이 게임의 목표 그 자체입니다.

    public class KeyItem : ItemBase
    {
        [SerializeField] private string keyLabel = "3층 병동 열쇠";

        private void Reset()
        {
            itemType = ItemType.Key;
            displayName = "열쇠";
        }

        public override void Apply(PlayerController player)
        {
            // TODO [4.7.5] 플레이어 인벤토리에 열쇠를 넣으세요.
            // 힌트:
            //   var inv = player.GetComponent<Inventory>();
            //   inv.Add(ItemType.Key, 1);
            //
            // 4일차에 이벤트를 배우면 아래 줄도 살아납니다. [5.6 델리게이트와 이벤트]
            //   GameEvents.RaiseKeyCollected(inv.CountOf(ItemType.Key));
        }

        public override string Describe() => $"{keyLabel}을(를) 손에 넣었다. 차갑다.";
    }
}
