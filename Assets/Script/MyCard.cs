using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour
{
    public static MyCard instance;

    public List<Transform> myCards;
    [SerializeField] private List<GameObject> cardPrefabs;
    [SerializeField] private Transform newParent;
    public List<Transform> checkCards;

    public bool canLicensingCards;

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
    }

    /// <summary>
    ///  ��ȡ����
    /// </summary>
    public void GetCards()
    {
        for (int i = 0; i <= 7 - myCards.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefabs[Random.Range(0, cardPrefabs.Count)], transform);

            newCard.name = newCard.name + "_" + i;
        }
        canLicensingCards = false;

        UpdateMyCards();
    }

    /// <summary>
    /// �����ƿ����鲢������
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
    /// ������
    /// </summary>
    private void OrganizeCards()
    {
        if (myCards.Count > 0)
            myCards[0].localPosition = new Vector3(-5.6f, 0);

        for (int i = 1; i < myCards.Count; i++)
        {
            Vector3 lastCardPosition = myCards[i - 1].localPosition;

            myCards[i].localPosition = lastCardPosition + new Vector3(1.6f, 0);
        }
    }

    // ͨ����ť�������Ʒ���
    public void DeleteCard()
    {
        if (checkCards.Count <= 0)
            return;

        foreach (var card in checkCards)
        {
            Destroy(card.gameObject);
            myCards.Remove(card);
        }

        checkCards.Clear();

        OrganizeCards();
    }
    
    // ͨ����ť���˷��Ʒ���
    public void SendCard()
    {
        foreach(var card in checkCards)
        {
            CheckCard_Box.instance.sendCards.Add(card);
            card.transform.SetParent(newParent);
        }
        checkCards.Clear();
    }
}
