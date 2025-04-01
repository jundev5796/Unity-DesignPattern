using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public TextMeshProUGUI scoreText; // Reference to UI Text (Assign in Inspector)

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int _score = 0;
    public int Score => _score;

    public void AddScore(int points)
    {
        _score += points;
        Debug.Log($"Score updated: {_score}");

        // Update UI if assigned
        if (scoreText != null)
        {
            scoreText.text = "Score: " + _score;
        }
        else
        {
            Debug.LogError("ScoreText UI is not assigned in the Inspector!");
        }
    }
}

