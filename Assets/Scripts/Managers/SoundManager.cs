using UnityEngine;

namespace CM.Managers
{
    /// <summary>
    /// Manages sound effects and background music in the game.
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the SoundManager.
        /// </summary>
        public static SoundManager Instance { get; private set; }

        [Header("Sound Effects")]
        /// <summary>
        /// Sound effect played when a card is flipped.
        /// </summary>
        public AudioClip flipSound;

        /// <summary>
        /// Sound effect played when a match is found.
        /// </summary>
        public AudioClip matchSound;

        /// <summary>
        /// Sound effect played when a mismatch occurs.
        /// </summary>
        public AudioClip mismatchSound;

        /// <summary>
        /// Sound effect played when the game ends.
        /// </summary>
        public AudioClip gameEndSound;

        [Header("Background Music")]
        /// <summary>
        /// Background music played during gameplay.
        /// </summary>
        public AudioClip backgroundMusic;

        private AudioSource audioSource;

        private void Awake()
        {
            // Initialize the singleton instance and set up the audio source
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

        /// <summary>
        /// Plays a sound effect.
        /// </summary>
        /// <param name="clip">The audio clip to play.</param>
        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        /// <summary>
        /// Plays background music on loop.
        /// </summary>
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
