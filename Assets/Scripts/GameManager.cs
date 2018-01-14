using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Player player1;
    public Player player2;
    public BallManager ball;
    public Text scoreTextP1;
    public Text scoreTextP2;
    public Text GameFinishedText;
    public Text pressSpaceToContinueText;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private void Start()
    {
        GameFinishedText.gameObject.SetActive(false);
        pressSpaceToContinueText.gameObject.SetActive(false);
    }
    private void LateUpdate()
    {
        if (GameFinishedText.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameFinishedText.gameObject.SetActive(false);
                pressSpaceToContinueText.gameObject.SetActive(false);
                Time.timeScale = 1f;
                scoreP1 = 0;
                scoreP2 = 0;
            }
        }
        scoreTextP1.text = scoreP1.ToString();
        scoreTextP2.text = scoreP2.ToString();
        bool gameHasEnded = CheckForGameEnd();
        if (gameHasEnded)
        {
            if(ball.LastTouched == true)
            {
                Debug.Log("Player1");
                scoreP1++;
                if (scoreP1 == 10)
                {
                    GameFinishedText.gameObject.SetActive(true);
                    pressSpaceToContinueText.gameObject.SetActive(true);
                    GameFinishedText.text = "Player 1 has won!";
                    Time.timeScale = 0f;
                }
            } else if(ball.LastTouched == false)
            {
                Debug.Log("player2");
                scoreP2++;
                if (scoreP2 == 10)
                {
                    GameFinishedText.gameObject.SetActive(true);
                    pressSpaceToContinueText.gameObject.SetActive(true);
                    GameFinishedText.text = "Player 2 has won!";
                    Time.timeScale = 0f;
                }
            }
            ResetGame();
        }
    }
    bool CheckForGameEnd()
    {
        bool val;
        if (ball.transform.position.x > 5.2)
        {
            val = true;
        } else if (ball.transform.position.x < -5.2)
        {
            val = true;
        }
        else
        {
            val = false;
        }
        return val;
    }
    void ResetGame()
    {
        player1.ResetPlayerPos();
        player2.ResetPlayerPos();
        ball.ResetBall();
    }

}
