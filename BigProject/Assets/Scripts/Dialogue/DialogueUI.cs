using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI SpeakerText;
    public TextMeshProUGUI DialogueText;
    
    public void DisplayDialogue(CharacterData characterData)
    {
        SpeakerText.text = characterData.characterName;
        DialogueText.text = characterData.story[0].text;
    }
}
