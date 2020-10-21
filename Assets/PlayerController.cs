using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618 // Type or member is obsolete
public class PlayerController : NetworkBehaviour
#pragma warning restore CS0618 // Type or member is obsolete
{
  Rigidbody2D rb;
  Animator animator;

  float horizontal;
  float vertical;

  public float runSpeed = 10.0f;
  Sprite localPlayerSprite;

  void Start()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();

    localPlayerSprite = Resources.Load<Sprite>("mage-black");
    GetComponent<SpriteRenderer>().sprite = localPlayerSprite;
  }

  void Update()
  {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");
  }

  private void FixedUpdate()
  {
    if (horizontal > 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
    }

    if (horizontal < 0)
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
    }

    if (isLocalPlayer)
    {
      if (horizontal != 0 && vertical != 0)
      {
        rb.velocity = new Vector2(horizontal * (runSpeed * 0.75f), vertical * (runSpeed * 0.75f));
      } else
      {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
      }
    }
  }
}
