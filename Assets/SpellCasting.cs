using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618 // Type or member is obsolete
public class SpellCasting : NetworkBehaviour
{
  public Transform castPoint;
  public GameObject fireball;

  private void Update()
  {
    if (Input.GetButtonDown("Fire1") && isLocalPlayer)
    {
      CastSpell();
    }
  }

  void CastSpell()
  {
    Instantiate(fireball, castPoint.position, castPoint.rotation);
  }
}
