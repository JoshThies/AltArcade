using UnityEngine;

public class Paddle : MonoBehaviour
{
   public float speed = 50.0f;
   protected Rigidbody2D _rigidbody;

   private AudioSource _audioSource; // Make sure this is initialized

   public AudioClip hitSoundEffect;

   protected void Awake()
   {
        _rigidbody = GetComponent<Rigidbody2D>();

        // Initialize the AudioSource
        _audioSource = GetComponent<AudioSource>();
   }

   public void ResetPosition()
   {
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0.0f);
        _rigidbody.velocity = Vector2.zero;
   }

   public void PlayHitSound()
     {
     // Check if both the AudioSource and the hitSoundEffect are assigned
          if (_audioSource != null && hitSoundEffect != null)
          {
               _audioSource.PlayOneShot(hitSoundEffect, 2.0f);  // Play the hit sound at full volume
          }
          else
          {
               if (_audioSource == null)
                    Debug.LogWarning("AudioSource component is missing!");

               if (hitSoundEffect == null)
                    Debug.LogWarning("Hit sound effect AudioClip is not assigned!");
          }
     }

}