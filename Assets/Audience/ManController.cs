using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
   [SerializeField] private Animator anim;
   [SerializeField] private int animId;

   private void Start()
   {
      anim.SetInteger("State", animId);
      StartCoroutine(SetDefaultAnimCoroutine());
   }

   private IEnumerator SetDefaultAnimCoroutine()
   {
      yield return new WaitForSeconds(0.5f);
      anim.SetInteger("State", 0);
   }
}
