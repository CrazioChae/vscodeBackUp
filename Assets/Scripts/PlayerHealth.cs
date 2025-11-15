using UnityEngine;
using UnityEngine.Events; // Unity 엔진 기능을 사용하기 위해 필수

// 클래스 이름은 파일 이름(PlayerHealth.cs)과 반드시 같아야 합니다.
// MonoBehaviour를 상속받아 유니티의 컴포넌트로 사용할 수 있게 합니다.
public class PlayerHealth : MonoBehaviour
{
    // [SerializeField]는 private 변수를 유니티 인스펙터 창에서 편하게 수정할 수 있게 해줍니다.
    [SerializeField] private int maxHealth = 100; // 최대 체력
    private int currentHealth; // 현재 체력

    // 이 클래스는 플레이어가 데미지를 받거나 회복할 때 체력을 조절하고, 체력 변경 및 사망 이벤트를 처리합니다.
    // UnityEvent를 사용하여 체력 변경 및 사망 이벤트를 다른 스크립트에서 구독할 수 있도록 합니다.
    public UnityEvent<int, int> OnHealthChanged; // 체력 변경 이벤트
    public UnityEvent OnPlayerDied; // 플레이어 사망 이벤트

    // Start is called before the first frame update
    // 게임이 시작될 때 이 스크립트에서 가장 먼저, 단 한 번만 호출됩니다.
    // 이 함수는 MonoBehaviour의 생명주기 중 가장 먼저 실행됩니다.
    void Start()
    {
        // 현재 체력을 최대 체력으로 초기화
        currentHealth = maxHealth;
        Debug.Log("플레이어의 체력 초기화: " + currentHealth + "/" + maxHealth);

        // 게임 시작 시 체력 변경 이벤트를 초기화하여 현재 체력과 최대 체력을 전달합니다.
        // 이 이벤트는 다른 스크립트(예: UI 매니저)에서 체력 변경을 감지하고 UI를 업데이트하는 데 사용됩니다.
        // UnityEvent는 Unity에서 제공하는 이벤트 시스템으로, 다른 스크립트에서 이 이벤트를 구독(subscribe)하여 체력 변경 시 자동으로 호출됩니다.
        // 예를 들어, UI 매니저 스크립트에서 이 이벤트를 구독하여 체력 바를 업데이트할 수 있습니다.
        OnHealthChanged.Invoke(currentHealth, maxHealth);
    }

    // 데미지를 받는 테스트 함수
    // 이 함수는 다른 스크립트에서 호출하여 플레이어에게 데미지를 줄 수 있습니다.
    public void OnDamageTest()
    {
        TakeDamage(40);
    }

    // 데미지를 받는 함수
    // 다른 스크립트(예: 몬스터의 공격 스크립트)에서 호출할 수 있도록 public으로 선언합니다.
    public void TakeDamage(int damage)
    {
        // 현재 체력에서 데미지만큼 감소시킵니다.
        currentHealth -= damage;

        // 체력이 0보다 작아지지 않도록 최소값을 0으로 고정합니다.
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // 콘솔 창에 데미지 정보와 현재 체력을 출력합니다.
        Debug.Log("플레이어가 " + damage + "의 데미지를 입었습니다. 현재 체력: " + currentHealth);

        // 체력 변경 이벤트를 호출하여 현재 체력과 최대 체력을 전달합니다.
        // 이 이벤트는 다른 스크립트(예: UI 매니저)에서 체력 변경을 감지하고 UI를 업데이트하는 데 사용됩니다.
        OnHealthChanged.Invoke(currentHealth, maxHealth);

        // 만약 체력이 0 이하라면
        if (currentHealth <= 0)
        {
            Die(); // 죽음 처리 함수를 호출합니다.
        }
    }

    // 죽었을 때 처리하는 함수
    private void Die()
    {
        // 콘솔 창에 죽었다는 메시지를 출력합니다.
        Debug.Log("플레이어가 쓰러졌습니다... GAME OVER");
        // 여기에 나중에 실제로 죽는 애니메이션, 게임 오버 창 띄우기 등의 로직을 추가할 수 있습니다.
        // 예: gameObject.SetActive(false); // 플레이어 오브젝트를 비활성화해서 사라지게 만듦
    }
}
