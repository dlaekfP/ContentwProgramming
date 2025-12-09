using UnityEngine;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

// 범용 데이터 모델: 항목 이름(string)과 해당 비율(float)
public struct ParsedData
{
    public string ItemName; 
    public float Percentage; 
}

public class Csv : MonoBehaviour
{
    // --- Singleton 인스턴스 ---
    public static Csv Instance { get; private set; }

    // 파일 이름 상수 정의 (StreamingAssets 폴더에 있는 파일 이름과 동일해야 합니다)
    private const string CLASSICAL_INTENTION_FILE = "ClassicalIntention.csv"; 
    private const string POP_INTENTION_FILE = "PopIntention.csv";
    private const string BARRIER_FILE = "Barriers.csv";

    // 파싱된 데이터를 저장할 리스트 (public 속성으로 다른 스크립트에서 접근 가능)
    public List<ParsedData> ClassicalIntentionData { get; private set; } = new List<ParsedData>();
    public List<ParsedData> PopIntentionData { get; private set; } = new List<ParsedData>();
    public List<ParsedData> BarrierData { get; private set; } = new List<ParsedData>();

    // Start()보다 먼저 실행되어 데이터 파싱을 완료합니다.
    void Awake()
    {
        // --- Singleton 초기화 ---
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // -------------------------

        // 파일 로드 및 파싱 실행
        ClassicalIntentionData = ParseIntentionData(CLASSICAL_INTENTION_FILE);
        PopIntentionData = ParseIntentionData(POP_INTENTION_FILE);
        BarrierData = ParseBarrierData(BARRIER_FILE);

        Debug.Log($"[Parser] 모든 데이터 파싱 완료. 클래식 의향 데이터 수: {ClassicalIntentionData.Count}");
    }

    private string ReadFileContent(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (!File.Exists(filePath))
        {
            Debug.LogError($"CSV 파일을 찾을 수 없습니다: {filePath}");
            return null;
        }
        
        return File.ReadAllText(filePath, Encoding.UTF8);
    }

    // 관람 의향 데이터 파싱 로직 (세 번째 행의 세 번째, 네 번째 열 추출)
    private List<ParsedData> ParseIntentionData(string fileName)
    {
        List<ParsedData> list = new List<ParsedData>();
        string csvText = ReadFileContent(fileName);
        if (csvText == null) return list;

        string[] lines = csvText.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        
        if (lines.Length < 3) return list;

        string dataLine = lines[2].Trim();
        string[] values = dataLine.Split(',');
        
        if (values.Length >= 4)
        {
            // '있다' (관람 의향)은 인덱스 2
            if (float.TryParse(values[2].Trim(), out float percentageYes))
            {
                list.Add(new ParsedData { ItemName = "있다", Percentage = percentageYes });
            }

            // '없다' (관람 비의향)은 인덱스 3
            if (float.TryParse(values[3].Trim(), out float percentageNo))
            {
                list.Add(new ParsedData { ItemName = "없다", Percentage = percentageNo });
            }
        }
        return list;
    }

    // 관람 걸림돌 데이터 파싱 로직 (9개 항목을 가로로 추출)
    private List<ParsedData> ParseBarrierData(string fileName)
    {
        List<ParsedData> list = new List<ParsedData>();
        string csvText = ReadFileContent(fileName);
        if (csvText == null) return list;

        string[] lines = csvText.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        
        if (lines.Length < 3) return list;

        // 두 번째 행(인덱스 1)에서 항목 이름 추출
        string[] itemNames = lines[1].Split(','); 
        // 세 번째 행(인덱스 2)에서 비율 추출
        string[] percentages = lines[2].Split(','); 

        const int START_INDEX = 2; // 데이터가 시작되는 열 인덱스
        const int BARRIER_COUNT = 9; // 장애 요인 항목 개수

        if (itemNames.Length < START_INDEX + BARRIER_COUNT || percentages.Length < START_INDEX + BARRIER_COUNT)
        {
            Debug.LogError($"파일 '{fileName}'의 열 개수가 충분하지 않습니다.");
            return list;
        }
        
        for (int i = 0; i < BARRIER_COUNT; i++)
        {
            string itemName = itemNames[START_INDEX + i].Trim();
            string percentageStr = percentages[START_INDEX + i].Trim();

            if (!string.IsNullOrEmpty(itemName) && float.TryParse(percentageStr, out float percentageValue))
            {
                list.Add(new ParsedData { ItemName = itemName, Percentage = percentageValue });
            }
        }
        return list;
    }
}