using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggersInteraction : MonoBehaviour
{
    [Header("Configurable por codigo via opciones")]
    public KeyCode interactionKey = KeyCode.E;
    [Header("Rango para interactuar con este objeto")]
    public Collider colTriggerEnabled;

    /// <summary>
    /// Para manejar los estados despues de haber interactuado con un objeto.
    /// vemos si quieren que se pueda reactivar o que quede inutilizable.
    /// </summary>
    private bool active = false;
    private bool wasActivated = false;

    [Header("Instanciar un objeto con las cosas que hagan falta")]
    public GameObject prefabInteraccion;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != GeneralInfo.PLAYER_LAYER || wasActivated) //evita repetir
            return;

        RaycastHit auxObstaculos;

        var rayCanInteract = new Ray(transform.position, other.transform.position); 
        var rayval = Physics.Raycast(rayCanInteract, out auxObstaculos, GeneralInfo.TERRAIN_LAYER);
        //Debug.Log(auxObstaculos);
        print(rayval);

        if (Input.GetKeyDown(interactionKey) && auxObstaculos.collider == null)
        {
            Debug.Log("Todo ok, no hay obstaculos, toque el input");
            active = wasActivated = true;

            NarrativeManager.instance.OnPrepairForInteraction(); // desactivo camara, movimiento, etc
            Instantiate(prefabInteraccion, transform.position, Quaternion.identity);
        }

        
    }
}
