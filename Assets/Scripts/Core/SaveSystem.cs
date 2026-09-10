using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HorrorEscape
{
    // ─────────────────────────────────────────────────────────────
    // 4일차 [5.4 파일스트림] [5.5 예외 처리] [5.1 문자열 다루기]
    //       [5.8.4 게임 데이터 저장]
    //
    // 세이브 파일은 언제든 깨질 수 있습니다.
    //   - 저장 도중 게임이 꺼짐
    //   - 사용자가 메모장으로 열어서 고침
    //   - 파일이 아예 없음
    //
    // 그래서 파일 다루기와 예외 처리는 같이 배웁니다.
    // ─────────────────────────────────────────────────────────────

    [Serializable]
    public class SaveData
    {
        public int hp;
        public float battery;
        public float survivedSeconds;
        public int keyCount;
        public List<ItemType> items = new List<ItemType>();
        public string savedAtIso = "";
    }

    public static class SaveSystem
    {
        private const string FileName = "lastnight.save.json";

        // Application.persistentDataPath 는 OS마다 알아서 안전한 위치를 잡아 줍니다.
        private static string FilePath => Path.Combine(Application.persistentDataPath, FileName);

        public static void Save(SaveData data)
        {
            // TODO [5.5 예외 처리] 아래 코드를 try - catch 로 감싸세요.
            //   IOException 과 UnauthorizedAccessException 을 각각 잡고,
            //   실패해도 게임이 멈추지 않게 Debug.LogError 만 남기세요.
            //
            // TODO [5.4 파일스트림] JSON으로 바꿔 파일에 쓰세요.
            // 힌트:
            //   data.savedAtIso = DateTime.Now.ToString("o");
            //   string json = JsonUtility.ToJson(data, true);
            //   File.WriteAllText(FilePath, json);

            Debug.Log($"[SaveSystem] 저장 위치: {FilePath}");
        }

        public static SaveData Load()
        {
            // TODO [5.5 예외 처리] + [5.4 파일스트림]
            //   1) 파일이 없으면 (File.Exists) 새 SaveData를 반환합니다.
            //   2) 있으면 읽어서 JsonUtility.FromJson<SaveData>(json) 으로 되돌립니다.
            //   3) 내용이 깨져 있으면 예외가 납니다. 잡아서 새 SaveData를 반환하세요.
            //
            // 힌트:
            //   try { ... }
            //   catch (Exception e) { Debug.LogWarning($"세이브 손상: {e.Message}"); return new SaveData(); }

            return new SaveData();
        }

        public static void Delete()
        {
            // TODO [5.5 예외 처리] 파일이 있으면 지우되, 실패해도 게임이 죽지 않게 하세요.
        }

        /// <summary>[5.1 문자열 다루기] 저장 시각을 사람이 읽는 형태로.</summary>
        public static string Describe(SaveData data)
        {
            if (data == null || string.IsNullOrEmpty(data.savedAtIso))
                return "저장된 기록 없음";

            // TODO [5.1 문자열 다루기]
            //   savedAtIso를 DateTime으로 파싱해서 "09월 16일 21:34 · 3분 12초 생존" 형태로 만드세요.
            // 힌트: DateTime.TryParse(data.savedAtIso, out var t)
            //       $"{t:MM월 dd일 HH:mm}"
            //       TimeSpan.FromSeconds(data.survivedSeconds)

            return data.savedAtIso;
        }
    }
}
