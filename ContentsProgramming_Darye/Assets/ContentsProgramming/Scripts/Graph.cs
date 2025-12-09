using UnityEngine;
using UnityEngine.UI; 
using System.Linq; 
using TMPro; // TextMeshPro 텍스트 컴포넌트를 사용하기 위해 필요

public class Graph : MonoBehaviour
{
    // --- 1. 그래프 UI 참조 ---
    public Image ClassicLikeGraph;
    public Image ClassiceHateGraph;
    public Image POPLikeGraph;
    public Image POPHateGraph;

    // --- 2. 텍스트 UI 참조 ---
    public TextMeshProUGUI ClassicLikeText;
    public TextMeshProUGUI ClassiceHateText;
    public TextMeshProUGUI POPLikeText;
    public TextMeshProUGUI POPHateText;


    void Start()
    {
        if (Csv.Instance == null)
        {
            Debug.LogError("CsvDataParser (Singleton)가 씬에 없습니다! 스크립트가 붙은 오브젝트를 확인하세요.");
            return;
        }

        // 1. 파싱된 데이터로 그래프와 텍스트를 채웁니다.
        FillGraphsAndTexts();
        
        // 2. 초기 상태: Like Graph(있다)만 보이게 설정 (false 전달)
        // SetGraphVisibility(true) -> Hate 먼저
        // SetGraphVisibility(false) -> Like 먼저 (수정됨)
        SetGraphVisibility(false); 
    }

    /// <summary>
    /// 버튼에 연결하여 그래프의 시각적 상태를 전환합니다. (Like -> Hate 로 전환)
    /// </summary>
    public void ToggleToHateGraph() // <--- 함수 이름 변경 (버튼 이벤트 재연결 필요)
    {
        // Hate 그래프를 보이게 설정 (true 전달)
        SetGraphVisibility(true); 
    }
    
    /// <summary>
    /// 그래프의 보이는 상태를 설정합니다.
    /// (텍스트 컴포넌트가 Image 컴포넌트의 자식이라고 가정합니다.)
    /// </summary>
    private void SetGraphVisibility(bool showHate)
    {
        // Image의 SetActive()만 호출합니다.
        
        // Hate Graph (Image) 토글
        ClassiceHateGraph.gameObject.SetActive(showHate);
        POPHateGraph.gameObject.SetActive(showHate);
        
        // Like Graph (Image) 토글
        ClassicLikeGraph.gameObject.SetActive(!showHate);
        POPLikeGraph.gameObject.SetActive(!showHate);
        
        Debug.Log(showHate ? "Hate Graph가 표시되었습니다." : "Like Graph가 표시되었습니다.");
    }

    /// <summary>
    /// 파싱된 데이터를 사용하여 UI Image의 Fill Amount와 Text를 설정합니다.
    /// </summary>
    private void FillGraphsAndTexts()
    {
        var parser = Csv.Instance;

        if (parser.ClassicalIntentionData.Count < 2 || parser.PopIntentionData.Count < 2) 
        {
             Debug.LogWarning("필요한 데이터(있다/없다)가 부족합니다.");
             return;
        }

        // --- 클래식 의향 데이터 처리 ---
        var classicLikeData = parser.ClassicalIntentionData.Find(d => d.ItemName.Contains("있다"));
        var classicHateData = parser.ClassicalIntentionData.Find(d => d.ItemName.Contains("없다"));
        
        ClassicLikeGraph.fillAmount = classicLikeData.Percentage / 100f;
        ClassiceHateGraph.fillAmount = classicHateData.Percentage / 100f;
        ClassicLikeText.text = $"{classicLikeData.Percentage:F1}%";
        ClassiceHateText.text = $"{classicHateData.Percentage:F1}%";


        // --- 대중음악 의향 데이터 처리 ---
        var popLikeData = parser.PopIntentionData.Find(d => d.ItemName.Contains("있다"));
        var popHateData = parser.PopIntentionData.Find(d => d.ItemName.Contains("없다"));

        POPLikeGraph.fillAmount = popLikeData.Percentage / 100f;
        POPHateGraph.fillAmount = popHateData.Percentage / 100f;
        POPLikeText.text = $"{popLikeData.Percentage:F1}%";
        POPHateText.text = $"{popHateData.Percentage:F1}%";
        
        // UI 업데이트 강제화
        Canvas.ForceUpdateCanvases();
    }
}