using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public ActionButtonsController actionButtonsController;

    [Header("PlayerStads")]
    public float dashSpeed = 200f;

    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// El personaje esquiva hacia la izquierda.
    /// </summary>
    public void DodgeLeft()
    {
        playerRigidbody.velocity = Vector3.left * dashSpeed * Time.deltaTime;
        actionButtonsController.takeAction = false;
        //Luego de realizar la acción, se ocultan los botones
    }

    /// <summary>
    /// El personaje esquiva hacia la derecha.
    /// </summary>
    public void DodgeRight()
    {
        playerRigidbody.velocity = Vector3.right * dashSpeed * Time.deltaTime;
        actionButtonsController.takeAction = false;
    }

    /// <summary>
    /// El personaje dispara su arma.
    /// </summary>
    public void Shoot()
    {
        actionButtonsController.takeAction = false;
        actionButtonsController.shootAction = true;
    }

    /// <summary>
    /// Dispara a alguna zona dependiendo de la dirección escogida.
    /// </summary>
    /// <param name="direction">Dirección del disparo.</param>
    public void ShootDirection(string direction)
    {
        switch (direction)
        {
            case "derecha":
                Debug.Log("Disparo hacia la derecha.");
                actionButtonsController.shootAction = false;
                break;

            case "izquierda":
                Debug.Log("Disparo hacia la izquierda.");
                actionButtonsController.shootAction = false;
                break;

            case "centro":
                Debug.Log("Disparo hacia el centro.");
                actionButtonsController.shootAction = false;
                break;

            default:
                Debug.Log("Dirección incorrecta.");
                actionButtonsController.shootAction = false;
                break;
        }
    }

}
