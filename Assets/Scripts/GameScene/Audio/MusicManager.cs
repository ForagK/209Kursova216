using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    AudioSource audioSource;

    [SerializeField] AudioClip battleTheme;
    [SerializeField] AudioClip bossTheme;
    [SerializeField] AudioClip victoryTheme;

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
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        PlayBattleMusic();
    }
    public void PlayBattleMusic()
    {
        audioSource.clip = battleTheme;
        audioSource.Play();
    }
    public void PlayBossMusic()
    {
        audioSource.clip = bossTheme;
        audioSource.Play();
    }
    public void PlayVictoryMusic()
    {
        audioSource.clip = victoryTheme;
        audioSource.Play();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
