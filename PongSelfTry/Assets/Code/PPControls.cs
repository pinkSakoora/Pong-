using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

public class PPControls : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppVolume;
    private Bloom bloom;
    private ChromaticAberration chromaticAberration;
    private void Start()
    {
        ppVolume.profile.TryGetSettings(out bloom);
        ppVolume.profile.TryGetSettings(out chromaticAberration);
    }

    public void Bloom(bool value)
    {
        bloom.active = value;
    }

    public void ChromaticAberration(bool value)
    {
        chromaticAberration.active = value;
    }
}
