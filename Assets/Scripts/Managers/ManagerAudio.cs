using UnityEngine;
using UnityEngine.Audio;

namespace SO.Managers
{
    public class ManagerAudio : MonoBehaviour
    {
        public static ManagerAudio Instance { get; private set; } // 싱글톤 인스턴스
        [SerializeField] private AudioMixer audioMixer; // 오디오 믹서 참조
        private const string MASTER_VOLUME_PARAM = "MasterVolume"; // 마스터 볼륨 파라미터 이름

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            // 씬 전환 시에도 파괴되지 않도록 설정
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            if (ManagerConfig.Instance != null)
            {
                ManagerConfig.Instance.OnMasterVolumeChanged += SetMixerVolume;
            }
            else
            {
                Debug.LogWarning("ManagerConfig 인스턴스를 찾을 수 없습니다. 마스터 볼륨 설정이 적용되지 않을 수 있습니다.");
                return;
            }
            // 매니저 설정에서 초기 마스터 볼륨 가져오기
            float initialVolume = ManagerConfig.Instance.GetMasterVolume();
            Debug.Log("초기 마스터 볼륨: " + initialVolume);
            // 시작 시 현재 설정을 사운드 시스템에 알림
            SetMixerVolume(initialVolume);
        }

        void OnDestroy()
        {
            if (ManagerConfig.Instance != null)
            {
                ManagerConfig.Instance.OnMasterVolumeChanged -= SetMixerVolume;
            }
        }

        private void SetMixerVolume(float initialVolume)
        {
            float clampedVolume = Mathf.Clamp01(initialVolume); // 0.0에서 1.0 사이로 클램프
            float db = Mathf.Log10(clampedVolume) * 20f; // 볼륨을 데시벨로 변환

            if (clampedVolume == 0f)
            {
                db = -80f; // 무음 처리
            }
            if (audioMixer != null)
            {
                audioMixer.SetFloat(MASTER_VOLUME_PARAM, db); // 오디오 믹서에 볼륨 설정
                Debug.Log("오디오 믹서에 마스터 볼륨 설정됨: " + db + " dB");
            }
            else
            {
                Debug.LogWarning("AudioMixer가 할당되지 않았습니다. 마스터 볼륨을 설정할 수 없습니다.");
            }
        }
    }
}