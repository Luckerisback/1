using UnityEngine;

public class PeoplesController : MonoBehaviour
{
   [SerializeField] private GameObject loseWindow;
   [SerializeField] private float speed;
   [SerializeField] private Transform player;
   [SerializeField] private Animator[] anims;
   private void Update()
   {
      if (!PlayerParameters.IsEndGame)
      {
         var offset = new Vector3(transform.position.x, transform.position.y, player.position.z);
         transform.position = Vector3.MoveTowards(transform.position, offset, speed);
      }

   }

   private void OnTriggerEnter(Collider collision)
   {
      if (collision.CompareTag("Player"))
      {
         loseWindow.SetActive(true);
         speed = 0;
         for (int i = 0; i < anims.Length; i++)
         {
            anims[i].SetInteger("State", 1);
         }
      }
   }
}
