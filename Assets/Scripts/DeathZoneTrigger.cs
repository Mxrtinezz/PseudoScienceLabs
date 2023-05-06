using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject spawnPoint;
    private Transform spawnLocation;

    private CharacterController charController;

    private void Start()
    {
        spawnLocation = spawnPoint.transform;
        charController = thePlayer.gameObject.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            charController.enabled = false;
            Debug.Log("Player is in da death zone!");
            thePlayer.transform.position = spawnLocation.position;
            charController.enabled = true;
        }
    }

}
