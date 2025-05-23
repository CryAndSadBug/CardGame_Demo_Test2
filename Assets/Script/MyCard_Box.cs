using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard_Box : MonoBehaviour
{
    public static MyCard_Box instance;

    private SendCard_Box sendCardBox;

    public List<Transform> myCards;
    [SerializeField] private List<GameObject> cardPrefabs;
    [SerializeField] private Transform newParent;
    public List<Transform> checkCards;

    public bool canLicensingCards;

    // ==================== test ====================
    public bool canClearSendCardBox;
    public bool usedSkill;
    // ==============================================

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
        sendCardBox = SendCard_Box.instance;
        UpdateMyCards();
    }

    /// <summary>
    ///  获取卡牌
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

        OrganizeCards(myCards, -5.6f, 0, 1.6f, 0);
    }

    /// <summary>
    /// 整理卡牌
    /// </summary>
    public void OrganizeCards(List<Transform> cardList, float x, float y, float xOffset, float yOffset)
    {
        /*if (myCards.Count > 0)
            myCards[0].localPosition = new Vector3(-5.6f, 0);

        for (int i = 1; i < myCards.Count; i++)
        {
            Vector3 lastCardPosition = myCards[i - 1].localPosition;

            myCards[i].localPosition = lastCardPosition + new Vector3(1.6f, 0);
        }*/

        if (cardList.Count > 0)
            cardList[0].localPosition = new Vector3(x, 0);

        for (int i = 1; i < cardList.Count; i++)
        {
            Vector3 lastCardPosition = cardList[i - 1].localPosition;

            cardList[i].localPosition = lastCardPosition + new Vector3(xOffset, yOffset);
        }
    }

    // 通过按钮绑定了弃牌方法
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

        OrganizeCards(myCards, -5.6f, 0, 1.6f, 0);
    }

    // 通过按钮绑定了发牌方法
    public void SendCard()
    {
        foreach (var card in checkCards)
        {
            sendCardBox.sendCards.Add(card);
            // 把卡牌的父对象变为 newParent
            card.transform.SetParent(newParent);
        }

        OrganizeCards(sendCardBox.sendCards, 80, 0, 0, 0);

        checkCards.Clear();

        if (sendCardBox.sendCards.Count <= 0)
            return;

        StartCoroutine(SendCardButtonIEnumerator());
    }

    /// <summary>
    /// 用于处理按下按钮后卡牌独有的特殊效果
    /// </summary>
    private IEnumerator SendCardButtonIEnumerator()
    {
        // 执行卡牌的独有方法
        Debug.Log("run to here");
        Test();

        //yield return new WaitForSeconds(2);
        yield return new WaitUntil(Test);

        // 1秒过渡 后续可增长自由发挥进行动画处理
        yield return new WaitForSeconds(1);

        sendCardBox.ClearCards();
        Debug.Log("执行清除发牌数组的方法");
    }


    // 模拟卡牌释放技能的过程
    private bool Test()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("执行卡牌的独有方法");
            usedSkill = true;
        }

        if (usedSkill)
        {
            canClearSendCardBox = true;
            usedSkill = false;
        }

        return canClearSendCardBox;
    }
}
