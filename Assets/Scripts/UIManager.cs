using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public int startLives = 3;
    public int score = 0;
    private int lives;

    private void Awake()
    {
        
        
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        lives = startLives;
        UpdateScoreUI();
        UpdateLivesUI();
    }

    //Adds the ammount of points gained during gameplay to the score variable
    public void AddScore(int ammont)
    {
        score += ammont;
        UpdateScoreUI();
    }

    //Updates the UI to show the new score
    private void UpdateScoreUI()
    {
        scoreText.text = "Score:" + score;
    }

    //Sets the lives of the player to the ammount they got during gameplay
    public void SetLives(int newLives)
    {
        lives = newLives;
        UpdateLivesUI();
    }

    //Updates the UI to show the correct ammount of lives
    private void UpdateLivesUI()
    {
        livesText.text = "Lives:" + lives;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
