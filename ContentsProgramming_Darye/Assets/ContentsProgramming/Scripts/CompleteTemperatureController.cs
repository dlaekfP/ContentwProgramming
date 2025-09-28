using UnityEngine;

public class TemperatureBar : MonoBehaviour
{
    [Header("온도 설정")]
    public float temperature = 30.0f;   // 온도
    public float maxHeight = 10.0f;      // 최대 높이

    private Renderer barRenderer;

    void Start()
    {
        barRenderer = GetComponent<Renderer>();
        if (barRenderer == null)
        {
            Debug.LogError("이 오브젝트에는 Renderer가 없습니다!");
        }
    }

    void Update()
    {
        // 길이 조절 (Pivot 중앙 → 위로 자라게 위치 보정)
        float height = Mathf.Clamp(temperature / 50.0f * maxHeight, 0.1f, maxHeight);
        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, height / 2f, transform.localPosition.z);

        // 색상 조절
        if (barRenderer != null)
        {
            if (temperature < 15.0f)
                barRenderer.material.color = Color.blue;
            else if (temperature < 25.0f)
                barRenderer.material.color = Color.green;
            else
                barRenderer.material.color = Color.red;
        }
    }
}
