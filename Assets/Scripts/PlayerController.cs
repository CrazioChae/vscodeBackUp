using UnityEngine;
using UnityEngine.InputSystem; // Input 시스템을 사용하기 위해 필요합니다.

// 클래스 이름은 파일 이름(PlayerController.cs)과 반드시 같아야 합니다.
// MonoBehaviour를 상속받아 유니티의 컴포넌트로 사용할 수 있게 합니다.
public class PlayerController : MonoBehaviour
{
    // [SerializeField]는 private 변수를 유니티 인스펙터 창에서 편하게 수정할 수 있게 해줍니다.
    // 이 변수는 캐릭터의 이동 속도를 조절합니다. 유니티 에디터에서 값을 바꿀 수 있습니다.
    [Header("Movement Settings")] // 인스펙터 창에서 보기 좋게 헤더를 추가합니다.
    [SerializeField] private float moveSpeed = 5f; // 이동 속도. 유니티 에디터에서 값을 바꿀 수 있습니다.

    // 필요한 컴포넌트들을 담을 변수들입니다.
    // Rigidbody2D는 물리 엔진을 사용하여 캐릭터를 움직이기 위해 필요합니다.
    private Rigidbody2D rb;
    // SpriteRenderer는 캐릭터의 스프라이트(이미지)를 화면에 그리기 위해 필요합니다.
    private SpriteRenderer spriteRenderer;
    // Animator는 애니메이션을 제어하기 위해 필요합니다. 현재는 Animator가 없어서 null이 될 수 있습니다.
    private Animator animator; // 나중에 애니메이션을 위해 미리 만들어 둡니다.
    private Vector2 moveInput; // InputValue는 유니티의 새로운 Input System에서 입력 값을 나타내는 구조체입니다.

    // Awake()는 MonoBehaviour의 생명주기 중 가장 먼저 실행됩니다.
    // 주로 초기화에 사용됩니다.
    void Awake()
    {
        // Rigidbody2D는 2D 물리 엔진을 사용하여 캐릭터를 움직이기 위해 필요합니다.
        // GetComponent는 현재 게임 오브젝트에 붙어있는 컴포넌트를 가져오는 함수입니다.
        // Rigidbody2D 컴포넌트를 가져와서 rb 변수에 저장합니다.
        rb = GetComponent<Rigidbody2D>();
        // 이 컴포넌트는 캐릭터의 스프라이트(이미지)를 화면에 그리기 위해 필요합니다.
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 이 컴포넌트는 캐릭터의 애니메이션을 제어하기 위해 필요합니다.
        animator = GetComponent<Animator>(); // 지금은 Animator가 없어서 null이 됩니다. 괜찮습니다.
    }

    // OnMove()는 키보드 입력을 처리하는 함수입니다.
    // 이 함수는 유니티의 Input 시스템을 사용하여 캐릭터의 이동을 제어합니다.
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // 캐릭터 방향을 뒤집는 함수를 호출합니다.
        // 이 함수는 캐릭터가 왼쪽으로 움직일 때 스프라이트를 뒤집어 줍니다.
        // 오른쪽으로 움직일 때는 스프라이트를 뒤집지 않습니다.
        FlipSprite();

        // 애니메이션을 제어하는 함수를 호출합니다.
        // 이 함수는 캐릭터가 움직이고 있는지 여부에 따라 애니메이션 상태를 업데이트합니다.
        // 예를 들어, 캐릭터가 움직이고 있다면 걷는 애니메이션을 재생하고, 멈춰있다면 멈춘 애니메이션을 재생합니다.
        UpdateAnimation();
    }

    // 정해진 시간 간격(기본 0.02초)마다 호출됩니다. 물리 계산은 여기서 하는 것이 안정적입니다.
    void FixedUpdate()
    {
        // Rigidbody의 속도(velocity)를 조절하여 캐릭터를 실제로 움직입니다.
        // rb.linearVelocity는 Rigidbody2D의 속도를 설정하는 속성입니다.
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    // 캐릭터의 방향을 뒤집는 로직을 담당하는 함수
    void FlipSprite()
    {
        // 오른쪽으로 움직이고 있다면 (입력값이 0보다 크면)
        if (moveInput.x > 0)
        {
            // 스프라이트를 뒤집지 않습니다 (오른쪽을 보게 함).
            spriteRenderer.flipX = false;
        }
        // 왼쪽으로 움직이고 있다면 (입력값이 0보다 작으면)
        else if (moveInput.x < 0)
        {
            // 스프라이트를 수평으로 뒤집습니다 (왼쪽을 보게 함).
            spriteRenderer.flipX = true;
        }
    }

    // 애니메이션을 관리하는 함수
    void UpdateAnimation()
    {
        // Animator 컴포넌트가 있는지 먼저 확인합니다 (오류 방지).
        if (animator != null)
        {
            // 움직이고 있다면 (입력값이 0이 아니라면)
            if (moveInput != Vector2.zero)
            {
                // Animator의 "isWalking" 파라미터를 true로 설정합니다.
                animator.SetBool("isWalking", true);
            }
            else // 멈춰있다면
            {
                // "isWalking" 파라미터를 false로 설정합니다.
                animator.SetBool("isWalking", false);
            }
        }
    }
}