using System;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform movePoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().SetInteger("State", 4);
            collision.GetComponent<PlayerController>().enabled = false;
            
            Camera.main.transform.SetParent(null);
            PlayerParameters.IsEndGame = true;
        }
    }

    private void Update()
    {
        if (PlayerParameters.IsEndGame)
        {
            var offset = new Vector3(player.transform.position.x, movePoint.position.y, movePoint.position.z);
            player.transform.position = Vector3.MoveTowards(player.transform.position, offset, 10);
            Camera.main.transform.eulerAngles =
                Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3(0, 0, 0), 0.01f);
        }
    }
}
