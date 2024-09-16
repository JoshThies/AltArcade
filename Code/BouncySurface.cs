using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private Color lastColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);

            if (this.bounceStrength > 10) {
                ChangeBallColor(ball);
            }
        }
    }

    private void ChangeBallColor(Ball ball)
    {
        // Get the SpriteRenderer component of the ball
        SpriteRenderer ballRenderer = ball.GetComponent<SpriteRenderer>();

        Color[] rainbowColors = new Color[]
        {
            Color.red,     // Red
            new Color(1f, 0.5f, 0f), // Orange (RGB)
            Color.yellow,  // Yellow
            Color.green,   // Green
            Color.blue,    // Blue
            new Color(0.5f, 0f, 1) // Violet (RGB)
        };

        Color newColor;
        do
        {
            newColor = rainbowColors[Random.Range(0, rainbowColors.Length)];
        } while (newColor == lastColor);
        
        if (ballRenderer != null)
        {
            ballRenderer.color = newColor;
        }

        lastColor = newColor;
    }
}