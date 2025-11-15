using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [Header("씬 이름 설정")]
    public string introSceneName = "IntroScene"; // 인트로 씬 이름

    [Header("연결할 패널(UI)")]
    public GameObject settingPanel; // 설정 패널
    public GameObject continuePanel; // 계속하기 패널

    // --- 버튼과 연결된 함수들 ---

    // 1. '새 게임' 버튼을 눌렀을 때 실행될 함수
    public void OnNewGameButtonClicked()
    {
        // 인트로 씬으로 이동
        SceneManager.LoadScene(introSceneName);
    }
    // 2. '계속하기' 버튼을 눌렀을 때 실행될 함수
    public void OnContinueButtonClicked()
    {
        // 계속하기 패널 활성화
        if (continuePanel != null)
        {
            continuePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("계속하기 패널이 할당되지 않았습니다.");
        }
    }

    // 3. '설정' 버튼을 눌렀을 때 실행될 함수
    public void OnSettingsButtonClicked()
    {
        // 설정 패널 활성화
        if (settingPanel != null)
        {
            settingPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("설정 패널이 할당되지 않았습니다.");
        }
    }

    // 4. '종료' 버튼을 눌렀을 때 실행될 함수
    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        // 유니티 에디터에서 실행 중일 때는 플레이 모드를 종료합니다
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 게임 종료
        Application.Quit();
#endif
    }
}
