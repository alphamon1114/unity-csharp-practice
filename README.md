# 마지막 야간 근무 (The Last Night Shift)

「Unity 기초」(2026.09.16 ~ 09.22 · 40시수) 커리큘럼을 따라가며 직접 완성하는 2D 탑다운 공포 탈출 게임입니다.

책의 슈팅 게임 예제 자리에 공포 게임을 넣었을 뿐, 배우는 C# 개념은 커리큘럼과 1:1로 같습니다.

---

## 게임 컨셉

폐병원 3층. 정전. 손전등 하나.
**열쇠 3개를 찾아 출구로 나가면 승리.** 배터리가 다 되면 어둠 속에 남겨집니다.

| 커리큘럼의 슈팅 게임 | 이 프로젝트 |
| --- | --- |
| 플레이어 이동 | 플레이어 이동 (동일) |
| 미사일 발사 | 손전등 비추기 — 몬스터를 잠시 밀어냄 |
| 적 스폰 | 몬스터 배회 / 추격 |
| 점수 | 생존 시간 + 수집한 열쇠 |
| 아이템 | 열쇠 · 배터리 · 붕대 |
| 게임오버 | HP 0 또는 배터리 0 상태로 피격 |

---

## 처음 한 번만 하는 세팅

1. **Unity Hub → Add → Add project from disk** → `Documents\practice` 폴더를 선택합니다.
   (에디터 버전 `6000.6.0f1`)
2. 프로젝트가 열리면 **Edit → Project Settings → Player → Active Input Handling** 을
   **`Both`** 로 바꾸고 에디터를 재시작합니다. (Input System을 쓰기 때문에 꼭 필요합니다)
3. **Edit → Project Settings → Editor → Default Behavior Mode** 를 **`2D`** 로 바꿉니다.
4. `Assets/Scenes/` 에 새 씬을 만들고 이름을 `Hospital3F` 로 저장합니다.

> 이미 쓰던 2D 프로젝트에 넣고 싶다면 `Assets/Scripts` 폴더만 복사해도 됩니다.

---

## 폴더 구조

저장소 루트 = 유니티 프로젝트 루트입니다. 문서는 `Assets` 밖에 둡니다.

```
practice/
  README.md          이 문서 — 프로젝트 개요
  COMMITS.md         커밋 규약과 42개 커밋 계획
  docs/              문법 정리 · 업그레이드 검토서 · 회고
  Assets/
    Scripts/
      Core/          GameManager, GameEvents, SaveSystem, Enums, GridPos
      Player/        PlayerController, PlayerStats, Flashlight, Inventory
      Enemies/       MonsterBase, Stalker, Wanderer, MonsterSpawner, MonsterRadar
      Items/         IInteractable, IEffect, ItemBase, KeyItem, BatteryItem, ExitDoor
      UI/            HUDController
    Scenes/  Sprites/  Prefabs/  Audio/
  Packages/  ProjectSettings/
```

## 코드 읽는 법

모든 스크립트에 커리큘럼 번호가 주석으로 달려 있습니다.

```csharp
// TODO [2.5 연산자] 배터리를 시간에 비례해 깎으세요.
```

- `TODO [n.n ...]` — **직접 채워야 하는 자리.** 그날 배운 문법으로 채웁니다.
- `// 힌트:` — 막혔을 때 읽으세요.
- TODO를 하나도 채우지 않은 상태로도 컴파일되고 Play가 됩니다. 대신 아무 일도 안 일어납니다.

## 하루 순서

1. 그날 챕터를 배운다
2. `일정표`의 해당 차시 과제 목록을 연다
3. 해당 스크립트의 TODO를 채운다
4. Play를 눌러 **완성 기준**을 하나씩 확인한다

막히면 Claude에게 파일 이름과 TODO 번호를 그대로 말하면 됩니다.
예: `PlayerController.cs의 TODO [2.7.2] 어떻게 해요?`
