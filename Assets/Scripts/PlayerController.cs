using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    public AudioClip flapSFX;
    private Rigidbody2D rb;
    private bool isAlive = true;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        float angle = Mathf.Clamp(rb.linearVelocity.y*5f, -90f, 45f);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void Flap()
    {
        rb.linearVelocity = Vector2.up * flapForce;
        if (flapSFX != null) audioSource.PlayOneShot(flapSFX);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        GameManager.Instance.PlayerDied();
    }

    public void ResetPlayer(Vector3 startpos)
    {
        transform.position = startpos;
        rb.linearVelocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
        isAlive = true;
    }
}
