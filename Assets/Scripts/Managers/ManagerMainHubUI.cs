using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SO.Managers
{
    public class ManagerMainHubUI : MonoBehaviour
    {
        // --- 상단 메뉴 ---    
        public Button dataButton;
        public Button pauseButton;

        // --- Pause 패널 ---
        public GameObject pauseMenuPanel; // 일시정지 패널
        public Button resumeButton; // 재개 버튼
        public Button configButton; // 설정 패널 버튼
        public Button goToTitleButton; // 타이틀로 이동 버튼
        public Button quitTheGameButton; // 게임 종료 버튼

        // --- Data 패널 ---
        public GameObject dataMenuPanel; // 데이터 패널
        public Button saveButton; // 저장 버튼
        public Button loadButton; // 불러오기 버튼
        public Button dataMenuPanelCloseButton; // 데이터 패널 닫기 버튼

        // --- Config 패널 ---
        public GameObject configMenuPanel; // 설정 패널
        public Button configMenuPanelCloseButton; // 설정 패널 닫기 버튼

        // --- 메인 행동 버튼 ---
        public Button enterTowerButton; // 탐험 버튼
        public Button soldierMenuButton; // 인벤토리 버튼
        public Button heroMenuButton; // 설정 버튼

        // --- 스토리 UI ---
        public Image characterImage;
        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI characterNameText;

        private void Start()
        {
            // 일시정지 패널 초기화
            pauseMenuPanel?.SetActive(false); // 게임 시작 시 일시정지 패널 비활성화
            dataMenuPanel?.SetActive(false); // 게임 시작 시 데이터 패널 비활성화
            configMenuPanel?.SetActive(false); // 게임 시작 시 설정 패널 비활성화

            // 메인 행동 버튼 리스너 설정
            pauseButton.onClick.AddListener(ManagerPause.Instance.PauseGame);
            dataButton.onClick.AddListener(OpenDataPanel);
            enterTowerButton.onClick.AddListener(EnterTower);
            // soldierMenuButton.onClick.AddListener(OpenSoldierMenu); // 추후 구현
            // heroMenuButton.onClick.AddListener(OpenHeroMenu); // 추후 구현

            // 일시정지 패널 버튼 리스너 설정
            resumeButton.onClick.AddListener(ManagerPause.Instance.ResumeGame);
            configButton.onClick.AddListener(OpenConfigPanel);
            goToTitleButton.onClick.AddListener(GoToTitleScene);
            quitTheGameButton.onClick.AddListener(QuitTheGame);

            // 데이터 패널 버튼 리스너 설정
            dataMenuPanelCloseButton.onClick.AddListener(CloseDataPanel);
            saveButton.onClick.AddListener(SaveGame);
            loadButton.onClick.AddListener(LoadGame);

            // 설정 패널 버튼 리스너 설정
            configMenuPanelCloseButton.onClick.AddListener(CloseConfigPanel);

        }
        void OnEnable()
        {
            ManagerPause.Instance.OnPauseStateChanged += OnPauseToggle;
        }
        void OnDisable()
        {
            ManagerPause.Instance.OnPauseStateChanged -= OnPauseToggle;
        }

        private void OnPauseToggle(bool isPaused)
        {
            if (pauseMenuPanel != null)
            {
                // 일시정지 상태에 따라 패널 활성화/비활성화
                pauseMenuPanel.SetActive(isPaused);
            }
        }

        private void GoToTitleScene()
        {
            Time.timeScale = 1f; // 게임 시간 재개
            SceneManager.LoadScene("TitleScene"); // 타이틀 장면으로 이동
        }
        private void EnterTower()
        {
            // 탐험 버튼 클릭 시 처리할 로직 추가
            Debug.Log("탑 탐험 시작!");
            Time.timeScale = 1f; // 게임 시간 재개
            SceneManager.LoadScene("EnterTowerScene"); // 탐험 장면으로 이동
        }
        private void QuitTheGame()
        {
            Debug.Log("게임 종료!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit(); 
#endif
        }


        private void OpenDataPanel()
        {
            if (dataMenuPanel != null)
            {
                dataMenuPanel.SetActive(true); // 데이터 패널 활성화
            }
        }
        private void CloseDataPanel()
        {
            if (dataMenuPanel != null)
            {
                dataMenuPanel.SetActive(false); // 데이터 패널 비활성화
            }
        }
        private void SaveGame()
        {
            Debug.Log("게임 저장 로직 실행");
            // 게임 저장 로직 추가
        }
        private void LoadGame()
        {
            Debug.Log("게임 불러오기 로직 실행");
            // 게임 불러오기 로직 추가
        }

        private void OpenConfigPanel()
        {
            if (configMenuPanel != null)
            {
                configMenuPanel.SetActive(true); // 설정 패널 활성화
            }
        }
        private void CloseConfigPanel()
        {
            if (configMenuPanel != null)
            {
                configMenuPanel.SetActive(false); // 설정 패널 비활성화
            }
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(true); // 일시정지 패널 다시 활성화
            }
        }
    }
}
