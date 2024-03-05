using UnityEngine;
using UnityEngine.UI;

public class UIInputTest : MonoBehaviour
{
    [SerializeField] private InputReaderTest input;
    [SerializeField] private Button[] buttonList;
    private int currentIndex;
    public Color highlightColor = Color.red;
    public Color OriginalColor = Color.white;
    private Button currentBtn;


    private void OnEnable()
    {
        input.OnUIEvent += UINavigation;
        input.OnUIEnter += EventPlay;
        input.OnGamePause += GamePause;
    }

    private void OnDisable()
    {
        input.OnUIEvent -= UINavigation;
        input.OnUIEnter -= EventPlay;
        
    }

    private void Awake()
    {
        OriginalColor = buttonList[0].GetComponent<Button>().image.color;
        buttonList[0].GetComponent<Button>().image.color = highlightColor;
        currentBtn = buttonList[0];
    }


    private void UINavigation(bool value)
    {
        if (value)
        {
            SetButtonHighlight(1);
            return;
        }

    }



    private void SetButtonHighlight(int index)
    {
        currentIndex += index;
        if (currentIndex >= buttonList.Length || currentIndex < 0)
        {
            currentIndex = 0;
        }
        currentBtn = buttonList[currentIndex];
        SetButtonsColor();
        buttonList[currentIndex].GetComponent<Button>().image.color = highlightColor;
    }

    private void SetButtonsColor()
    {
        foreach (var button in buttonList)
        {
            button.GetComponent<Button>().image.color = OriginalColor;

        }
    }

    private void EventPlay(bool value)
    {
        if(value)
        Debug.Log(currentBtn.GetComponent<Button>().name);
    }

    private void GamePause(bool value)
    {

    }
}
