using UnityEngine;
public class CenterLine : MonoBehaviour
{
    public PlayerPaddle playerPaddle; // Reference to the player's paddle
    private SpriteRenderer paddleRenderer; // To get the paddle's color

    private void Start()
    {
        if (playerPaddle != null)
        {
            // Get the SpriteRenderer of the paddle
            paddleRenderer = playerPaddle.GetComponent<SpriteRenderer>();
        }
    }

    // This is called when the ball crosses the center line
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();

        if (ball != null)
        {
            // Get the ball's color
            SpriteRenderer ballRenderer = ball.GetComponent<SpriteRenderer>();
            Color ballColor = ballRenderer.color;

            // Get the paddle's color
            if (paddleRenderer != null)
            {
                Color paddleColor = paddleRenderer.color;

                // Compare ball and paddle colors
                if (ballColor == paddleColor)
                {
                    // Colors match, increase the paddle height by 1 pixel
                    IncreasePaddleSize(5.0f / 100.0f); // 5 pixels = 5/100 units in Unity
                    Debug.Log("Colors match! Paddle height increased.");
                }
                else
                {
                    // Colors do not match, decrease the paddle height by 1 pixel
                    DecreasePaddleSize(1.0f / 100.0f); // 1 pixel = 1/100 units in Unity
                    Debug.Log("Colors do not match. Paddle height decreased.");
                }
            }
        }
    }

    private void IncreasePaddleSize(float amount)
    {
        // Increase the paddle's height by modifying its local scale
        Vector3 newScale = playerPaddle.transform.localScale;
        newScale.y += amount; // Increase the Y scale (height)
        playerPaddle.transform.localScale = newScale;
    }

    private void DecreasePaddleSize(float amount)
    {
        // Decrease the paddle's height, but ensure it doesn't become too small
        Vector3 newScale = playerPaddle.transform.localScale;
        newScale.y = Mathf.Max(0.1f, newScale.y - amount); // Decrease but prevent negative height
        playerPaddle.transform.localScale = newScale;
    }
}
