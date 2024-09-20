using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;
    private AudioSource _audioSource;

    public float minPitch = 0.5f;
    public float maxPitch = 2.0f;

    public float minY = -4.0f;
    public float maxY = 4.0f;

    private void Awake()
    {
        base.Awake(); // Call the base class's Awake method
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
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

        AdjustPitchBasedOnPosition();

    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * speed);
        }
    }

    // Method to set the paddle's color
    private void AdjustPitchBasedOnPosition()
    {
        // Get the current Y position of the paddle
        float currentY = transform.position.y;

        // Normalize the Y position to a value between 0 and 1
        float normalizedY = Mathf.InverseLerp(minY, maxY, currentY);

        // Calculate the pitch based on the normalized Y position
        float pitch = Mathf.Lerp(minPitch, maxPitch, normalizedY);

        // Apply the pitch to the AudioSource
        if (_audioSource != null)
        {
            _audioSource.pitch = pitch;
        }
    }
}
