using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortRangedCooldown : MonoBehaviour
{
    public bool shortOnCooldown;
    private float baseCooldown;
    public float shortCooldown = 3f;
    public float cooldownTotal = 3f;
    public KeyCode m_short;
    public Slider meterSlider;

    // Start is called before the first frame update
    void Start()
    {
        shortOnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShortTeleport();
    }

    void ShortTeleport()
    {
        if (Input.GetKey(m_short) && shortOnCooldown == false)
        {
            shortOnCooldown = true;
            baseCooldown = shortCooldown;
        }
        if (shortOnCooldown == true)
        {
            float percentageResult =  baseCooldown / cooldownTotal;
            meterSlider.value = percentageResult;
            baseCooldown -= Time.deltaTime;
            if (baseCooldown <= 0)
            {
                shortOnCooldown = false;
            }
        }
    }
}
