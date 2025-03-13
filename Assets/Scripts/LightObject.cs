using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightObject : MonoBehaviour
{
    private Light2D lightComponent;

    // Adjustable properties
    public bool isFlashing = false;
    public float flashFrequency = 1f;
    public Color lightColor = Color.white;
    public float lightRadius = 5f;
    public float lightIntensity = 1f;

    private float flashTimer = 0f;

    private void Awake()
    {
        lightComponent = GetComponent<Light2D>();
        UpdateLightProperties();
    }

    private void Update()
    {
        // Handle flashing effect
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;
            lightComponent.intensity = Mathf.Lerp(0.5f, 2f, Mathf.PingPong(flashTimer * flashFrequency, 1));
        }
        else
        {
            lightComponent.intensity = lightIntensity;  // Normal intensity when not flashing
        }
    }

    // Method to update the light properties
    public void UpdateLightProperties()
    {
        lightComponent.color = lightColor;
        lightComponent.pointLightOuterRadius = lightRadius;
        lightComponent.intensity = lightIntensity;
    }

    // Public methods to be used by UI elements
    public void SetColor(float r, float g, float b)
    {
        // Convert RGB values (0-255) to normalized values (0-1)
        lightColor = new Color(r / 255f, g / 255f, b / 255f);
        UpdateLightProperties();
    }

    public void SetRadius(float newRadius)
    {
        lightRadius = newRadius;
        UpdateLightProperties();
    }

    public void SetIntensity(float newIntensity)
    {
        lightIntensity = newIntensity;
        UpdateLightProperties();
    }

    public void SetFlashFrequency(float newFrequency)
    {
        flashFrequency = newFrequency;
    }

    public void ToggleFlashing(bool enableFlashing)
    {
        isFlashing = enableFlashing;
    }
}

