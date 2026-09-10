# 커밋 규약

커밋 하나 = 커리큘럼 소단원 하나. 히스토리 자체가 학습 기록이 되고,
`git diff`로 "이 문법을 배우기 전과 후"를 그대로 되돌려 볼 수 있습니다.

## 형식

```
<타입>(<소단원 번호>): <무엇을 했는지 한 줄>

- 왜 이렇게 했는지 / 막혔던 지점 (선택, 1~3줄)
```

| 타입 | 쓰는 경우 |
| --- | --- |
| `feat` | TODO를 채워 기능이 새로 동작하게 됨 — 대부분 이것 |
| `refactor` | 동작은 그대로인데 구조를 바꿈 (4.1 abstract 전환, 4.4 네임스페이스 분리) |
| `fix` | 앞 커밋의 버그를 고침 |
| `docs` | README·위키·주석만 바뀜 |
| `chore` | 프로젝트 설정, 패키지, .gitignore |

### 예시

```
feat(2.3): 형변환 — HpRatio가 0/1이 아닌 비율을 반환

int / int 결과가 정수라 게이지가 항상 0이거나 1이었다.
분자를 float으로 캐스팅해 해결.
```

```
refactor(4.1): 추상 클래스 — MonsterBase를 abstract로 전환

Behave()를 abstract로 바꾸니 Stalker·Wanderer가 반드시
구현하도록 컴파일러가 강제한다. 씬에 MonsterBase를 직접
붙이는 실수도 막힌다.
```

## 커밋 계획 — 42개

체크하며 진행하세요. 하루가 끝나면 그날 커밋이 전부 있는지 확인합니다.

### 1일차 · 09.16 (수) · 02장 C# 기초 문법

- [ ] `chore: 프로젝트 초기화 — 스크립트 골격과 폴더 구조`
- [ ] `docs(2.1): 토큰과 코드 작성 — 씬 구성과 Player 오브젝트`
- [ ] `feat(2.2): 변수와 자료형 — PlayerStats 능력치 정의`
- [ ] `feat(2.3): 형변환 — HpRatio 비율 계산`
- [ ] `feat(2.4): 배열 — 손전등 부채꼴 탐색`
- [ ] `feat(2.5): 연산자 — 피해·회복·배터리 소모`
- [ ] `feat(2.6): 제어문 — 배터리 고갈과 공포 누적`
- [ ] `feat(2.7.1): 플레이어 게임 오브젝트`
- [ ] `feat(2.7.2): 플레이어의 이동`
- [ ] `feat(2.7.3): 플레이어의 공격 — 손전등 섬광`
- [ ] `feat(2.7.4): Input System 바인딩 정리`

### 2일차 · 09.17 (목) · 03장 클래스

- [ ] `feat(3.1): 추상화 — MonsterBase 공통 구조`
- [ ] `feat(3.2): 캡슐화 — 몬스터 상태 읽기 전용 공개`
- [ ] `feat(3.3): 상속 — Stalker·Wanderer 고유 능력치`
- [ ] `feat(3.4): 다형성 — Behave 오버라이드로 행동 분기`
- [ ] `feat(3.5.1): Enemy 클래스 생성`
- [ ] `feat(3.5.2): Enemy 객체 생성 — MonsterSpawner`
- [ ] `feat(3.5.3): 적군의 피격 — 충돌 피해와 쿨다운`
- [ ] `feat(3.5.4): 상속으로 적군 종류 추가`
- [ ] `feat(3.5.5): 오버라이드·오버로드 — Stun과 넉백`

### 3일차 · 09.18 (금) · 04장 클래스의 응용

- [ ] `refactor(4.1): 추상 클래스 — MonsterBase abstract 전환`
- [ ] `feat(4.2): 인터페이스 — IInteractable 상호작용`
- [ ] `feat(4.3): 구조체 — GridPos 값 형식`
- [ ] `refactor(4.4): 네임스페이스 — Core·Enemies·Items 분리`
- [ ] `feat(4.5): 인덱서 — Inventory 배열처럼 접근`
- [ ] `feat(4.6): 열거형 — ItemType·MonsterState·DoorState`
- [ ] `feat(4.7.1): Item 클래스`
- [ ] `feat(4.7.2): Point 구조체 활용`
- [ ] `feat(4.7.3): IEffect 인터페이스`
- [ ] `feat(4.7.4): Items 열거형 확장`
- [ ] `feat(4.7.5): Player·Enemy·Item 통합 — 열쇠와 출구`

### 4일차 · 09.21 (월) · 05장 한 걸음 더

- [ ] `feat(5.1): 문자열 다루기 — 상호작용 문구와 저장 기록`
- [ ] `feat(5.2): static — GameManager 싱글턴`
- [ ] `feat(5.3): 컬렉션과 제네릭 — 인벤토리와 몬스터 목록`
- [ ] `feat(5.4): 파일스트림 — 세이브 저장과 불러오기`
- [ ] `feat(5.5): 예외 처리 — 손상된 세이브 파일 방어`
- [ ] `feat(5.6): 델리게이트와 이벤트 — GameEvents 방송`
- [ ] `feat(5.7): 익명 메서드와 람다식 — HUD 엔딩 구독`

### 5일차 · 09.22 (화) · 5.8 종합 + 06 LINQ

- [ ] `feat(5.8.1): UI와 GameManager 연결`
- [ ] `feat(5.8.2): static·이벤트를 이용한 점수 기능`
- [ ] `feat(5.8.3): Enemy Spawn 개선 — 목록 정리와 웨이브`
- [ ] `feat(5.8.4): 게임 데이터 저장 연결`
- [ ] `feat(6): LINQ — 몬스터 탐색과 위협 요약`

## 시작하기

프로젝트 폴더에서 한 번만:

```bash
git init
git add .
git commit -m "chore: 프로젝트 초기화 — 스크립트 골격과 폴더 구조"
git branch -M main
git remote add origin <저장소 주소>
git push -u origin main
```

이후 소단원 하나를 끝낼 때마다:

```bash
git add -A
git commit -m "feat(2.3): 형변환 — HpRatio 비율 계산"
```

## Claude Code로 돌릴 때

프로젝트 폴더에서 `claude`를 실행하고, 소단원 단위로 이렇게 요청합니다.

```
COMMITS.md의 2.3 항목을 진행해줘.
PlayerStats.cs의 TODO [2.3]만 채우고, 왜 int 나눗셈이 문제인지
먼저 설명한 다음 고쳐줘. 끝나면 규약에 맞춰 커밋해줘.
```

**먼저 스스로 채워 보고, 막힌 뒤에 물어보세요.** 답을 받아 커밋한 히스토리는
포트폴리오에서 근거가 되지 못합니다. 막힌 지점과 해결 과정이 남은 히스토리가
「문제 해결」 절의 재료가 됩니다.
