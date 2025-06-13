using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPopup : MonoBehaviour
{
    [System.Serializable]
    public struct TutorialPage
    {
        [TextArea(1, 2)]
        public string header;
        [TextArea(3, 10)]
        public string subText;
    }

    public TutorialPage[] tutorialPages;

    public TextMeshProUGUI headerText;    
    public TextMeshProUGUI subText;       
    public Button leftButton;
    public Button rightButton;
    public Button closeButton;

    private int currentPage = 0;
    private bool isActive = false;

    private void Awake()
    {
        leftButton.onClick.AddListener(OnLeft);
        rightButton.onClick.AddListener(OnRight);
        closeButton.onClick.AddListener(ClosePopup);
    }

    private void Start()
    {
        ShowPopup();
    }

    public void ShowPopup()
    {
        isActive = true;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        currentPage = 0;
        UpdateTutorial();
    }

    private void OnLeft()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateTutorial();
        }
    }

    private void OnRight()
    {
        if (currentPage < tutorialPages.Length - 1)
        {
            currentPage++;
            UpdateTutorial();
        }
    }

    private void UpdateTutorial()
    {
        if (headerText != null)
            headerText.text = tutorialPages[currentPage].header;
        if (subText != null)
            subText.text = tutorialPages[currentPage].subText;

        leftButton.interactable = currentPage > 0;
        rightButton.interactable = currentPage < tutorialPages.Length - 1;
    }

    public void ClosePopup()
    {
        isActive = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
