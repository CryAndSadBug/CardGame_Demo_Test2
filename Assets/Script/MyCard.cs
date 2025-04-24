using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyCard : MonoBehaviour
{
    [SerializeField] private List<Transform> myCards;
    [SerializeField] private List<GameObject> cardPrefabs;
    private GameObject newCard;

    private void Start()
    {
        UpdateMyCards();

        if (myCards.Count <= 0)
        {
            GetCards();
        }
    }

    private void GetCards()
    {
        for (int i = 0; i <= 7; i++)
        {
            newCard = Instantiate(cardPrefabs[Random.Range(0, cardPrefabs.Count)], transform);
        }
        
        UpdateMyCards();
    }

    private void UpdateMyCards()
    {
        myCards.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            myCards.Add(child);
        }

        OrganizeCards();
    }

    /// <summary>
    /// ÕûÀí¿¨ÅÆ
    /// </summary>
    private void OrganizeCards()
    {
        for (int i = 1; i < myCards.Count; i++)
        {
            Vector3 lastCardPosition = myCards[i - 1].localPosition;

            myCards[i].localPosition = lastCardPosition + new Vector3(1.6f, 0);
        }
    }
}
