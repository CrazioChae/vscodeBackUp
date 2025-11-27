using UnityEngine;
using SO.Managers;
using UnityEngine.UI;
using TMPro;

public class PresenterConfigUI : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TMP_Text masterVolumeText;
    [SerializeField] private Toggle muteToggle;
    private float lastVolumeBeforeMute = 1f;

    [Header("Display Settings")]
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    void OnEnable()
    {
        if (ManagerConfig.Instance == null)
        {
            Debug.LogWarning("ManagerConfig 인스턴스를 찾을 수 없습니다. UI 초기화가 적용되지 않을 수 있습니다.");
            return;
        }
        InitializeVolumeSettings(); // 볼륨 설정 초기화
        InitializeDisplaySettings(); // 디스플레이 설정 초기화
        Debug.Log("설정 UI 초기화 완료 및 ManagerConfig 인스턴스 연결됨.");
    }

    private void InitializeVolumeSettings()
    {
        float currentVolume = ManagerConfig.Instance.GetMasterVolume();
        if (masterVolumeSlider == null || masterVolumeText == null || muteToggle == null)
        {
            Debug.LogWarning("볼륨 설정 UI 요소 중 할당되지 않은 것이 있습니다. 설정을 건너뜁니다.");
            return;
        }

        masterVolumeSlider.value = currentVolume;
        UpdateVolumeUI(currentVolume);

        if (currentVolume > 0f)
        {
            lastVolumeBeforeMute = currentVolume;
            Debug.Log("마지막 음소거 전 볼륨 설정: " + lastVolumeBeforeMute);
        }

        masterVolumeSlider.onValueChanged.RemoveAllListeners();
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderChanged);
        Debug.Log("마스터 볼륨 슬라이더 설정 완료.");

        muteToggle.onValueChanged.RemoveAllListeners();
        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
        Debug.Log("음소거 토글 설정 완료.");
    }

    private void InitializeDisplaySettings()
    {
        // 해상도 드롭다운 설정
        if (resolutionDropdown != null)
        {
            ManagerConfig.Instance.PopulateResolutions(resolutionDropdown);
            resolutionDropdown.onValueChanged.RemoveAllListeners();
            resolutionDropdown.onValueChanged.AddListener(ManagerConfig.Instance.SetResolution);
            Debug.Log("해상도 설정 UI 초기화 완료.");
        }

        // 전체 화면 토글 설정
        if (fullScreenToggle != null)
        {
            fullScreenToggle.isOn = Screen.fullScreen;
            fullScreenToggle.onValueChanged.RemoveAllListeners();
            fullScreenToggle.onValueChanged.AddListener(ManagerConfig.Instance.SetFullScreen);
            Debug.Log("전체 화면 토글 설정 UI 초기화 완료.");
        }
        Debug.Log("디스플레이 설정 UI 초기화 완료.");
    }

    public void OnMasterVolumeSliderChanged(float newVolume)
    {
        // 마스터 볼륨 설정 업데이트
        if (ManagerConfig.Instance == null) return;

        ManagerConfig.Instance.SetMasterVolume(newVolume);
        UpdateVolumeUI(newVolume);

        if (newVolume > 0f)
        {
            lastVolumeBeforeMute = newVolume;
        }
        Debug.Log("마스터 볼륨 슬라이더 변경: " + newVolume);
    }

    public void OnMuteToggleChanged(bool isMuted)
    {
        if (ManagerConfig.Instance == null) return;

        if (isMuted)
        {
            // 음소거 처리
            masterVolumeSlider.value = 0f;
            Debug.Log("음소거 활성화됨.");
        }
        else
        {
            // 음소거 해제 처리
            // 복원할 볼륨이 0 이하인 경우 (lastVolumeBeforeMute가 초기값 1f이거나 0이 아닐 경우)
            float restoreVolume = lastVolumeBeforeMute > 0f ? lastVolumeBeforeMute : 1f;
            masterVolumeSlider.value = restoreVolume;
            // Slider.value 변경으로 인해 OnMasterVolumeSliderChanged가 호출되어 볼륨이 설정됩니다.
            Debug.Log("음소거 해제됨. 복원된 볼륨: " + restoreVolume);
        }
    }

    private void UpdateVolumeUI(float volume)
    {
        if (masterVolumeText != null)
        {
            int volumePercentage = Mathf.RoundToInt(volume * 100);
            masterVolumeText.text = volumePercentage.ToString();
            Debug.Log("볼륨 UI 업데이트: " + volumePercentage + "%");
            if (muteToggle != null)
            {
                muteToggle.isOn = volume <= 0f;
                Debug.Log("음소거 토글 업데이트: " + muteToggle.isOn);
            }
        }
        else
        {
            Debug.LogWarning("마스터 볼륨 텍스트 UI 요소가 할당되지 않았습니다.");
            return;
        }
    }
}