using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score = 0;
    public bool isGameOver = false;

    [SerializeField] private GameObject shipModel;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject titleText;
    [SerializeField] private Spawner spawner;
    public Speed speed;

    private static Game instance;

    private void Start()
    {
        instance = this;
        titleText.SetActive(true);
        gameOverText.enabled = false;
        scoreText.enabled = false;
        startGameButton.SetActive(true);
    }

    public static void GameOver()
    {
        instance.titleText.SetActive(true);
        instance.startGameButton.SetActive(true);
        instance.isGameOver = true;
        instance.spawner.StopSpawning();
        instance.shipModel.GetComponent<Ship>().Explode();
        instance.gameOverText.enabled = true;
    }

    public void NewGame()
    {
        isGameOver = false;
        titleText.SetActive(false);
        startGameButton.SetActive(false);
        shipModel.transform.localPosition = new Vector3(0, 0, 0);
        score = 0;
        scoreText.text = $"Score: {score}";
        scoreText.enabled = true;
        spawner.BeginSpawning();
        shipModel.GetComponent<Ship>().RepairShip();
        spawner.ClearAsteroids();
        gameOverText.enabled = false;
        speed.Reset();
    }

    public static void AsteroidDestroyed()
    {
        instance.score++;
        instance.scoreText.text = $"Score: {instance.score}";
    }

    public Ship GetShip()
    {
        return shipModel.GetComponent<Ship>();
    }

    public Spawner GetSpawner()
    {
        return spawner.GetComponent<Spawner>();
    }
}
