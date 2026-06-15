using UnityEngine;
using System.Collections.Generic;
using System;

public class CharacterSelector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Dictionary<string, Collectible> Collectibles;
    private List<Collectible> collectedCollectibles;
    [SerializeField] private List<Collectible> collectableCollectables;
    public static event Action<Collectible> OnCollectedChar;


    private void OnEnable()
    {
        NFC.OnNFCRetrieved += Plavehodelr;
        collectedCollectibles = new List<Collectible>();
        collectableCollectables = new List<Collectible>();
        Collectibles = new Dictionary<string, Collectible>();

        if(collectableCollectables != null)
        for (int i = 0; i < collectableCollectables.Count; i++)
        {
            Collectibles.Add(collectableCollectables[i].CharData.id, collectableCollectables[i]);
        }
    }

    private void OnDisable()
    {
        NFC.OnNFCRetrieved += Plavehodelr;
    }


    private void Plavehodelr(string str)
    {
        Collectible collectible;
        if (Collectibles.TryGetValue(str, out collectible))
        {
            if (!collectedCollectibles.Contains(collectible))
            {
                collectedCollectibles.Add(collectible);

                OnCollectedChar(collectible);
                // run code
            }
        }
    }
}
