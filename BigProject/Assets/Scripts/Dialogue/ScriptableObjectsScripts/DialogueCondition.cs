using UnityEngine;
namespace Dialogue
{
    public abstract class DialogueCondition : ScriptableObject
    {
        public abstract bool Evaluate();
    }
}