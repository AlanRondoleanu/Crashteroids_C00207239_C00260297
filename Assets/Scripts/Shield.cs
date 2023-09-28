using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public bool active = false;


    private bool shieldIsReady = true;
    private float shieldCooldownTimer;
    private const float SHIELD_COOLDOWN = 4f;
    private const float SHIELD_LIFETIME = 2f;

    void Update()
    {
        // Input to gain shiekd
        if (Input.GetKeyDown(KeyCode.E) && shieldIsReady == true)
        {
            shieldCooldownTimer = SHIELD_COOLDOWN;
            shieldIsReady = false;

            active = true;
            shield.gameObject.SetActive(true);
        }

        // Cooldown timer if ability is ready
        shieldCooldownTimer -= Time.deltaTime;
        if (shieldCooldownTimer <= 0.0f)
        {
            shieldIsReady = true;
        }

        // Shield lifetime
        if (shieldCooldownTimer <= SHIELD_COOLDOWN - SHIELD_LIFETIME)
        {
            active = false;
            shield.gameObject.SetActive(false);
        }

    }
}
