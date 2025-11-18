using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{
    // OpenWeatherMap API 키 (여러분의 API 키로 교체하세요!)
    private const string API_KEY = "7b8cb0a50ce5e059e7fe34df8c815287";
    
    // API 엔드포인트 URL
    private const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather";
    
    public string cityName;

    void Start()
    {
        // 게임 시작 시 서울 날씨 가져오기
        // StartCoroutine(GetWeatherData(cityName));
    }
    
    public void GetWeahterDateBTTN(string cityName)
    {
         StartCoroutine(GetWeatherData(cityName));
    }
    // 날씨 데이터를 가져오는 코루틴
    IEnumerator GetWeatherData(string cityName)
    {
        // 1단계: URL 조합
        string url = $"{BASE_URL}?q={cityName}&appid={API_KEY}&units=metric&lang=kr";
        
        Debug.Log("📡 API 요청 시작: " + url);
        
        // 2단계: UnityWebRequest 생성 및 전송
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // 3단계: 응답 대기 (비동기)
            yield return request.SendWebRequest();
            
            // 4단계: 에러 체크
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("❌ API 호출 실패: " + request.error);
                yield break;  // 코루틴 종료
            }
            
            // 5단계: 응답 데이터 받기
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("✅ 응답 받음:\n" + jsonResponse);
            
            // 6단계: JSON을 C# 객체로 변환
            WeatherData weatherData = JsonUtility.FromJson<WeatherData>(jsonResponse);
            
            // 7단계: 데이터 출력
            Debug.Log("=== 날씨 정보 ===");
            Debug.Log($"🌡️ 도시: {weatherData.name}");
            Debug.Log($"🌡️ 현재 온도: {weatherData.main.temp}°C");
            Debug.Log($"🌡️ 체감 온도: {weatherData.main.feels_like}°C");
            Debug.Log($"🌡️ 최저 온도: {weatherData.main.temp_min}°C");
            Debug.Log($"🌡️ 최고 온도: {weatherData.main.temp_max}°C");
            Debug.Log($"💧 습도: {weatherData.main.humidity}%");
            Debug.Log($"☁️ 날씨: {weatherData.weather[0].description}");
        }
    }
}

// ========== JSON 데이터 클래스들 ==========

[System.Serializable]
public class WeatherData
{
    public Main main;           // 온도/습도 정보
    public Weather[] weather;   // 날씨 상태 (배열)
    public string name;         // 도시 이름
}

[System.Serializable]
public class Main
{
    public float temp;          // 현재 온도
    public float feels_like;    // 체감 온도
    public float temp_min;      // 최저 온도
    public float temp_max;      // 최고 온도
    public int humidity;        // 습도
}

[System.Serializable]
public class Weather
{
    public string main;         // 날씨 요약 (Clear, Clouds, Rain 등)
    public string description;  // 상세 설명 (맑음, 흐림, 비 등)
}