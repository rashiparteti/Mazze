using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarUI : MonoBehaviour
{
    public Text ammoText;          // UI Text for displaying the ammo count
    public Image reloadBar;        // UI Image for displaying the reload bar
    public Firing firingScript;    // Reference to the Firing script

    private int maxAmmo;
    private int currentAmmo;

    void Start()
    {
        if (firingScript == null)
        {
            Debug.LogError("Firing script reference is missing!");
            return;
        }

        // Get the initial values from the Firing script
        maxAmmo = firingScript.maxAmmo;
        UpdateAmmoUI(); // Initialize the ammo UI
        reloadBar.fillAmount = 1f; // Full reload bar at the start
    }

    void Update()
    {
        // Get the current ammo count from the firing script
        currentAmmo = firingScript.GetCurrentAmmo();
        UpdateAmmoUI();
        UpdateReloadBar();
    }

    void UpdateAmmoUI()
    {
        // Update the ammo text UI
        ammoText.text = $"{currentAmmo}/{maxAmmo}";
    }

    void UpdateReloadBar()
    {
        // Update the reload bar fill amount based on current ammo
        reloadBar.fillAmount = (float)currentAmmo / maxAmmo;

        // Optional: If you want a minimum fill amount to indicate the bar is not empty
        reloadBar.fillAmount = Mathf.Max(reloadBar.fillAmount, 0.01f);
    }
}
