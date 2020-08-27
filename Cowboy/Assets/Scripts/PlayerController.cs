using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("PlayerStads")]
    public float dashSpeed = 200f;

    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void DodgeLeft()
    {
        playerRigidbody.velocity = Vector3.left * dashSpeed * Time.deltaTime;
    }

    public void DodgeRight()
    {
        playerRigidbody.velocity = Vector3.right * dashSpeed * Time.deltaTime;
    }

    public void Shoot()
    {
        Debug.Log("Disparo");
    }

}
