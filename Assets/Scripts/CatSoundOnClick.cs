using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class CatSoundOnClick : MonoBehaviour
{
    [SerializeField] public AudioClip catSound;

    private AudioSource audioSource;
    private Cat _cat;

    private void Awake()
    {
        _cat = GetComponent<Cat>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _cat.Down += PlayCatSound;
    }

    private void OnDisable()
    {
        _cat.Down -= PlayCatSound;
    }

    private void PlayCatSound()
    {
        audioSource.PlayOneShot(catSound);
    }
}