using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Condition/FriendshipCondition")]
    public class FriendshipCondition : DialogueCondition
    {
        public int friendshipLevel;
        public CharacterData characterData;
        public override bool Evaluate()
        {
            return characterData.friendshipLevel>= friendshipLevel;
        }
    }
}