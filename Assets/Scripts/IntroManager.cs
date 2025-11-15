using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 인트로 장면 데이터(대사, 배경 이미지)를 저장하는 클래스
[System.Serializable]
public class IntroSceneData
{
    public Sprite backgroundImage; // 인트로 장면의 배경 이미지 (스프라이트로 저장)
    [TextArea(3, 10)] //인스펙터 창에서 텍스트를 여러 줄로 입력하게 해줌
    public string storyText; // 표시할 스토리 텍스트
}
public class IntroManager : MonoBehaviour // 인트로 장면을 관리하는 매니저 클래스
{
    [Header("UI Components")]
    public Image backgroundImage; // 배경 이미지를 표시할 UI 컴포넌트
    public TextMeshProUGUI storyText; // 스토리 텍스트를 표시할 UI 컴포넌트

    [Header("Intro Data")]
    public IntroSceneData[] introScenes; // 인트로 장면 데이터 배열
    public string nextSceneName = "MainScene"; // 다음 장면 이름

    [Header("Settings")]
    [SerializeField] private int currentSceneIndex = 0; // 현재 인트로 장면 인덱스
    [Range(0f, 2f)] public float transitionDuration = 0.5f; // 장면 전환 지속 시간

    [Header("Audio")]
    public AudioClip bgmPlayer; // 인트로 음악 클립
    public AudioSource bgmClip; // 인트로 음악 재생용 오디오 소스

    private void Start()
    {
        // 인트로 음악 재생
        if (bgmPlayer != null && bgmClip != null)
        {
            bgmClip.clip = bgmPlayer;
            bgmClip.loop = true;
            bgmClip.Play();
        }

        // 첫 번째 인트로 장면 설정
        ShowScene(currentSceneIndex);
    }
    
    void Update() // 매 프레임마다 호출되는 업데이트 메서드
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) // 마우스 클릭 또는 스페이스바 입력 감지
        {
            GoToNextScene(); // 다음 인트로 장면으로 이동
        }
    }

    private void ShowScene(int sceneIndex) // 특정 인트로 장면을 화면에 표시하는 메서드
    {
        if (sceneIndex >= 0 && sceneIndex < introScenes.Length) // 유효한 인덱스인지 확인
        {
            // 배경 이미지와 스토리 텍스트 업데이트
            backgroundImage.sprite = introScenes[sceneIndex].backgroundImage;
            storyText.text = introScenes[sceneIndex].storyText; 
        }
    }

    void GoToNextScene() // 다음 인트로 장면으로 이동하는 메서드
    {
        currentSceneIndex++; // 다음 인트로 장면으로 이동
        if (currentSceneIndex < introScenes.Length) // 아직 인트로 장면이 남아있는 경우
        {
            ShowScene(currentSceneIndex); // 다음 장면 표시
        }
        else
        {
            // 모든 인트로 장면이 끝나면 다음 씬으로 전환
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}


