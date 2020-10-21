using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
  public float speed = 20f;
  public Rigidbody2D rb;

  private void Start()
  {
    rb.velocity = transform.right * speed;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("collided");
    Destroy(gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag != "Player")
    {
      Destroy(gameObject);
    }
  }
}
