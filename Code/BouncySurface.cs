using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private Color lastColor;

    public PlayerPaddle playerPaddle; // Reference to player paddle
    public Paddle opponentPaddle;     // Reference to opponent paddle (if applicable)
    public GameObject centerLine;     // Reference to center line or other objects to change color

    private AudioSource _audioSource;
    private void Awake()
    {
        // Get the AudioSource component from the paddle
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);

            // Only change colors and play sound when it hits the paddle (assumed based on bounceStrength condition)
            if (this.bounceStrength > 6)
            {
                // Call PlayHitSound from the paddle instead of the BouncySurface
                if (collision.gameObject.GetComponent<PlayerPaddle>() != null)
                {
                    playerPaddle.PlayHitSound();
                }

                ChangeAllColors(ball);
            }
        }
    }


    private void PlayHitSound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();  // Play the assigned sound effect
        }
    }
    private void ChangeAllColors(Ball ball)
    {
        // Array of colors (Rainbow)
        Color[] rainbowColors = new Color[]
        {
            Color.red,     // Red
            new Color(1f, 0.5f, 0f), // Orange
            Color.yellow,  // Yellow
            Color.green,   // Green
            Color.blue,    // Blue
            new Color(0.5f, 0f, 1f)  // Violet
        };

        // Choose a new random color that isn't the same as the last one
        Color newColor;
        do
        {
            newColor = rainbowColors[Random.Range(0, rainbowColors.Length)];
        } while (newColor == lastColor);

        // Change ball color
        ChangeObjectColor(ball.gameObject, newColor);

        // Change player paddle color
        if (playerPaddle != null)
        {
            ChangeObjectColor(playerPaddle.gameObject, newColor);
        }

        // Change opponent paddle color (if applicable)
        if (opponentPaddle != null)
        {
            ChangeObjectColor(opponentPaddle.gameObject, newColor);
        }

        // Change center line color (or other objects, if needed)
        if (centerLine != null)
        {
            ChangeObjectColor(centerLine, newColor);
        }

        // Update the last color used
        lastColor = newColor;
    }

    private void ChangeObjectColor(GameObject obj, Color newColor)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            renderer.color = newColor;
        }
    }
}
