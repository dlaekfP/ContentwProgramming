using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindController : MonoBehaviour
{
    [Header("풍속 Toggle")]
    public Toggle windToggle;

    [Header("풍속 Panel")]
    public GameObject windPanel;

    [Header("풍속 슬라이더")]
    public Slider windSlider;

    [Header("풍속 텍스트")]
    public TextMeshProUGUI windText;

    void Start()
    {
        // 초기 상태: 패널 숨김
        windPanel.SetActive(false);

        Debug.Log("풍속 제어 시스템 초기화 완료!");
    }

    // ========== Toggle 이벤트 처리 ==========

    public void OnWindToggled(bool isOn)
    {
        // 토글 상태에 따라 패널 표시/숨김
        windPanel.SetActive(isOn);

        if (isOn)
        {
            Debug.Log("풍속 정보 표시");
        }
        else
        {
            Debug.Log("풍속 정보 숨김");
        }
    }

    // ========== Slider 이벤트 처리 ==========

    public void OnWindChanged(float value)
    {
        // 풍속 값을 m/s 단위로 표시 (F1 = 소수점 1자리)
        windText.text = value.ToString("F1") + " m/s";
    }
}