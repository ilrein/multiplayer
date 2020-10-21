using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
  Rigidbody2D body;

  float horizontal;
  float vertical;

  public float runSpeed = 10.0f;
  Sprite localPlayerSprite;

  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    if (!isLocalPlayer)
    {
      localPlayerSprite = Resources.Load<Sprite>("mage-black");
      GetComponent<SpriteRenderer>().sprite = localPlayerSprite;
    }
    else
    {
      localPlayerSprite = Resources.Load<Sprite>("mage-white");

      GetComponent<SpriteRenderer>().sprite = localPlayerSprite;
    }
  }

  void Update()
  {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");

    if (horizontal > 0)
    {
      transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180f, transform.localRotation.z);
    }

    if (horizontal < 0)
    {
      transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0f, transform.localRotation.z);
    }
  }

  private void FixedUpdate()
  {
    if (!isLocalPlayer)
      return;

    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
  }
}
