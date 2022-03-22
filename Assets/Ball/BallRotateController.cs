using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallRotateController : MonoBehaviour
{
    private float x;
    private float z;

    private void Start()
    {
        x = Random.Range(0, 15);
        z = Random.Range(0, 15);
    }

    private void Update()
    {
        if (PlayerParameters.IsVictory)
        {
            transform.eulerAngles = new Vector3(-50, 60, -50);
        }
    }
}
