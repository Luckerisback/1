using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeteController : MonoBehaviour
{
   [SerializeField] private Transform[] movePos;
   private void OnTriggerEnter(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         collision.GetComponent<Animator>().SetInteger("State", 4);
         collision.GetComponent<PlayerController>().enabled = false;
         Camera.main.transform.SetParent(null);
      }
   }

   private void OnTriggerStay(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         if (collision.transform.position.z < movePos[0].position.z)
         {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, movePos[0].position, 1);
         }
         else
         {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, movePos[1].position, 1);
         }
      }
   }
}
