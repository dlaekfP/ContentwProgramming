using System;
using UnityEngine;

public class Myarray : MonoBehaviour
{
    public float[] monthlyTemps = new float[12]
    {
        -2f, 0f, 7f, 14f, 20f, 25f,
        28f, 27f, 22f, 15f, 7f, -5f
    };

    void Start()
    {
        for (int i = 0; i < monthlyTemps.Length; i++)
        {
            Debug.Log(( i + 1 ) + "월 온도는" + monthlyTemps[i] + "도 입니다.");
        }
    }
}
