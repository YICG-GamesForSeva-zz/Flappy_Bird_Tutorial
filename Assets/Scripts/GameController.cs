using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance; // Creating a reference to be used statically
    public Text scoreText; // To hold the score value
    public GameObject gameOverText; // A reference to hold the gameOverText

    private int score = 0; // The player's score
    public bool gameOver = false; // Is the game over?
    public float scrollSpeed = -1.5f; // The speed at which the background moves

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        else
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void BirdDied()
    {
        // Activate the game over text block
        gameOverText.SetActive(true);

        // Note the game is really over
        gameOver = true;
    }
}