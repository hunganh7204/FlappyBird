using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;
    public AudioClip scoreSFX;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        scored = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scored) return;
        if (collision.CompareTag("Player"))
        {
            scored = true;
            GameManager.Instance.AddScore(1);
            if (scoreSFX != null) audioSource.PlayOneShot(scoreSFX);
        }
    }
}
