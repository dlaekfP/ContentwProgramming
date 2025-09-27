using UnityEngine;

public class TemperatureColor : MonoBehaviour
{
    public float temperature = 25.0f;
    public Color coldColor = Color.blue;
    public Color normalColor = Color.green;
    public Color hotColor = Color.red;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (temperature < 15.0f)
        {
            renderer.material.color = coldColor;
            Debug.Log(temperature + "도: 차가워요! (파란색)");
        }
        else if (temperature < 30.0f)
        {
            renderer.material.color = normalColor;
            Debug.Log(temperature + "도: 적당해요! (녹색)");
        }
        else
        {
            renderer.material.color = hotColor;
            Debug.Log(temperature + "도: 뜨거워요! (빨간색)");
        }
    }
}
