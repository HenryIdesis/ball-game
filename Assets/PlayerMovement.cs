using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource as_audio;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        as_audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coletavel"))
        {
            as_audio.Play();
            GameController.Collect();

            if (TimerManager.Instance != null)
                TimerManager.Instance.AdicionarTempo(2f);

            Destroy(other.gameObject);
        }
    }

    public void ReiniciarJogo()
    {
        Debug.Log("REINICIAR CLICADO");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}