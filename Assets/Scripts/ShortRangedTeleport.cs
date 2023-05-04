using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool shortOnCooldown;
    private float baseCooldown;
    public float shortCooldown;
    private float cooldownTotal;

    public KeyCode m_short;
    public Transform shortTeleTarget;
    public GameObject Player;
    public bool cannotShortTele;

    // UI SECTION
    public Slider meterSliderShort;

    void Start()
    {
        shortOnCooldown = false;
        cooldownTotal = shortCooldown;
}
    void Update()
    {
        ShortTeleport();
    }
    void ShortTeleport()
    {
        if (Input.GetKey(m_short) && shortOnCooldown == false) // Activates Short-Ranged Teleportation if not on cooldown
        {
            if (cannotShortTele == false) // Checks a bool set by the CheckAhead.cs script - looking for bad tele outcomes.
            {
                Player.SetActive(false);
                playerPos.transform.position = shortTeleTarget.position;
                Player.SetActive(true);
                Player.GetComponent<FPSMovement>().m_velocity.y = 0f; // ensures player velocity vertically is reset.
                shortOnCooldown = true; // Enters a 'cooldown' state.
                baseCooldown = shortCooldown; // Cooldown time reset
            }
        }
        if (shortOnCooldown == true) // Cooldown calculations
        {
            baseCooldown -= Time.deltaTime;
            float percentageResult = baseCooldown / cooldownTotal;
            meterSliderShort.value = percentageResult;
            if (baseCooldown <= 0)
            {
                shortOnCooldown = false;
            }
        }
    }
}
