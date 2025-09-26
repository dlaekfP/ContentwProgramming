using UnityEngine;

public class TemperatureHeight : MonoBehaviour
{
    // 온도 변수 (Inspector에서 조절 가능)
    public float temperature = 25.0f;
    public float maxHeight = 3.0f;  // 최대 높이

    private Transform myTransform;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        float height = (temperature / 50.0f) * maxHeight;
        
        // Y축(세로) 크기만 변경
        transform.localScale = new Vector3(1, height, 1);
        
        // 결과 출력
        Debug.Log("온도 " + temperature + "도 → 높이 " + height);
    }
}