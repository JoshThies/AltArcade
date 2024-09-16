using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;

    // Rainbow colors
    private Color[] rainbowColors = new Color[]
    {
        Color.red,     // Red
        new Color(1f, 0.5f, 0f), // Orange
        Color.yellow,  // Yellow
        Color.green,   // Green
        Color.blue,    // Blue
        new Color(0.5f, 0f, 1f)  // Violet
    };

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        base.Awake(); // Call the base class's Awake method
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    private void Update()
    {
        // Paddle movement input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }

        // Change color based on specific key presses
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 key for Red
        {
            SetColor(rainbowColors[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 key for Orange
        {
            SetColor(rainbowColors[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 3 key for Yellow
        {
            SetColor(rainbowColors[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) // 4 key for Green
        {
            SetColor(rainbowColors[3]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) // 5 key for Blue
        {
            SetColor(rainbowColors[4]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) // 6 key for Violet
        {
            SetColor(rainbowColors[5]);
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * speed);
        }
    }

    // Method to set the paddle's color
    private void SetColor(Color color)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = color;
        }
    }
}
