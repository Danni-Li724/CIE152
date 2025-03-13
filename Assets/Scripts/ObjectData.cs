using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public Vector3 position;
    public float rotation;
    public bool isLight;
    public Color lightColor;
    public float lightIntensity;
    public float lightRadius;
    public float lightAngle;
    public bool isFlashing;
    public float flashFrequency;
}