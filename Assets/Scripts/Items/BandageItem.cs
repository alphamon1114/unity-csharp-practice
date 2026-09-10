using UnityEngine;

namespace HorrorEscape
{
    // 3일차 [4.7.3 IEffect 인터페이스]

    public class BandageItem : ItemBase
    {
        [SerializeField] private int healAmount = 25;

        private void Reset()
        {
            itemType = ItemType.Bandage;
            displayName = "붕대";
        }

        public override void Apply(PlayerController player)
        {
            // TODO [4.2 인터페이스] 플레이어의 HP를 회복시키세요.
            // 힌트:
            //   var stats = player.GetComponent<PlayerStats>();
            //   if (stats != null) stats.Heal(healAmount);
        }

        public override string Describe() => $"상처를 감쌌다. (+{healAmount})";
    }
}
