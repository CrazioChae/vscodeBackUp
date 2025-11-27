using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SO.Managers
{
    public class ManagerConfig : MonoBehaviour
    {
        public static ManagerConfig Instance { get; private set; } // 싱글톤 인스턴스
        public event System.Action<float> OnMasterVolumeChanged; // 볼륨 변경 시 외부에 알리는 이벤트
        [SerializeField] private float masterVolume = 1f; // 현재 마스터 볼륨 값
        [SerializeField] private bool isFullScreen = true; // 전체 화면 모드 여부(UI 동기화용)
        // 중복 제거된 해상도 목록을 저장하는 캐시
        [SerializeField] private List<Resolution> availableResolutions = new();

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            LoadSettings(); // 게임 시작 시 저장된 설정 불러오기
            // 씬 전환 시에도 파괴되지 않도록 설정
            // DontDestroyOnLoad(gameObject);
        }

        public void SetMasterVolume(float newVolume)
        {
            masterVolume = Mathf.Clamp01(newVolume); // 0.0에서 1.0 사이로 클램프
            SaveSettings(); // 설정 즉시 저장
            OnMasterVolumeChanged?.Invoke(masterVolume); // 볼륨 변경 이벤트 호출
            Debug.Log("마스터 볼륨 설정됨: " + masterVolume);
        }

        public float GetMasterVolume()
        {
            return masterVolume;
        }

        public void SetFullScreen(bool isFullScreen)
        {
            this.isFullScreen = isFullScreen; // 내부 상태 업데이트
            Screen.fullScreen = isFullScreen; // 실제 전체 화면 모드 설정
            SaveSettings();
            Debug.Log("전체 화면 모드 설정됨: " + isFullScreen);
        }

        public void PopulateResolutions(TMPro.TMP_Dropdown dropdown)
        {
            // 중복 해상도 제거 및 가로 해상도 내림차순 정렬
            availableResolutions = Screen.resolutions
                .GroupBy(res => new { res.width, res.height }) // 해상도별로 그룹화
                .Select(g => g.First()) // 익명 타입으로 변환
                .Distinct() // 중복 제거
                .OrderByDescending(res => res.width) // 가로 해상도 내림차순 정렬
                .ToList(); // 리스트로 변환
 
            dropdown.ClearOptions(); // 기존 옵션 제거
            List<string> options = availableResolutions // 옵션 문자열 생성
                .Select(res => $"{res.width} x {res.height}") // 문자열 포맷팅
                .ToList(); // 옵션 문자열 생성

            dropdown.AddOptions(options); // 드롭다운에 옵션 추가
            dropdown.RefreshShownValue(); // 표시된 값 새로고침

            int currentResolutionIndex = availableResolutions.FindIndex(res =>
                res.width == Screen.width && res.height == Screen.height);
            if (currentResolutionIndex >= 0)
            {
                dropdown.value = currentResolutionIndex; // 현재 해상도에 맞게 드롭다운 선택 설정
                Debug.Log("해상도 드롭다운이 채워졌습니다.");
                dropdown.RefreshShownValue();
            }
            else
            {
                dropdown.value = 0; // 기본값으로 설정
                Debug.LogWarning("현재 해상도에 맞는 옵션을 찾을 수 없습니다. 기본값으로 설정됩니다.");
                dropdown.RefreshShownValue();
            }
        }

        public void SetResolution(int index)
        {
            if (availableResolutions != null && index >= 0 && index < availableResolutions.Count)
            {
                Resolution selectedResolution = availableResolutions[index];
                Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
                SaveSettings();
                Debug.Log($"해상도 설정됨: {selectedResolution.width}x{selectedResolution.height}");
            }
            else
            {
                Debug.LogWarning("유효하지 않은 해상도 인덱스입니다: " + index);
            }
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);

            PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);

            PlayerPrefs.SetInt("ScreenHeight", Screen.height);
            PlayerPrefs.SetInt("ScreenWidth", Screen.width);

            PlayerPrefs.Save();
        }

        private void LoadSettings()
        {
            // 저장된 마스터 볼륨 불러오기 (기본값은 1.0f)
            masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

            // 저장된 전체 화면 모드 불러오기 (기본값은 true)
            isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 1) == 1;
            Screen.fullScreen = isFullScreen;

            // 저장된 해상도 불러오기 (기본값은 현재 해상도)
            int loadedWidth = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
            int loadedHeight = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);
            Screen.SetResolution(loadedWidth, loadedHeight, isFullScreen);

            Debug.Log($"모든 설정 불러옴: {loadedWidth}x{loadedHeight}, 전체화면={isFullScreen}, 볼륨={masterVolume}");
        }
    }
}