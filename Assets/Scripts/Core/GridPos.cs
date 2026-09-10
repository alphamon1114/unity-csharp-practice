using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // [4.3 구조체(Struct)] — 3일차
    // 교재의 "Point 구조체"에 해당합니다.
    //
    // 클래스와 뭐가 다른가?
    //   class  : 참조 형식. 변수는 "주소"를 담는다. 복사해도 같은 것을 가리킨다.
    //   struct : 값 형식.   변수는 "값 자체"를 담는다. 복사하면 별개가 된다.
    //
    // 좌표처럼 작고, 값 자체가 곧 의미인 데이터는 struct가 어울립니다.
    // ─────────────────────────────────────────────────────────────

    [System.Serializable]
    public struct GridPos
    {
        public int x;
        public int y;

        public GridPos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>월드 좌표(Vector3)를 격자 좌표로 바꿉니다.</summary>
        public static GridPos FromWorld(Vector3 world)
        {
            // TODO [4.3 구조체] world.x, world.y를 반올림해서 GridPos로 만드세요.
            // 힌트: Mathf.RoundToInt(world.x)
            return new GridPos(0, 0);
        }

        /// <summary>격자 좌표를 월드 좌표로 되돌립니다.</summary>
        public Vector3 ToWorld()
        {
            return new Vector3(x, y, 0f);
        }

        /// <summary>두 칸 사이의 거리(대각선 없이 몇 칸인지).</summary>
        public int ManhattanTo(GridPos other)
        {
            // TODO [2.5 연산자] |x차이| + |y차이| 를 반환하세요.
            // 힌트: Mathf.Abs(x - other.x)
            return 0;
        }

        // struct에서도 메서드를 오버로드할 수 있습니다. [3.5.5 오버로드]
        public int ManhattanTo(Vector3 world) => ManhattanTo(FromWorld(world));

        public override string ToString() => $"({x}, {y})";
    }
}
