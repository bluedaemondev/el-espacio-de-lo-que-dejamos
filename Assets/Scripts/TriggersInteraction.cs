using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggersInteraction : MonoBehaviour
{
    [Header("Configurable en Project Settings")]
    public string interactionAxis = "Interact";
    [Header("Rango para interactuar con este objeto")]
    public Collider colTriggerEnabled;

    /// <summary>
    /// Para manejar los estados despues de haber interactuado con un objeto.
    /// vemos si quieren que se pueda reactivar o que quede inutilizable.
    /// </summary>
    private bool active = false;
    private bool wasActivated = false;


    private void OnTriggerStay(Collider other)
    {
        RaycastHit auxObstaculos;

        var rayCanInteract = new Ray(transform.position, other.transform.position); //, out auxObstaculos);
        Debug.DrawRay(rayCanInteract.origin, rayCanInteract.direction, Color.red);
        //Physics.Raycast(rayCanInteract, out auxObstaculos,);

        Debug.Log(Physics.Raycast(rayCanInteract, out auxObstaculos));
        Debug.Log(auxObstaculos.collider.name);

        //if (auxObstaculos.transform)
        //{
        //    Debug.Log(canInteract && other.gameObject.layer == GeneralInfo.PLAYER_LAYER);
        //}


        // Si se mantiene dentro del rango del trigger, y es el jugador
        //if (other.gameObject.layer == GeneralInfo.PLAYER_LAYER)
        //{
        //    Debug.Log("Interactuando con " + this.name);
        //    active = true;
        //    wasActivated = true;
        //}
    }
}
