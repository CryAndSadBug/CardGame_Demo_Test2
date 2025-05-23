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

    // 清除发牌数组
    public void ClearCards()
    {
        foreach (var card in sendCards)
        {
            // 先删除游戏物体
            Destroy(card.gameObject);
            //再移除原列表的 transform
            myCard.myCards.Remove(card);
        }
        sendCards.Clear();
        myCard.OrganizeCards(myCard.myCards, -5.6f, 0, 1.6f, 0);
    }
}
