using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player UI Elements")] // 플레이어 UI 요소
    [SerializeField] private Slider healthSlider; // 플레이어의 체력바 슬라이더
    [SerializeField] private TextMeshProUGUI healthText; // 플레이어의 체력 텍스트
  
    // [Header("Game Over UI Elements")] // 게임 오버 UI 요소
    // [SerializeField] private GameObject gameOverPanel; // 게임 오버 화면 패널

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작 시 UI 초기화
        InitializeUI();
    }

    // 체력바의 값을 업데이트합니다.
    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        // 체력 바의 크기를 현재 체력에 맞게 0에서 1 사이로 설정할 수 있습니다.
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
            Debug.Log("체력 바 업데이트: " + currentHealth + "/" + maxHealth);
        }
        else
        {
            Debug.LogWarning("Health Slider UI 요소가 할당되지 않았습니다.");
        }

        // 체력 텍스트를 업데이트합니다.
        if (healthText != null)
        {
            healthText.text = $"체력: {currentHealth}/{maxHealth}";
            Debug.Log($"체력 UI 업데이트: {currentHealth}/{maxHealth}");
        }
        else
        {
            Debug.LogWarning("Health Text UI 요소가 할당되지 않았습니다.");
        }
    }

    // UI 초기화 함수
    private void InitializeUI()
    {
        // 체력 바와 게임 오버 패널을 비활성화
        healthSlider.gameObject.SetActive(true);
        // gameOverPanel.SetActive(false);
    }

    // 게임 오버 처리 함수
    // public void OnGameOver()
    // {
    //     // 게임 오버 패널을 활성화
    //     gameOverPanel.SetActive(true);
    // }
}
