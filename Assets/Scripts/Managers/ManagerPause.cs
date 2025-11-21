using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SO.Managers
{
    public class ManagerPause : MonoBehaviour
    {
        // 1. 싱글톤 인스턴스
        public static ManagerPause Instance { get; private set; }
        // 2. 상태 변수: 일시정지 상태를 추적
        public bool IsPaused { get; private set; } = false;
        // 3. 상태 변경 이벤트: UI나 다른 시스템에 일시정지 상태 변경 알림
        public event Action<bool> OnPauseStateChanged;

        public GameObject pauseMenuPanel; // 일시정지 패널

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            // 씬 전환 시에도 파괴되지 않도록 설정
            // DontDestroyOnLoad(gameObject);
        }

        // 새로운 Input System의 Action에 연결할 메서드
        // Esc 키 또는 지정된 버튼을 눌렀을 때 호출
        public void OnPauseInput(InputValue inputValue){
            if (inputValue.isPressed)
            {
                if (IsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            if (IsPaused) return; // 이미 일시정지 상태이면 무시
            Time.timeScale = 0f; // 게임 시간 정지
            IsPaused = true; // 일시정지 상태로 설정
            OnPauseStateChanged?.Invoke(IsPaused); // 상태 변경 이벤트 호출
            Debug.Log("게임 일시정지됨");
        }

        public void ResumeGame() // 게임 재개 메서드
        {
            if (!IsPaused) return; // 이미 재개 상태이면 무시
            Time.timeScale = 1f; // 게임 시간 재개
            IsPaused = false; // 재개 상태로 설정
            OnPauseStateChanged?.Invoke(IsPaused); // 상태 변경 이벤트 호출
            Debug.Log("게임 재개됨");
        }
    }
}