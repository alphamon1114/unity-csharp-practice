using UnityEngine;

namespace HorrorEscape
{
    // 3일차 [4.7.3 IEffect 인터페이스]
    //
    // 같은 ItemBase를 상속하지만 Apply의 내용은 완전히 다릅니다. → 다형성

    public class BatteryItem : ItemBase
    {
        [SerializeField] private float chargeAmount = 35f;

        private void Reset()
        {
            itemType = ItemType.Battery;
            displayName = "건전지";
        }

        public override void Apply(PlayerController player)
        {
            // TODO [4.2 인터페이스] 플레이어의 손전등을 충전하세요.
            // 힌트:
            //   var light = player.GetComponentInChildren<Flashlight>();
            //   if (light != null) light.Recharge(chargeAmount);
        }

        public override string Describe() => $"건전지를 갈아 끼웠다. (+{chargeAmount:F0})";
    }
}
