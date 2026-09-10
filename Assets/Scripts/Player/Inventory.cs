using System.Collections.Generic;
using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 3일차 [4.5 인덱서]
    // 4일차 [5.3 컬렉션과 제네릭]
    //
    // 배열([2.4])은 크기가 고정입니다. 무엇을 몇 개 주울지 모르는 인벤토리에는
    // Dictionary<키, 값> 같은 컬렉션이 맞습니다.
    //
    //   Dictionary<ItemType, int>  →  "열쇠: 2개, 건전지: 1개"
    //
    // <> 안에 자료형을 넣어 쓰는 것 — 이게 제네릭입니다.
    // ─────────────────────────────────────────────────────────────

    public class Inventory : MonoBehaviour
    {
        // [5.3 컬렉션과 제네릭]
        private readonly Dictionary<ItemType, int> slots = new Dictionary<ItemType, int>();

        // [5.3] 주운 순서를 기억하는 목록. 로그 화면에 씁니다.
        private readonly List<string> pickupLog = new List<string>();

        public IReadOnlyList<string> PickupLog => pickupLog;

        // ── [4.5 인덱서] ─────────────────────────────────────
        // 인덱서를 만들면 인벤토리를 배열처럼 쓸 수 있습니다.
        //   int keys = inventory[ItemType.Key];
        public int this[ItemType type]
        {
            get
            {
                // TODO [4.5 인덱서] slots에 type이 있으면 그 개수를, 없으면 0을 반환하세요.
                // 힌트: return slots.TryGetValue(type, out int count) ? count : 0;
                return 0;
            }
            set
            {
                // TODO [4.5 인덱서] 0 이하이면 항목을 지우고, 아니면 값을 설정하세요.
                // 힌트:
                //   if (value <= 0) slots.Remove(type);
                //   else slots[type] = value;
            }
        }

        /// <summary>인덱서를 그대로 쓰는 편의 메서드.</summary>
        public int CountOf(ItemType type) => this[type];

        public void Add(ItemType type, int amount = 1)
        {
            // TODO [4.5 인덱서] + [2.5 연산자] 인덱서를 이용해 개수를 더하세요.
            // 힌트: this[type] = this[type] + amount;

            pickupLog.Add($"{type} x{amount}");
        }

        public bool TryConsume(ItemType type, int amount = 1)
        {
            // TODO [2.6 제어문] 개수가 모자라면 false를 반환하고, 충분하면 빼고 true를 반환하세요.
            return false;
        }

        /// <summary>세이브용. 지금 가진 것을 전부 목록으로 내보냅니다.</summary>
        public List<ItemType> SnapshotTypes()
        {
            var list = new List<ItemType>();
            foreach (var pair in slots)
            {
                for (int i = 0; i < pair.Value; i++) list.Add(pair.Key);
            }
            return list;
        }

        public void Clear()
        {
            slots.Clear();
            pickupLog.Clear();
        }
    }
}
