using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWeapon : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}