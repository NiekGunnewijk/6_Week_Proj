using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "GiveFriendshipEvent", menuName = "Dialogue/Event/GiveFriendshipEvent")]
    public class GiveFriendshipEvent : DialogueEvent
    {
        public CharacterData characterData;
        public int friendship;
        public override void Execute()
        {
            characterData.friendshipLevel += friendship;
        }
    }
}