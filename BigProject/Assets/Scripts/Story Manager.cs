using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private GameObject storyBook;
    
    [Space][SerializeField] private TextMeshProUGUI storyText; 
    
    [Space] [SerializeField] private TMP_Text pagination;
    
    private string _story;

    private void ShowStory()
    {
        _story = characterData.mainStory.storyPart + "\n \n";
        foreach (var node in characterData.storyNodes)
        {
            _story += node.storyPart + "\n \n";
        }
        storyText.text = _story;
    }
    
    private void UpdatePagination()
    {
        pagination.text = storyText.pageToDisplay.ToString();
    }
    
    public void PreviousPage()
    {
        if (storyText.pageToDisplay < 1)
        {
            storyText.pageToDisplay = 1;
            return;
        }

        if (storyText.pageToDisplay - 1 > 1)
            storyText.pageToDisplay -= 1;
        else
            storyText.pageToDisplay = 1;

        UpdatePagination();
    }

    public void NextPage()
    {
        if (storyText.pageToDisplay >= storyText.textInfo.pageCount)
            return;

        /*if (leftSide.pageToDisplay >= leftSide.textInfo.pageCount - 1)
        {
            leftSide.pageToDisplay = leftSide.textInfo.pageCount - 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        }*/
        else
        {
            storyText.pageToDisplay += 1;
        }

        UpdatePagination();
    }

    void ChangeCharacter(CharacterData character)
    {
        characterData = character;
        characterName.text = character.characterName;
    }

    public void OpenBook()
    {
        storyBook.SetActive(true);
        UpdatePagination();

        if (storyText.text == _story)
            return;

        ShowStory();
    }

    public void CloseBook()
    {
        storyBook.SetActive(false);
    }
}
