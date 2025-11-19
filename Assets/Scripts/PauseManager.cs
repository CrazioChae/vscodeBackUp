using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // 1. Inspector 창에서 연결할 비활성화된 패널
    public GameObject pauseMenuPanel; // 일시정지 패널
    private bool isPaused = false; // 일시정지 상태를 추적하는 변수

    void Start()
    {
        pauseMenuPanel?.SetActive(false); // 게임 시작 시 패널 비활성화
    }
    public void PauseGame() // 게임 일시정지 메서드
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true); // 패널 활성화
            Time.timeScale = 0f; // 게임 시간 정지
            isPaused = true; // 일시정지 상태로 설정
        }
    }
    public void ResumeGame() // 게임 재개 메서드
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false); // 패널 비활성화
            Time.timeScale = 1f; // 게임 시간 재개
            isPaused = false; // 일시정지 상태 해제
        }
    }
}
