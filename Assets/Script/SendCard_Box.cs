using System.Collections.Generic;
using UnityEngine;

public class SendCard_Box : MonoBehaviour
{
    static public SendCard_Box instance;

    public List<Transform> sendCards;
    private MyCard_Box myCard;

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
        myCard = MyCard_Box.instance;
    }

    // �����������
    public void ClearCards()
    {
        if (sendCards.Count <= 0)
            return;

        foreach (var card in sendCards)
        {
            // ��ɾ����Ϸ����
            Destroy(card.gameObject);
            //���Ƴ�ԭ�б�� transform
            myCard.myCards.Remove(card);
        }
        sendCards.Clear();

        myCard.OrganizeCards(myCard.myCards, -5.6f, 0, 1.6f, 0);

        myCard.canClearSendCardBox = false;
    }
}
