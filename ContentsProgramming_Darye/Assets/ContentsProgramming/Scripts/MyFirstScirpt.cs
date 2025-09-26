using UnityEngine;

public class VariablePractice : MonoBehaviour
{
    // 다양한 타입의 변수 선언
    public int playerLevel = 1;           // 플레이어 레벨
    public float walkSpeed = 5.0f;        // 걸음 속도
    public string playerName = "김철수";   // 플레이어 이름
    public bool canJump = true;           // 점프 가능 여부
    
    void Start()
    {
        // 변수 값 출력
        Debug.Log("플레이어 레벨: " + playerLevel);
        Debug.Log("걸음 속도: " + walkSpeed + "m/s");
        Debug.Log("플레이어 이름: " + playerName);
        Debug.Log("점프 가능: " + canJump);
    }
}