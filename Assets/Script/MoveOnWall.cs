using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWall : MonoBehaviour
{
   [SerializeField] private Transform[] movePoints;
   [SerializeField] private bool isLeftWall;
   private void OnTriggerEnter(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         collision.GetComponent<PlayerController>().enabled = false;
         if (isLeftWall)
         {
            collision.GetComponent<Animator>().SetInteger("State", 2);
         }
         else
         {
            collision.GetComponent<Animator>().SetInteger("State", 3);
         }

         StartCoroutine(SetDefaultAnimCoroutine(collision.GetComponent<Animator>()));

         // collision.transform.position = new Vector3(transform.position.x + )
      }
   }

   private void OnTriggerStay(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         if (collision.transform.position.z < movePoints[0].position.z)
         {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, movePoints[0].position, 2f);
         }
         else
         {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, movePoints[1].position, 2f);
         }
         
      }
   }

   private void OnTriggerExit(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         collision.GetComponent<PlayerController>().enabled = true;
      }
   }

   private IEnumerator SetDefaultAnimCoroutine(Animator anim)
   {
      yield return new WaitForSeconds(0.5f);
      anim.SetInteger("State", 0);
      
   }
}
