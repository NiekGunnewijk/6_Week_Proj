using UnityEngine;

namespace Dialogue
{
    public abstract class DialogueEvent : ScriptableObject
    {
        public abstract void Execute();
    }
}