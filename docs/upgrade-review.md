# 예제 프로젝트 업그레이드 검토

**검토 대상** · 「처음 배우는 C# 프로그래밍」 교재의 슈팅 게임 예제
**기준 환경** · Unity 6000.6.0f1 · Input System 1.20.0 · URP 17.6
**작성 시점** · 2026.09.10

교재 예제는 유니티 구버전 기준으로 쓰여 있습니다. 그대로 따라 치면 동작은 하지만,
경고가 뜨거나 나중에 고쳐야 할 습관이 남습니다. 어디를 어떻게 올릴지 정리했습니다.

---

## 01. 요약

| 구분 | 항목 수 | 판단 |
| --- | --- | --- |
| **적용** — 이번 실습에 반영 | 6 | 지금 안 바꾸면 습관으로 굳음 |
| **보류** — 알아만 두기 | 4 | 이번 규모에선 이득이 없음 |
| **비적용** — 교재대로 | 2 | 학습 목적이 그 방식 자체 |

---

## 02. 적용 — 이번 실습에 반영

### 02-1. 입력 · Input Manager → Input System

| | |
| --- | --- |
| **교재** | `Input.GetAxis("Horizontal")` · `Input.GetKeyDown(KeyCode.Space)` |
| **Unity 6** | `InputAction` · `moveAction.ReadValue<Vector2>()` |
| **이유** | 구버전 Input Manager는 게임패드·모바일·리바인딩을 못 다룹니다. Unity 6 신규 프로젝트는 Input System이 기본입니다. |
| **적용** | `PlayerController`에서 바인딩을 **코드로** 생성 — 액션 에셋 없이 Input System을 익히도록 |

```csharp
// 교재
float h = Input.GetAxis("Horizontal");

// 적용
moveAction = new InputAction("Move", InputActionType.Value, expectedControlType: "Vector2");
moveAction.AddCompositeBinding("2DVector")
    .With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
    .With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
```

> ⚠️ `Player > Active Input Handling`을 `Both`로 두어야 합니다. 안 그러면 런타임에 예외가 납니다.

### 02-2. 물리 · velocity → linearVelocity

| | |
| --- | --- |
| **교재** | `rb.velocity = dir * speed;` · `rb.drag` |
| **Unity 6** | `rb.linearVelocity` · `rb.linearDamping` · `rb.angularDamping` |
| **이유** | Unity 6에서 물리 용어를 명확히 하려고 이름이 바뀌었습니다. 각속도와 구분됩니다. |
| **적용** | 전 스크립트에서 `linearVelocity` 사용 |

### 02-3. 객체 탐색 · FindObjectOfType → FindFirstObjectByType

| | |
| --- | --- |
| **교재** | `FindObjectOfType<GameManager>()` · `FindObjectsOfType<Enemy>()` |
| **Unity 6** | `FindFirstObjectByType<T>()` · `FindAnyObjectByType<T>()` · `FindObjectsByType<T>(FindObjectsSortMode.None)` |
| **이유** | 옛 API는 결과를 항상 정렬해서 반환합니다. 정렬이 필요 없는데도 비용을 냅니다. `FindAnyObjectByType`은 "아무거나 하나"라 더 빠릅니다. |
| **적용** | 필요한 곳에서 새 API 사용. 단 **어느 쪽이든 매 프레임 부르면 안 됩니다** — `Awake`에서 한 번 찾아 캐싱 |

### 02-4. UI 텍스트 · Text → TextMeshPro

| | |
| --- | --- |
| **교재** | `UnityEngine.UI.Text` |
| **Unity 6** | `TMP_Text` (TextMeshPro) |
| **이유** | 레거시 `Text`는 확대하면 뭉개집니다. TMP는 SDF 방식이라 어느 크기에서도 선명하고, **한글 폰트 폴백**도 TMP에서만 제대로 됩니다. |
| **적용** | `HUDController`는 우선 `Text`로 시작 → 4일차 UI 작업 때 TMP로 교체 |

> 한글을 쓸 거면 TMP Font Asset을 만들 때 **Character Set을 Unicode Range**로 잡고
> 완성형 한글 범위(`AC00-D7A3`)를 넣어야 합니다. Dynamic으로 두면 처음 뜨는 글자마다 끊깁니다.

### 02-5. 상태 갱신 · 폴링 → 이벤트

| | |
| --- | --- |
| **교재** | `Update()`에서 매 프레임 `hpText.text = hp.ToString();` |
| **Unity 6** | 값이 바뀔 때만 `event`로 방송 |
| **이유** | 성능보다 **구조** 문제입니다. 폴링은 UI가 플레이어를 알아야 하고, 이벤트는 서로 몰라도 됩니다. |
| **적용** | `GameEvents` · `HUDController`에 `Update()`가 아예 없음 — 5.6 학습과 정확히 겹침 |

### 02-6. 물리 질의 · 배열 할당 → 리스트 재사용

| | |
| --- | --- |
| **교재** | `Physics2D.OverlapCircleAll(pos, r)` |
| **Unity 6** | `Physics2D.OverlapCircle(pos, r, filter, results)` — `List<Collider2D>` 재사용 |
| **이유** | `~All`은 호출할 때마다 배열을 새로 만듭니다. 매 프레임 돌면 GC가 계속 돕니다. |
| **적용** | 학습 단계에서는 `~All`로 시작(읽기 쉬움) → 5일차 최적화에서 교체하며 차이를 측정 |

---

## 03. 보류 — 알아만 두기

| 항목 | 교재 방식 | 현대적 방식 | 왜 보류하나 |
| --- | --- | --- | --- |
| 코루틴 | `StartCoroutine` + `yield return new WaitForSeconds` | `Awaitable` / `async`-`await` | 5일 과정에 `async` 개념까지 얹으면 과부하. 단 `new WaitForSeconds`를 매번 만들지 말고 **필드에 캐싱**하는 습관은 지금 들일 것 |
| 저장 | `PlayerPrefs` | JSON 파일 (`SaveSystem`) | 이 프로젝트는 이미 JSON. `PlayerPrefs`는 설정값 정도에만 |
| 리소스 로딩 | `Resources.Load` | Addressables | 씬 하나짜리 규모에선 Addressables 설정 비용이 더 큼 |
| UI 프레임워크 | uGUI (Canvas) | UI Toolkit | 교재·강의가 uGUI 기준. 게임 런타임 UI는 아직 uGUI가 무난 |

---

## 04. 비적용 — 교재대로 간다

| 항목 | 판단 |
| --- | --- |
| `GameObject.FindGameObjectWithTag` | 더 나은 방법(인스펙터 참조 주입)이 있지만, **태그 개념을 먼저 배우는 것**이 커리큘럼 의도. `Awake`에서 한 번만 부르는 선에서 유지 |
| 싱글턴 `GameManager.Instance` | 안티패턴이라는 비판이 있지만 5.2 static 학습의 핵심 예제. 대신 "정말 하나뿐인가"를 묻는 습관을 같이 |

---

## 05. 적용 순서

업그레이드는 커리큘럼 진행과 자연스럽게 겹치게 배치했습니다. 따로 시간을 낼 필요가 없습니다.

| 차시 | 함께 적용할 항목 |
| --- | --- |
| 1일차 | 02-1 Input System · 02-2 linearVelocity |
| 2일차 | 02-3 객체 탐색 캐싱 |
| 4일차 | 02-4 TextMeshPro · 02-5 이벤트 기반 UI |
| 5일차 | 02-6 물리 질의 최적화 (전후 프로파일러 수치 기록) |

5일차의 측정 결과는 포트폴리오 「최적화 및 검증」 절에 그대로 들어갑니다.
**"최적화했다"가 아니라 측정 조건과 전후 수치**를 남기세요.
