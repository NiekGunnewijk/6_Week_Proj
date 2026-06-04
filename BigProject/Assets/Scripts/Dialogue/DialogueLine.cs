using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Dialogue
{
    [System.Serializable]
    public class DialogueLine
    {
        public string character;
        [TextArea]
        public string text;
    }
}