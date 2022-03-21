using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider col;
    private Animator anim;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text coinsText;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameObject qtePanel;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject cam;
    private int lineToMove = 1;
    public float lineDistance = 4;
    private float maxSpeed = 110;
    //����� ����
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        Time.timeScale = 1;
        coins = 0;
        coinsText.text = coins.ToString();
        StartCoroutine(SpeedIncrease());
    }
    //�������� �������
    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                StartCoroutine(Jump());
        }
        //�������� ����
        if (controller.isGrounded)
            anim.SetTrigger("isRunning");
        //������� ������
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

    }
    //�������� ������
    private IEnumerator Jump()
    {
        dir.y = jumpForce;
        anim.SetInteger("State", 1);
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("State", 0);
    }
    //��������
    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
    //�������� � ������� + ��������� ������
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
            PlayerPrefs.SetInt("lastRunScore", lastRunScore);
            Time.timeScale = 0;
        }
    }
    //���������� ��������
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(3);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

   
    //���� �������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "qte")
        {
            qtePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "Finish")
        {
            anim.SetTrigger("Finish");
            endPanel.SetActive(true);
            maxSpeed = 0;
            speed = 0;
        }
        if (other.gameObject.tag == "up1")
        {
            Destroy(other.gameObject);
            anim.SetTrigger("up");
            dir.y = 1.8f*jumpForce;
            obj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
            cam.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
            obj.GetComponent<Transform>().position = transform.position + new Vector3(5,0);
            cam.GetComponent<Transform>().position = transform.position + new Vector3(2, 14);
        }
        if (other.gameObject.tag == "endwall1")
        {
            cam.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            obj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            obj.GetComponent<Transform>().position = transform.position - new Vector3(1, 3);
            cam.GetComponent<Transform>().position = new Vector3(0, 11.7f);
        }
        if (other.gameObject.tag == "up2")
        {
            Destroy(other.gameObject);
            anim.SetTrigger("up");
            dir.y = 1.8f * jumpForce;
            obj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
            cam.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
            obj.GetComponent<Transform>().position = transform.position + new Vector3(-3, 0);
            cam.GetComponent<Transform>().position = transform.position + new Vector3(2, 14);
        }
        if (other.gameObject.tag == "endwall2")
        {
            cam.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            obj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            obj.GetComponent<Transform>().position = transform.position - new Vector3(1, 3);
            cam.GetComponent<Transform>().position = new Vector3(0, 11.7f);
        }
        if (other.gameObject.tag == "destroyer")
        {
            gameObject.SetActive(false);
        }

    }

}