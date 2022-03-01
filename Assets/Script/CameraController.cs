using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    //Отслеживание позиции
    void Start()
    {
        offset = transform.position - player.position;
        RenderSettings.ambientLight = Color.red;
    }
    //Камера идет за игроком
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPosition;
    }

}