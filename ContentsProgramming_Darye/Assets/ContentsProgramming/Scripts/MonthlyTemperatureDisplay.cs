using UnityEngine;

public class MonthlyTemperatureDisplay : MonoBehaviour
{
    [Header("12개월 평균 온도 데이터")]
    public float[] monthlyTemperatures = new float[12]
    {
        -2f,   // 1월
        0f,    // 2월
        7f,    // 3월
        14f,   // 4월
        20f,   // 5월
        25f,   // 6월
        28f,   // 7월
        27f,   // 8월
        22f,   // 9월
        15f,   // 10월
        7f,    // 11월
        -5f    // 12월
    };

    void Start()
    {
        for (int i = 0; i < monthlyTemperatures.Length; i++)
        {
            if (monthlyTemperatures[i] > 20f)
            {
                Debug.Log((i + 1) + "월은 평균 온도가" + monthlyTemperatures[i] + "도로, 따뜻한 달입니다.");
            }
        }
    }
}

    