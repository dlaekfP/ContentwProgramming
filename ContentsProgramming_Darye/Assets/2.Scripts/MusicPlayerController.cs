using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    private AudioSource audioSource; // 삭제하지 말 것
    // 아래에 필요한 변수를 추가할 수 있습니다
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // 삭제하지 말 것
        // 아래에 기능 추가
    }

    void Update()
    {

    }

    public void PlayMusic()
    {
        audioSource.Play(); // 삭제하지 말 것
        // 아래에 기능 추가
    }

    public void StopMusic()
    {
        audioSource.Stop(); // 삭제하지 말 것
        // 아래에 기능 추가
    }
}
