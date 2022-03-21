using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject ball;
    [SerializeField] private bool isFreeBall;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isFreeBall)
            {
                Debug.Log(1);
                anim.SetBool("isDie", true);
                collision.GetComponent<Animator>().SetInteger("State", 5);
                StartCoroutine(SetDefaultAnimCoroutine(collision.GetComponent<Animator>()));
            }
            
            if (!collision.isTrigger)
            {
                PlayerParameters.BallCount++;
            }
            ball.transform.SetParent(playerHand);
            ball.transform.localPosition = new Vector3(0,0,0);
           
        }
    }

    private IEnumerator SetDefaultAnimCoroutine(Animator anim)
    {
        yield return new WaitForSeconds(0.5f);
    
        anim.SetInteger("State", 0);
        Destroy(gameObject);
    }
}
