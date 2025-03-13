using UnityEngine;
using UnityEngine.UI;

public class LightUIManager : MonoBehaviour
{
   private static LightObject selectedLight; 
   
    public Slider radiusSlider;
    public Slider intensitySlider;
    public Slider flashFrequencySlider;
    public Toggle flashingToggle;
    
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private void Start()
    {
        radiusSlider.onValueChanged.AddListener(UpdateLightRadius);
        intensitySlider.onValueChanged.AddListener(UpdateLightIntensity);
        flashFrequencySlider.onValueChanged.AddListener(UpdateFlashFrequency);
        flashingToggle.onValueChanged.AddListener(ToggleFlashing);

        redSlider.onValueChanged.AddListener(UpdateLightColor);
        greenSlider.onValueChanged.AddListener(UpdateLightColor);
        blueSlider.onValueChanged.AddListener(UpdateLightColor);
    }

    public static void SetSelectedLight(LightObject newLight)
    {
        if (newLight == null) return;

        selectedLight = newLight;
        Debug.Log("Selected new light: " + selectedLight.gameObject.name);
    }

    private void UpdateLightRadius(float value)
    {
        if (selectedLight != null)
            selectedLight.SetRadius(value);
    }

    private void UpdateLightIntensity(float value)
    {
        if (selectedLight != null)
            selectedLight.SetIntensity(value);
    }

    private void UpdateFlashFrequency(float value)
    {
        if (selectedLight != null)
            selectedLight.SetFlashFrequency(value);
    }

    private void ToggleFlashing(bool value)
    {
        if (selectedLight != null)
            selectedLight.ToggleFlashing(value);
    }

    private void UpdateLightColor(float value)
    {
        if (selectedLight != null)
        {
            float r = redSlider.value;
            float g = greenSlider.value;
            float b = blueSlider.value;
            selectedLight.SetColor(r, g, b);
        }
    }
}
