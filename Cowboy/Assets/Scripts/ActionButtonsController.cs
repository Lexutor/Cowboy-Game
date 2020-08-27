using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsController : MonoBehaviour
{
    [Header("Botones de acción")]
    public GameObject[] actionButtons; //Lista con los botones
    public GameObject[] shootActionButtons; //Lista con las opciones de disparo

    public bool takeAction = false, shootAction = false;

    private void Awake() {
        SetActionButtons(false);
        SetShootActionButtons(false);
    }

    void LateUpdate()
    {
        if (takeAction)
        {
            SetActionButtons(true);
        }
        else
        {
            SetActionButtons(false);
        }

        if (shootAction)
        {
            SetShootActionButtons(true);
        }
        else
        {
            SetShootActionButtons(false);
        }
    }

    /// <summary>
    /// Activa o desactiva los botones de acción.
    /// </summary>
    /// <param name="state">Nuevo estado de los botones de acción.</param>
    private void SetActionButtons(bool state)
    {
        foreach (GameObject button in actionButtons)
        {
            button.gameObject.SetActive(state);
        }
    }

    /// <summary>
    /// Activa o desactiva los botones de opción de disparo.
    /// </summary>
    /// <param name="state">Nuevo estado de los botones de acción.</param>
    private void SetShootActionButtons(bool state)
    {
        foreach (GameObject button in shootActionButtons)
        {
            button.gameObject.SetActive(state);
        }
    }
}
