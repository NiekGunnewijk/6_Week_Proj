using CMGTSA.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "SpawnAssetsEvent", menuName = "Dialogue/Event/SpawnAssetsEvent")]
    public class SpawnAssetsEvent : DialogueEvent
    {
        [VerticalVector3]
        [SerializeField] private Vector3 spawnPoint;
        [Space][SerializeField] private GameObject spawnObject;
        [SerializeField] private int amount;
        [SerializeField] private float offsetX;
        [SerializeField] private float offsetZ;

        public override void Execute()
        {
            for (int i = 0; i < amount; i++)
            {
                
                float rangeX = Random.Range(-offsetX, offsetX);
                float rangeZ = Random.Range(-offsetZ, offsetZ);
                
                Vector3 spawnPotition = new Vector3(spawnPoint.x + rangeX, spawnPoint.y, spawnPoint.z + rangeZ);
                
                Instantiate(spawnObject,spawnPotition , Quaternion.identity);
            }
        }
        
        
    }
}