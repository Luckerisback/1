using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private Animator anim;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isDie", true);
            collision.GetComponent<Animator>().SetInteger("State", 5);
            StartCoroutine(SetDefaultAnimCoroutine(collision.GetComponent<Animator>()));
            PlayerParameters.BallCount++;
            transform.SetParent(playerHand);
            transform.localPosition = new Vector3(0,0,0);
            enabled = false;
        }
    }

    private IEnumerator SetDefaultAnimCoroutine(Animator anim)
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("State", 0);
    }
}
