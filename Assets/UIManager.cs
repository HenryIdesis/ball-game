using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    private bool jogoIniciado = false;

    void Start()
    {
        endGamePanel.SetActive(false);
        jogoIniciado = true;
    }

    void FixedUpdate()
    {
        if (jogoIniciado && GameController.gameOver)
        {
            endGamePanel.SetActive(true);
        }
    }
}