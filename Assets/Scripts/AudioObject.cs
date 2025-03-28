using UnityEngine;

public class AudioObject : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip; 
    public Transform volumeTarget; 
    public float maxVolumeDistance = 10f; 

    private DraggablePiece draggablePiece;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        draggablePiece = GetComponent<DraggablePiece>();

        if (audioSource == null)
        {
            Debug.LogError("Missing AudioSource!");
        }
        else
        {
            audioSource.playOnAwake = false;
            audioSource.loop = true;
            audioSource.spatialBlend = 0f; // Ensure it's 2D audio
        }

        if (clip != null)
        {
            audioSource.clip = clip;
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to " + gameObject.name);
        }
    }

    private void Update()
    {
        if (draggablePiece.isBeingDragged)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            AdjustVolume();
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void AdjustVolume()
    {
        if (volumeTarget == null) return;

        float distance = Vector2.Distance(transform.position, volumeTarget.position);
        float volume = Mathf.Clamp01(1 - (distance / maxVolumeDistance));

        audioSource.volume = volume;
    }
}
