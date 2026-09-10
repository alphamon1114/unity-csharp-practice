# 스크립트 지도

차시 순서대로 정리했습니다. 그날 열어야 할 파일만 열면 됩니다.

## 1일차 — 2장 C# 기초 문법

| 파일 | 담당 항목 |
| --- | --- |
| `Player/PlayerStats.cs` | 2.2 변수와 자료형 · 2.3 형변환 · 2.5 연산자 · 2.6 제어문 |
| `Player/Flashlight.cs` | 2.2 변수 · 2.5 연산자 · 2.6 제어문 |
| `Player/PlayerController.cs` | 2.7.1~2.7.4 플레이어 오브젝트 · 이동 · 공격 · Input System |
| `Enemies/Wanderer.cs` (순찰 지점) | 2.4 배열 |

## 2일차 — 3장 클래스

| 파일 | 담당 항목 |
| --- | --- |
| `Enemies/MonsterBase.cs` | 3.1 추상화 · 3.2 캡슐화 · 3.5.1~3.5.3 |
| `Enemies/Stalker.cs` | 3.3 상속 · 3.4 다형성 · 3.5.4 · 3.5.5 오버라이드 |
| `Enemies/Wanderer.cs` | 3.3 상속 · 3.4 다형성 · 3.5.4 |
| `Enemies/MonsterSpawner.cs` | 3.5.2 객체 생성 |

## 3일차 — 4장 클래스의 응용

| 파일 | 담당 항목 |
| --- | --- |
| `Enemies/MonsterBase.cs` | 4.1 추상 클래스 (virtual → abstract 로 바꾸기) |
| `Items/IInteractable.cs` `Items/IEffect.cs` | 4.2 인터페이스 · 4.7.3 |
| `Core/GridPos.cs` | 4.3 구조체 · 4.7.2 Point 구조체 |
| (전 파일 `namespace`) | 4.4 네임스페이스 |
| `Player/Inventory.cs` | 4.5 인덱서 |
| `Core/Enums.cs` | 4.6 열거형 · 4.7.4 |
| `Items/ItemBase.cs` 및 하위 3종 | 4.7.1 Item 클래스 · 4.7.5 |
| `Items/ExitDoor.cs` | 4.2 · 4.6 |

## 4일차 — 5장 한 걸음 더

| 파일 | 담당 항목 |
| --- | --- |
| `Core/GameEvents.cs` | 5.2 static · 5.6 델리게이트와 이벤트 |
| `Core/SaveSystem.cs` | 5.1 문자열 · 5.4 파일스트림 · 5.5 예외 처리 |
| `Player/Inventory.cs` | 5.3 컬렉션과 제네릭 |
| `Core/GameManager.cs` | 5.2 static · 5.6 이벤트 |
| `UI/HUDController.cs` | 5.6 이벤트 · 5.7 람다식 |

## 5일차 — 5.8 종합 + 6 LINQ

| 파일 | 담당 항목 |
| --- | --- |
| `UI/HUDController.cs` `Core/GameManager.cs` | 5.8.1 UI와 GameManager |
| `Core/GameManager.cs` | 5.8.2 점수 기능 |
| `Enemies/MonsterSpawner.cs` | 5.8.3 Spawn 개선 |
| `Core/SaveSystem.cs` `Core/GameManager.cs` | 5.8.4 데이터 저장 |
| `Enemies/MonsterRadar.cs` | 6 LINQ |

---

## TODO를 찾는 방법

Visual Studio: `Ctrl+Shift+F` → `TODO [2.` 처럼 검색하면 그날 것만 나옵니다.
Rider: `Ctrl+Shift+F` 같음. 또는 하단 **TODO** 창.
