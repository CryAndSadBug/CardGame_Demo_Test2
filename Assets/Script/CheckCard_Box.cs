using System.Collections.Generic;
using UnityEngine;

public class CheckCard_Box : MonoBehaviour
{
    static public CheckCard_Box instance;

    public List<Transform> sendCards;
    private MyCard myCard;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }

    private void Start()
    {
        myCard = MyCard.instance;
    }

    // �����������
    public void ClearCards()
    {
        foreach (var card in sendCards)
        {
            // ��ɾ����Ϸ����
            Destroy(card.gameObject);
            //���Ƴ�ԭ�б�� transform
            myCard.myCards.Remove(card);
        }
        sendCards.Clear();
        myCard.OrganizeCards(myCard.myCards, -5.6f, 0, 1.6f, 0);
    }
}
