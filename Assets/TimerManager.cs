using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    [SerializeField] private TextMeshProUGUI tempoAtualText;
    [SerializeField] private TextMeshProUGUI tempoFinalText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject telaFinal;

    private float tempoRestante;
    private float tempoTotal;
    private bool finalizado;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameController.Init();
        Time.timeScale = 1f;
        tempoRestante = 7f;
        tempoTotal = 0f;
        finalizado = false;

        if (tempoFinalText != null)
            tempoFinalText.gameObject.SetActive(false);

        if (telaFinal != null)
            telaFinal.SetActive(false);
    }

    void Update()
    {
        if (finalizado)
            return;

        tempoRestante -= Time.deltaTime;
        tempoTotal += Time.deltaTime;

        if (tempoAtualText != null)
            tempoAtualText.text = "Tempo: " + Mathf.Max(0f, tempoRestante).ToString("F2");

        if (scoreText != null)
            scoreText.text = "Score: " + GameController.Score;

        if (tempoRestante <= 0f)
        {
            FinalizarJogo();
            return;
        }

        if (GameController.gameOver)
            FinalizarJogo();
    }

    public void AdicionarTempo(float tempoExtra)
    {
        if (finalizado)
            return;

        tempoRestante += tempoExtra;
    }

    private void FinalizarJogo()
    {
        if (finalizado)
            return;

        finalizado = true;

        if (tempoAtualText != null)
            tempoAtualText.gameObject.SetActive(false);

        if (tempoFinalText != null)
        {
            tempoFinalText.gameObject.SetActive(true);
            tempoFinalText.text = "Tempo final: " + tempoTotal.ToString("F2");
        }

        if (telaFinal != null)
            telaFinal.SetActive(true);

        Time.timeScale = 0f;
    }
}