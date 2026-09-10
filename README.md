# 마지막 야간 근무 · The Last Night Shift

> 「처음 배우는 C# 프로그래밍」 커리큘럼을 슈팅 게임 예제 대신 **2D 탑다운 공포 탈출 게임** 하나로 완주하는 학습 프로젝트입니다.
> 배우는 문법은 교재와 1:1로 같고, 매 커밋이 커리큘럼 소단원 하나에 대응합니다.

![Unity](https://img.shields.io/badge/Unity-6000.6.0f1-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Input%20System%201.20-239120?logo=csharp&logoColor=white)
![상태](https://img.shields.io/badge/상태-진행중-E8A33D)

**2026.09.16 → 09.22 · 40시수 · 5일** · NC AI 대전

---

## 무엇을 만드나

폐병원 3층. 정전. 손전등 하나.
**열쇠 3개를 찾아 출구로 나가면 승리.** 배터리가 다 되면 어둠 속에 남겨집니다.

손전등이 무기이자 자원이자 시계입니다. 켜 두면 몬스터를 밀어낼 수 있지만 배터리가 닳고,
꺼 두면 공포가 쌓여 손이 떨립니다. 이 하나의 트레이드오프가 게임 전체를 굴립니다.

| 시스템 | 내용 |
| --- | --- |
| 플레이어 | 이동 · 손전등 토글 · 섬광 · 상호작용 (Input System) |
| 몬스터 | 추격형 `Stalker`, 배회형 `Wanderer` — 같은 부모, 다른 행동 |
| 아이템 | 열쇠 · 건전지 · 붕대 — 인터페이스로 효과 분리 |
| 진행 | 열쇠 수집 → 출구 해금 → 탈출, 생존 시간 기반 점수 |
| 데이터 | 이벤트 기반 UI 갱신, JSON 세이브, 손상 파일 방어 |

> 🖼️ *플레이 화면 — 5일차 빌드 완료 후 추가 예정*

---

## 어떤 문법을 어디서 쓰나

이 프로젝트의 목적은 게임이 아니라 **문법이 실제로 필요해지는 순간을 만드는 것**입니다.
아래 표가 이 저장소의 핵심입니다.

| 문법 | 왜 여기서 필요해지나 | 코드 |
| --- | --- | --- |
| 형변환 | HP 게이지가 0 아니면 1로만 나오는 걸 고쳐야 함 | `PlayerStats.HpRatio` |
| 배열 | 순찰 지점이 여러 개, 섬광 범위 안의 대상이 여러 개 | `Wanderer.patrolPoints` |
| 상속 | 몬스터 두 종류가 체력·피격·스턴을 똑같이 가짐 | `MonsterBase` → `Stalker` / `Wanderer` |
| 다형성 | 섬광 한 번으로 종류를 몰라도 전부 처리해야 함 | `MonsterBase.Behave()` |
| 추상 클래스 | `MonsterBase`를 씬에 직접 붙이는 실수를 막아야 함 | `abstract class MonsterBase` |
| 인터페이스 | 열쇠·건전지·문을 E키 하나로 다뤄야 함 | `IInteractable` · `IEffect` |
| 구조체 | 좌표를 복사해도 원본이 안 바뀌어야 함 | `GridPos` |
| 인덱서 | 인벤토리를 `inventory[ItemType.Key]`로 읽고 싶음 | `Inventory` |
| 열거형 | 몬스터 상태를 숫자 대신 이름으로 | `MonsterState` · `ItemType` |
| 컬렉션 · 제네릭 | 몇 개를 주울지 미리 알 수 없음 | `Dictionary<ItemType, int>` |
| 델리게이트 · 이벤트 | UI가 플레이어를 몰라도 갱신돼야 함 | `GameEvents` |
| 파일 · 예외 처리 | 세이브 파일은 언제든 깨질 수 있음 | `SaveSystem` |
| LINQ | 가장 가까운 몬스터를 열 줄이 아니라 한 줄로 | `MonsterRadar` |

---

## 진행 상황

| 차시 | 날짜 | 범위 | 상태 |
| --- | --- | --- | --- |
| 1일차 | 09.16 (수) | 02장 C# 기초 문법 · 플레이어 구현 | ⬜ |
| 2일차 | 09.17 (목) | 03장 클래스 · 적군 구현 | ⬜ |
| 3일차 | 09.18 (금) | 04장 클래스의 응용 · 아이템 구현 | ⬜ |
| 4일차 | 09.21 (월) | 05장 한 걸음 더 · UI와 저장 | ⬜ |
| 5일차 | 09.22 (화) | 5.8 종합 + 06 LINQ · 빌드 | ⬜ |

커밋 42개 전체 계획은 [`COMMITS.md`](COMMITS.md)에 있습니다.

---

## 실행

**요구 사항** · Unity **6000.6.0f1**

1. Unity Hub → **Add** → **Add project from disk** → 이 폴더 선택
2. **Edit → Project Settings → Player → Active Input Handling** 을 **`Both`** 로 변경 후 에디터 재시작
3. **Edit → Project Settings → Editor → Default Behavior Mode** 를 **`2D`** 로 변경
4. `Assets/Scenes/Hospital3F` 열고 Play

| 조작 | 키 |
| --- | --- |
| 이동 | `WASD` / 방향키 |
| 달리기 | `Shift` |
| 손전등 섬광 | `Space` |
| 상호작용 | `E` |

---

## 저장소 구조

```
Assets/Scripts/
  Core/      GameManager · GameEvents · SaveSystem · Enums · GridPos
  Player/    PlayerController · PlayerStats · Flashlight · Inventory
  Enemies/   MonsterBase · Stalker · Wanderer · MonsterSpawner · MonsterRadar
  Items/     IInteractable · IEffect · ItemBase · KeyItem · BatteryItem · ExitDoor
  UI/        HUDController
docs/        문법 정리 · 업그레이드 검토
```

모든 스크립트에 커리큘럼 번호가 주석으로 달려 있습니다.

```csharp
// TODO [2.5 연산자] 배터리를 시간에 비례해 깎으세요.
```

TODO를 하나도 채우지 않은 상태로도 컴파일되고 Play가 됩니다. 대신 아무 일도 일어나지 않습니다.
[`Assets/Scripts/README.md`](Assets/Scripts/README.md)에 차시별로 어느 파일을 여는지 정리해 뒀습니다.

---

## 문서

| 문서 | 내용 |
| --- | --- |
| [`docs/csharp-notes.md`](docs/csharp-notes.md) | 커리큘럼 항목별 문법 정리 — 정의 · 이 프로젝트에서의 쓰임 · 자주 틀리는 것 |
| [`docs/upgrade-review.md`](docs/upgrade-review.md) | 교재 예제의 구버전 API를 Unity 6 기준으로 올리는 검토 (적용 6 / 보류 4 / 비적용 2) |
| [`COMMITS.md`](COMMITS.md) | 커밋 규약과 42개 커밋 계획 |
| Wiki | 차시별 학습 일지와 트러블슈팅 |

---

## 커밋 규약

커밋 하나 = 커리큘럼 소단원 하나. 히스토리 자체가 학습 기록이 됩니다.

```
feat(2.3): 형변환 — HpRatio가 0/1이 아닌 비율을 반환

int / int 결과가 정수라 게이지가 항상 0이거나 1이었다.
분자를 float으로 캐스팅해 해결.
```

`feat` 기능 · `refactor` 구조 변경 · `fix` 버그 · `docs` 문서 · `chore` 설정
