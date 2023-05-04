using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongRangedTeleport : MonoBehaviour
{
    private GameObject Player;
    public Transform playerPos;
    public bool longOnCooldown;
    private float baseCooldown;
    public float longCooldown = 8f;
    private float longCooldownTotal;
    public KeyCode m_long;
    private Vector3 teleLDestination;
    
    public float longTeleRange = 1000f;
    public Slider meterSliderLong;

    public LayerMask layers;

    void Start()
    {
        Player = this.gameObject;
        longOnCooldown = false;
        longCooldownTotal = longCooldown;
    }
    void LongTeleport()
    {
        if (Input.GetKey(m_long) && longOnCooldown == false) // Activates Long-Range Teleportation
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Finding point to teleport to
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, longTeleRange, layers))
            {
                if ((hit.collider.CompareTag("Ceiling")) || (hit.collider.CompareTag("LeadCeiling")))
                {
                    teleLDestination = hit.point + new Vector3(0, -2, 0);
                    LTeleport();
                }
                else
                {
                    teleLDestination = hit.point;
                    LTeleport();
                }

                longOnCooldown = true;
                baseCooldown = longCooldown; // Cooldown reset
            }
        }
        else if (longOnCooldown == true) // Cooldown calculations
        {
            float percentageResult = baseCooldown / longCooldownTotal;
            meterSliderLong.value = percentageResult;
            baseCooldown -= Time.deltaTime;

            if (baseCooldown <= 0)
            {
                longOnCooldown = false;
            }
        }
    }
    void Update()
    {
        LongTeleport();

    }

    void LTeleport()
    {
        Debug.Log("LTeleport to " + teleLDestination);
        Player.SetActive(false);
        playerPos.transform.position = teleLDestination; // Teleport
        Player.SetActive(true);
    }

}
