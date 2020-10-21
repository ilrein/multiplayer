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
    if (!isLocalPlayer)
    {
      Sprite localPlayerSprite = Resources.Load<Sprite>("mage-black");

      GetComponent<SpriteRenderer>().sprite = localPlayerSprite;
    }
    else
    {
      Sprite localPlayerSprite = Resources.Load<Sprite>("mage-white");

      GetComponent<SpriteRenderer>().sprite = localPlayerSprite;
    }
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
