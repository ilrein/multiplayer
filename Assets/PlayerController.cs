using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618 // Type or member is obsolete
public class PlayerController : NetworkBehaviour
{
  Rigidbody2D rb;
  new SpriteRenderer renderer;

  float horizontal;
  float vertical;

  public float moveSpeed = 5.0f;
  Sprite[] sprites;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    renderer = GetComponent<SpriteRenderer>();

    sprites = Resources.LoadAll<Sprite>("mage-black");
    renderer.sprite = sprites[5];
  }

  void Update()
  {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");

    StartCoroutine(Animate());
  }

  IEnumerator Animate()
  {
    float delay = 0.15f;

    if (vertical > 0)
    {
      if (renderer.sprite == sprites[2])
      {
        yield return new WaitForSeconds(delay);
        renderer.sprite = sprites[3];
      }
      else
      {
        yield return null;
        renderer.sprite = sprites[2];
      }
    }
    else if (vertical < 0)
    {
      if (renderer.sprite == sprites[4])
      {
        yield return new WaitForSeconds(delay);
        renderer.sprite = sprites[5];
      }
      else
      {
        yield return null;
        renderer.sprite = sprites[4];
      }
    }
    else if (horizontal < 0)
    {
      if (renderer.sprite == sprites[0])
      {
        yield return new WaitForSeconds(delay);
        renderer.sprite = sprites[1];
      }
      else
      {
        yield return null;
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
        renderer.sprite = sprites[0];
      }
    }
    else if (horizontal > 0)
    {
      if (renderer.sprite == sprites[0])
      {
        yield return new WaitForSeconds(delay);
        renderer.sprite = sprites[1];
      }
      else
      {
        yield return null;
        transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
        renderer.sprite = sprites[0];
      }
    }
  }

  private void FixedUpdate()
  {


    if (isLocalPlayer)
    {
      // if running diagonally, reduce speed multiplier
      if (horizontal != 0 && vertical != 0)
      {
        rb.velocity = new Vector2(horizontal * (moveSpeed * 0.75f), vertical * (moveSpeed * 0.75f));
      } else
      {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
      }
    }
  }
}
