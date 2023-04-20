using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongRangedCooldown : MonoBehaviour
{
    public bool longOnCooldown;
    private float baseCooldown;
    public float longCooldown = 10f;
    public float cooldownTotal = 10f;
    public KeyCode m_long;
    public Slider meterSlider;
    void Start()
    {
        longOnCooldown = false;
    }
    void LongTeleport()
    {
        if (Input.GetKey(m_long) && longOnCooldown == false)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                longOnCooldown = true;
                baseCooldown = longCooldown;
            }
        }
        else if (longOnCooldown == true)
        {
            float percentageResult = baseCooldown / cooldownTotal;
            meterSlider.value = percentageResult;
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
}