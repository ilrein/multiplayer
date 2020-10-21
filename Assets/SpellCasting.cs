using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
  public Transform castPoint;
  public GameObject fireball;

  private void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      CastSpell();
    }
  }

  void CastSpell()
  {
    Instantiate(fireball, castPoint.position, castPoint.rotation);
  }
}
