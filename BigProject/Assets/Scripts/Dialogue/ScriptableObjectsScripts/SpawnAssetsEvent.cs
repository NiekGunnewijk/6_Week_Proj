using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "SpawnAssetsEvent", menuName = "Dialogue/Event/SpawnAssetsEvent")]
    public class SpawnAssetsEvent : DialogueEvent
    {
        public GameObject obj;
        public override void Execute()
        {
            obj.gameObject.SetActive(true);
        }
    }
}