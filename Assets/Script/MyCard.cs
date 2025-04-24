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

        GetCards();
    }

    // 获取卡牌
    private void GetCards()
    {
        for (int i = 0; i <= 7 - myCards.Count; i++)
        {
            newCard = Instantiate(cardPrefabs[Random.Range(0, cardPrefabs.Count)], transform);
        }
        
        UpdateMyCards();
    }

    // 更新卡牌数组
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
    /// 整理卡牌
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
