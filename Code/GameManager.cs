using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Paddle playerPaddle;
    public Paddle player2Paddle;
    public Text playerScoreText;
    public Text player2ScoreText;
    private int _playerScore;
    private int _player2Score;

    public void PlayerScores()
    {
        _playerScore++;

        this.playerScoreText.text = _playerScore.ToString();
        ResetRound();
    }
    public void Player2Scores()
    {
        _player2Score++;

        this.player2ScoreText.text = _player2Score.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        this.playerPaddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
}
