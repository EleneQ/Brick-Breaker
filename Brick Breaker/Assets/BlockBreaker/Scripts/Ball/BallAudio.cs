using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] BallMovement ball;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] ballSounds;

    private void OnEnable()
    {
        ball.OnBallCollision += PlayBallSounds;
    }

    private void PlayBallSounds()
    {
        int randomIndex = Random.Range(0, ballSounds.Length);

        AudioClip clip = ballSounds[randomIndex];
        audioSource.PlayOneShot(clip);
    }

    private void OnDisable()
    {
        ball.OnBallCollision -= PlayBallSounds;
    }
}
