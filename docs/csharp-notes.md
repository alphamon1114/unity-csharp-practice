# C# 문법 정리

「처음 배우는 C# 프로그래밍」 커리큘럼 항목을 이 프로젝트 코드와 짝지어 정리했습니다.
수업 중에 찾아보는 용도라 설명은 짧고, **자주 틀리는 것** 칸에 무게를 뒀습니다.

---

## 02장 · C# 기초 문법

| 항목 | 한 줄 | 이 프로젝트에서 | 자주 틀리는 것 |
| --- | --- | --- | --- |
| 2.1 토큰과 코드 작성 | 코드를 이루는 최소 단위(키워드·식별자·리터럴·연산자·구분자) | 모든 파일 | 클래스 이름과 **파일 이름이 다르면** 유니티가 컴포넌트로 못 붙임 |
| 2.2 변수와 자료형 | 값을 담는 그릇과 그릇의 종류 | `PlayerStats`의 hp·moveSpeed·fear | `int`로 충분한 걸 `float`으로, 비율을 `int`로 잡는 것 |
| 2.3 형변환 | 자료형을 바꾸는 것. 암시적/명시적 | `PlayerStats.HpRatio` | **`int / int`는 결과도 `int`**. `50/100`이 `0`이 됨 |
| 2.4 배열 | 같은 자료형을 정해진 개수만큼 | `Wanderer.patrolPoints`, `Physics2D.OverlapCircleAll` 결과 | 길이가 0인 배열을 `[0]`으로 접근 → `IndexOutOfRange` |
| 2.5 연산자 | 계산·비교·논리 | 피해량, 배터리 소모, 공포 누적 | `=`(대입)과 `==`(비교) 혼동. `%`로 순환 인덱스 만들기를 안 떠올림 |
| 2.6 제어문 | `if` `switch` `for` `while` `foreach` | 감지 조건, 게임오버, 순찰 | `foreach` 도는 중에 그 컬렉션을 수정 → 예외 |
| 2.7 플레이어 구현 | 위 전부를 합친 첫 결과물 | `PlayerController` | 이동을 `Update`에 넣고 `Time.deltaTime`을 빼먹음 |

### 짚고 갈 것

**`float`에는 `f`를 붙인다.** `float speed = 4.0;` 는 컴파일 에러입니다. `4.0`은 `double`이라서요.

**`Update`와 `FixedUpdate`.** 입력 읽기는 `Update`(매 프레임), 물리 이동은 `FixedUpdate`(고정 간격).
`Rigidbody2D`를 `Update`에서 움직이면 프레임 수에 따라 속도가 달라집니다.

**대각선 이동이 빠른 이유.** `(1, 1)`의 길이는 `1`이 아니라 `√2 ≈ 1.414`.
`.normalized`로 길이를 1로 맞춰야 합니다.

---

## 03장 · 클래스

| 항목 | 한 줄 | 이 프로젝트에서 | 자주 틀리는 것 |
| --- | --- | --- | --- |
| 3.1 추상화 | 공통점만 남기고 나머지를 버리는 것 | `MonsterBase` | 부모에 자식 전용 기능까지 넣어 부모가 비대해짐 |
| 3.2 캡슐화 | 안을 감추고 정해진 통로로만 바꾸게 | `CurrentHp`는 `public get` / `private set` | 전부 `public` 필드로 열어두고 아무 데서나 수정 |
| 3.3 상속 | 부모의 것을 물려받아 확장 | `Stalker : MonsterBase` | 자식 `Awake`에서 **`base.Awake()` 호출을 빼먹음** |
| 3.4 다형성 | 같은 호출, 다른 동작 | `Behave()` 하나로 두 몬스터 처리 | `virtual` 없이 자식에서 같은 이름 메서드를 만들어 가림(`new`) |
| 3.5.5 오버라이드 / 오버로드 | 덮어쓰기 vs 이름 재사용 | `Stun` 오버라이드, `TakeDamage` 오버로드 | 둘을 같은 말로 씀 |

### 오버라이드 vs 오버로드

한 글자 차이인데 전혀 다릅니다.

```csharp
// 오버라이드 — 부모의 메서드를 자식이 다시 씀. 시그니처가 같다.
public override void Stun(float duration) { base.Stun(duration * 0.5f); }

// 오버로드 — 같은 이름, 다른 매개변수. 같은 클래스 안에서도 된다.
public void TakeDamage(int amount) { }
public void TakeDamage(int amount, Vector2 knockbackFrom) { }
```

### 접근 제한자

| | 자신 | 자식 | 외부 |
| --- | --- | --- | --- |
| `private` | ○ | ✕ | ✕ |
| `protected` | ○ | ○ | ✕ |
| `public` | ○ | ○ | ○ |

유니티에서는 **`[SerializeField] private`** 가 기본기입니다.
인스펙터에는 보이고 코드로는 못 건드리는 상태 — 캡슐화를 지키면서 값만 조정할 수 있습니다.
`public`으로 열면 인스펙터에도 보이지만 캡슐화가 깨집니다.

---

## 04장 · 클래스의 응용

| 항목 | 한 줄 | 이 프로젝트에서 | 자주 틀리는 것 |
| --- | --- | --- | --- |
| 4.1 추상 클래스 | 그 자체로는 만들 수 없는 설계도 | `MonsterBase` `ItemBase` | 자식이 `abstract` 멤버를 구현 안 해 컴파일 실패 |
| 4.2 인터페이스 | "이런 일을 할 수 있다"는 약속 | `IInteractable` `IEffect` | 인터페이스에 필드를 넣으려 함(불가) |
| 4.3 구조체 | 값 형식. 복사하면 별개가 됨 | `GridPos` | 클래스처럼 생각해 복사본을 고치고 원본이 바뀌길 기대 |
| 4.4 네임스페이스 | 이름 충돌을 막는 울타리 | `HorrorEscape.Core` 등 | `using`을 안 넣고 "왜 못 찾지" |
| 4.5 인덱서 | 객체를 배열처럼 `[ ]`로 | `Inventory[ItemType.Key]` | 없는 키를 그냥 읽어 예외 |
| 4.6 열거형 | 이름 붙은 상수 묶음 | `ItemType` `MonsterState` `DoorState` | 숫자나 문자열로 상태를 표현 |

### 상속은 하나, 인터페이스는 여럿

```csharp
public abstract class ItemBase : MonoBehaviour, IInteractable, IEffect
//                               └ 부모 하나        └ 인터페이스는 몇 개든
```

### 클래스 vs 구조체

```csharp
GridPos a = new GridPos(1, 1);
GridPos b = a;      // 값이 통째로 복사됨
b.x = 99;           // a.x는 여전히 1

Player p = new Player();
Player q = p;       // 주소만 복사됨 — 같은 것을 가리킨다
q.hp = 0;           // p.hp도 0
```

좌표·크기처럼 **작고, 값 자체가 곧 의미**인 것만 구조체로. 나머지는 클래스입니다.

---

## 05장 · 한 걸음 더

| 항목 | 한 줄 | 이 프로젝트에서 | 자주 틀리는 것 |
| --- | --- | --- | --- |
| 5.1 문자열 다루기 | 보간·서식·분해 | `$"열쇠 {total} / {need}"` | `+`로 매 프레임 이어붙여 쓰레기 생성 |
| 5.2 static | 인스턴스가 아니라 클래스에 붙음 | `GameEvents` `GameManager.Instance` | 아무거나 static으로 만들어 전부 얽힘 |
| 5.3 컬렉션과 제네릭 | 크기가 변하는 자료구조 + 타입 매개변수 | `List<MonsterBase>` `Dictionary<ItemType,int>` | `List`를 `foreach` 돌며 `Remove` |
| 5.4 파일스트림 | 파일 읽고 쓰기 | `SaveSystem` | 경로를 하드코딩. `Application.persistentDataPath`를 써야 함 |
| 5.5 예외 처리 | 실패를 예상하고 대비 | 손상된 세이브 방어 | `catch { }` 로 삼켜버려 원인을 못 찾음 |
| 5.6 델리게이트와 이벤트 | 메서드를 값처럼 넘기기 | `GameEvents.OnHpChanged` | 구독(`+=`)만 하고 해제(`-=`)를 안 함 |
| 5.7 익명 메서드와 람다식 | 이름 없는 짧은 메서드 | `RemoveAll(m => !m.IsAlive)` | 람다로 구독해놓고 해제하려다 못 함 |

### 이벤트 구독 해제를 꼭 해야 하는 이유

```csharp
void OnEnable()  { GameEvents.OnHpChanged += UpdateHp; }
void OnDisable() { GameEvents.OnHpChanged -= UpdateHp; }   // 이 줄이 없으면
```

`GameEvents`는 `static`이라 씬이 바뀌어도 살아 있습니다.
해제를 안 하면 이미 파괴된 UI 오브젝트를 계속 호출해서
`MissingReferenceException`이 쏟아집니다. **씬을 다시 로드할 때 터집니다.**

람다로 구독하면 `-=`로 정확히 떼어낼 수 없습니다. 참조가 다르니까요.
그래서 람다 구독은 오래 살지 않는 곳에만 쓰거나, 변수에 담아둡니다.

```csharp
Action<string> handler = reason => ShowEnding(reason);
GameEvents.OnGameOver += handler;
GameEvents.OnGameOver -= handler;   // 이건 떼어진다
```

### 컬렉션을 돌며 지우기

```csharp
foreach (var m in alive) { if (!m.IsAlive) alive.Remove(m); }   // 예외
alive.RemoveAll(m => !m.IsAlive);                                // 이렇게
```

---

## 06 · LINQ

목록에서 조건에 맞는 것을 문장처럼 골라냅니다. `using System.Linq;` 가 있어야 합니다.

| 메서드 | 하는 일 | 이 프로젝트 |
| --- | --- | --- |
| `Where` | 조건에 맞는 것만 | 살아 있는 몬스터만 |
| `OrderBy` | 정렬 | 거리순 정렬 |
| `FirstOrDefault` | 첫 번째, 없으면 `null` | 가장 가까운 몬스터 |
| `Count(조건)` | 조건에 맞는 개수 | 추격 중인 몬스터 수 |
| `Any(조건)` | 하나라도 있나 | 위험 반경 안의 Stalker |
| `Select` | 모양 바꾸기 | 종류별 요약 문자열 |
| `GroupBy` | 묶기 | 종류별 집계 |

```csharp
// foreach로 쓰면
MonsterBase nearest = null; float best = float.MaxValue;
foreach (var m in monsters) {
    if (m == null || !m.IsAlive) continue;
    if (m.DistanceToPlayer < best) { best = m.DistanceToPlayer; nearest = m; }
}

// LINQ로 쓰면
var nearest = monsters.Where(m => m != null && m.IsAlive)
                      .OrderBy(m => m.DistanceToPlayer)
                      .FirstOrDefault();
```

**단, 매 프레임 부르지 마세요.** LINQ는 중간 결과를 계속 새로 만들어서
`Update`에서 돌리면 GC가 쉬지 않고 돕니다. `MonsterRadar`가 0.2초에 한 번만
계산하는 이유가 그것입니다.
