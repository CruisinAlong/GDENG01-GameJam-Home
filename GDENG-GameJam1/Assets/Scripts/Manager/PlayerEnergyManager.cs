using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEnergyManager : MonoBehaviour
{
    public static PlayerEnergyManager Instance { get; private set; }


    public float maxEnergy = 100f;
    public float currentEnergy = 100f;
    public float drainRate = 5f;
    public float energyGainPerClean = 10f;

    public Image batteryFillImage;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public Image flashingBatteryImage;
    public float blinkInterval = 0.5f; // Time in seconds between blinks

    private bool isGameOver = false;
    private float blinkTimer = 0f;
    private bool isBatteryVisible = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }

    private void Start()
    {
        currentEnergy = maxEnergy;
        UpdateBatteryUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (flashingBatteryImage != null)
            flashingBatteryImage.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentEnergy -= drainRate * Time.deltaTime;
            currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);

            UpdateBatteryUI();

            if (currentEnergy <= 0f)
            {
                GameOver();
            }
        }
        else if (flashingBatteryImage != null)
        {
            // Blinking logic
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= blinkInterval)
            {
                isBatteryVisible = !isBatteryVisible;
                flashingBatteryImage.gameObject.SetActive(isBatteryVisible);
                blinkTimer = 0f;
            }
        }
    }

    public void GainEnergy(float amount)
    {
        if (isGameOver) return;
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0f, maxEnergy);
        UpdateBatteryUI();
    }

    private void UpdateBatteryUI()
    {
        if (batteryFillImage != null)
        {
            float percent = currentEnergy / maxEnergy;
            batteryFillImage.fillAmount = percent;
            if (percent > 0.6f)
                batteryFillImage.color = Color.green;
            else if (percent > 0.3f)
                batteryFillImage.color = Color.yellow;
            else
                batteryFillImage.color = Color.red;
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        // Ensure the battery icon is visible at the start of game over
        if (flashingBatteryImage != null)
        {
            flashingBatteryImage.gameObject.SetActive(true);
            isBatteryVisible = true;
            blinkTimer = 0f;
        }
        // Optionally, pause the game here
        // Time.timeScale = 0f;
    }
}
