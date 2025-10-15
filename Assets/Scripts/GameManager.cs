using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public bool IsGameOver {  get; private set; } = false;

    public AudioClip dieSFX;
    private AudioSource audioSource;

    public Text scoreText;
    public GameObject gameOverPanel;
    public Text finalScoreText;

    public PlayerController player;
    public Vector3 playerStartPos;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        UpdateScoreUI();
        IsGameOver = false;

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        if (player != null) player.ResetPlayer(playerStartPos);
    }

    public void AddScore(int v)
    {
        if (IsGameOver) return;
        score += v;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void PlayerDied()
    {
        if (IsGameOver) return;
        IsGameOver = true;

        if (dieSFX != null) audioSource.PlayOneShot(dieSFX);

        // show panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (finalScoreText != null) finalScoreText.text = "Score: " + score.ToString();
        }

        // tạm dừng game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
