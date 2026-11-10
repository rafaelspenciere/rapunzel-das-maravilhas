using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicaSource;
    public AudioSource efeitosSource;

    [Header("Audio Clips")]
    public AudioClip musicaFundo;
    public AudioClip somJump;
    public AudioClip somCoin;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicaSource.clip = musicaFundo;
        musicaSource.loop = true;
        musicaSource.Play();
    }

    public void TocarJump()
    {
        efeitosSource.PlayOneShot(somJump);
    }

    public void TocarCoin()
    {
        efeitosSource.PlayOneShot(somCoin);
    }
}