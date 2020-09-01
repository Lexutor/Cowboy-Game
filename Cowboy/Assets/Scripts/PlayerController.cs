using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public ActionButtonsController actionButtonsController;
    public Transform enemy;

    /// <summary>
    /// Posición a la que se moverá el personaje.
    /// </summary>
    /// <value>Posición</value>
    public Vector3 TargetPosition 
    {
        get { return targetPosition; }

        set
        {
            targetPosition = value;

            StopCoroutine("Dodging");
            StartCoroutine("Dodging", targetPosition);
        }
    }

    /// <summary>
    /// Lo que rotará el personaje para ver de frente a su enemigo.
    /// </summary>
    /// <value>Rotación destino.</value>
    public Quaternion TargetRotation 
    {
        get { return targetRotation; }

        set
        {
            targetRotation = value;

            StopCoroutine("Rotating");
            StartCoroutine("Rotating", targetRotation);
        }
    }

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    [Header("PlayerStads")]
    public float dashSpeed = 5, dashSmoothing = 1, rotationSmoothing = 3.5f;
    
    /// <summary>
    /// Movimiento lateral del personaje.
    /// </summary>
    /// <param name="direction">Derecha (1) o izquierda (-1).</param>
    private void Dodge(float direction)
    {
        Vector2 movement = new Vector2(direction, 0);
        movement = Vector2.ClampMagnitude(movement, 1);

        Vector3 actualRight = transform.right;
        actualRight.y = 0;
        actualRight = actualRight.normalized;

        TargetPosition = transform.position + (actualRight * movement.x) * dashSpeed;
    }

    /// <summary>
    /// El personaje esquiva hacia la izquierda.
    /// </summary>
    public void DodgeLeft()
    {
        Dodge(-1);
        actionButtonsController.takeAction = false;
        //Luego de realizar la acción, se ocultan los botones
    }

    /// <summary>
    /// El personaje esquiva hacia la derecha.
    /// </summary>
    public void DodgeRight()
    {
        Dodge(1);
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

    /// <summary>
    /// Dirige la mirada (frente) hacia el enemigo.
    /// </summary>
    private void LookAtEnemy()
    {
        Vector3 direction = enemy.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;

        TargetRotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    IEnumerator Dodging(Vector3 targetPos)
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, dashSmoothing * Time.deltaTime);
            yield return null;
        }

        LookAtEnemy();
        StopCoroutine("Dodging");
    }

    IEnumerator Rotating(Quaternion targetRot)
    {
        float t = 0;
        t = Mathf.Lerp(t, 1f, rotationSmoothing * Time.deltaTime);

        while (t > 0.001)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSmoothing * Time.deltaTime);
            yield return null;
        }

        StopCoroutine("Rotating");
    }
}
