using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Method to load a scene by name
    // '새 게임' 버튼을 눌렀을 때 실행될 함수
    // public으로 선언해야 유니티 버튼의 OnClick 이벤트에서 이 함수를 찾을 수 있습니다.
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
        // "GamePlayScene"이라는 이름의 씬을 불러옵니다.
        // 이 이름은 Build Settings에 등록된 씬의 이름과 정확히 일치해야 합니다.
        // 또는, Build Settings의 번호(Build Index)로도 불러올 수 있습니다.
        // SceneManager.LoadScene(1);
    }
    // '타이틀로' 버튼을 눌렀을 때 실행될 함수 (나중에 필요할 수 있습니다)
    // 타이틀 씬을 불러옵니다.
    // public으로 선언해야 유니티 버튼의 OnClick 이벤트에서 이 함수를 찾을 수 있습니다.
    // 이 함수는 게임이 끝났을 때 타이틀 화면으로 돌아갈 때 사용됩니다.
    // 타이틀 씬은 게임의 시작 화면으로, 게임을 시작하기 전에 보여지는 씬입니다.
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        // "TitleScene"이라는 이름의 씬을 불러옵니다.
        // 이 이름은 Build Settings에 등록된 씬의 이름과 정확히 일치해야 합니다.
        // 또는, Build Settings의 번호(Build Index)로도 불러올 수 있습니다.
        // SceneManager.LoadScene(0);
    }
    // '재시작' 버튼을 눌렀을 때 실행될 함수
    // 현재 씬을 다시 불러옵니다.
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
// Path: Assets/Scripts/NewEmptyCSharpScript.cs
// 이 파일은 유니티에서 새 C# 스크립트를 만들 때 자동으로 생성되는 빈 스크립트입니다.
// 이 스크립트는 현재 사용되지 않지만, 유니티 에디터에서 새 스크립트를 만들 때 기본적으로 생성됩니다.
public class NewEmptyCSharpScript
{
    // 이 클래스는 아무런 기능도 없으며, 유니티에서 새 스크립트를 만들 때의 기본 구조를 보여줍니다.
    // 실제로 사용하려면 이 클래스에 필요한 기능을 추가해야 합니다.
    // 예를 들어, 게임 오브젝트에 부착하여 특정 동작을 수행하도록 할 수 있습니다.
}
