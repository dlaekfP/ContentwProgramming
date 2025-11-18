using UnityEngine;
using System.Collections;

public class MyCoroutine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MyCoroutineMethod());
    }

    // 코루틴 선언 (IEnumerator 반환 타입)
    IEnumerator MyCoroutineMethod()
    {
        Debug.Log("시작");

        yield return new WaitForSeconds(2f);  // 2초 대기

        Debug.Log("2초 후 실행");
    }

}
