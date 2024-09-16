using UnityEngine;

public class Paddle : MonoBehaviour
{
   public float speed = 50.0f;
   protected Rigidbody2D _rigidbody;

   protected void Awake()
   {
        _rigidbody = GetComponent<Rigidbody2D>();
   }

   public void ResetPosition()
   {
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0.0f);
        _rigidbody.velocity = Vector2.zero;
   }
}

