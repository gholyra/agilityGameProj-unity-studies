using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);

        Instance = this;
    }

    public void RestartGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    
}
