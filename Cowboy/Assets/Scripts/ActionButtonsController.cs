using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsController : MonoBehaviour
{
    public GameObject[] actionButtons; //Lista con los botones

    public bool takeAction = false;

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
    }

    /// <summary>
    /// Activa o desactiva los botones de acción
    /// </summary>
    /// <param name="state">Nuevo estado de los botones de acción.</param>
    private void SetActionButtons(bool state)
    {
        foreach (GameObject button in actionButtons)
        {
            button.gameObject.SetActive(state);
        }
    }
}
