using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour
{
    public static MyCard instance;

    public List<Transform> myCards;
    [SerializeField] private List<GameObject> cardPrefabs;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateMyCards();

        GetCards();
    }

    /// <summary>
    ///  获取卡牌
    /// </summary>
    private void GetCards()
    {
        for (int i = 0; i <= 7 - myCards.Count; i++)
        {
            Instantiate(cardPrefabs[Random.Range(0, cardPrefabs.Count)], transform);
        }

        UpdateMyCards();
    }

    /// <summary>
    /// 更新牌库数组并整理卡牌
    /// </summary>
    public void UpdateMyCards()
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
