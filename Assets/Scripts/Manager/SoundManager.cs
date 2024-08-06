using UnityEngine;


namespace CM.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [Header("Sound Effects")]
        public AudioClip flipSound;
        public AudioClip matchSound;
        public AudioClip mismatchSound;
        public AudioClip gameEndSound;

        [Header("Background Music")]
        public AudioClip backgroundMusic;

        private AudioSource audioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                audioSource = GetComponent<AudioSource>();
                PlayBackgroundMusic();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        private void PlayBackgroundMusic()
        {
            if (backgroundMusic != null)
            {
                audioSource.clip = backgroundMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }
}
