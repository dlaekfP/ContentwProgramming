using UnityEngine;

public class TemperatureColor : MonoBehaviour
{
    public float temperature = 25.0f;
    public Color coldColor = Color.blue;
    public Color normalColor = Color.green;
    public Color hotColor = Color.red;
    private Renderer myRenderer;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        if (temperature < 15.0f)
        {
            myRenderer.material.color = coldColor;
            Debug.Log(temperature + "도: 차가워요! (파란색)");
        }
        else if (temperature < 25.0f)
        {
            myRenderer.material.color = normalColor;
            Debug.Log(temperature + "도: 적당해요! (녹색)");
        }
        else
        {
            myRenderer.material.color = hotColor;
            Debug.Log(temperature + "도: 뜨거워요! (빨간색)");
        }
    }

    void Update()
    {
         if (temperature < 15.0f)
        {
            myRenderer.material.color = coldColor;
            Debug.Log(temperature + "도: 차가워요! (파란색)");
        }
        else if (temperature < 25.0f)
        {
            myRenderer.material.color = normalColor;
            Debug.Log(temperature + "도: 적당해요! (녹색)");
        }
        else
        {
            myRenderer.material.color = hotColor;
            Debug.Log(temperature + "도: 뜨거워요! (빨간색)");
        }
    }
}
