using System.Collections;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private Transform[] victoryLevel;
    [SerializeField] private GameObject victoryScreen;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().enabled = false;
            collision.GetComponent<Animator>().SetInteger("State", 6);
            StartCoroutine(SetDefaultAnim(collision.GetComponent<Animator>()));
            PlayerParameters.IsVictory = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position,
                victoryLevel[3].position, 0.5f);
            if (collision.transform.position == victoryLevel[3].position)
            {
                victoryScreen.SetActive(true);
            }
            
        }
    }

    private IEnumerator SetDefaultAnim(Animator anim)
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("State", 0);
    }
}
