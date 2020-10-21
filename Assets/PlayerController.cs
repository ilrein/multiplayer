using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
  Rigidbody2D body;

  float horizontal;
  float vertical;

  public float runSpeed = 20.0f;

  void Start()
  {
    body = GetComponent<Rigidbody2D>();

    Color playerColor = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
    );

    GetComponent<SpriteRenderer>().color = playerColor;
   }

    void Update()
  {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");
  }

  private void FixedUpdate()
  {
    if (!isLocalPlayer)
      return;

    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
  }
}
