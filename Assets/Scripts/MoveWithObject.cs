using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObject : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (player == null) // If player is not assigned in the Inspector, find it based on tag.
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform; // ties the player's transform to this object's transform.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something exited");
        if (other.gameObject == player)
        {
            Debug.Log("IT WAS DA PLAYA");
            player.transform.parent = null; // unties the player's transform from this object's transform.
        }
    }


}
