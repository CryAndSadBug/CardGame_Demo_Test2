using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour 
{
    [TextArea(1, 1)]
    [SerializeField] public string cardName;
    [TextArea(1, 1)]
    [SerializeField] public string cardType;
    [TextArea(1, 10)]
    [SerializeField] public string cardIntrocude;

    protected CardIntroduce_UI cardIntroduce_UI;
    private MyCard_Box myCard;

    private SpriteRenderer sp;

    [SerializeField] private float yOffset;
    [SerializeField] public bool isCheck;

    [SerializeField] private Color checkColor;

    private float introduceTimer;

    protected virtual void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();

        CardIntroduce_UI.instance.Hide();

        cardIntroduce_UI = CardIntroduce_UI.instance;

        myCard = MyCard_Box.instance;
    }

    #region 鼠标按下选中卡牌的偏移 和 变色
    // 鼠标按下
    private void OnMouseDown()
    {
        if (isCheck)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - yOffset);
            sp.color = Color.white;
            isCheck = false;
            myCard.checkCards.Remove(transform);
            return;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yOffset);
        sp.color = checkColor;
        isCheck = true;

        myCard.checkCards.Add(transform);

    }
    #endregion

    #region 鼠标停留在上面时用计时器去判断是否显示详细
    // 鼠标停留在的每帧都调用
    private void OnMouseOver()
    {
        introduceTimer += 1 * Time.deltaTime;

        if (introduceTimer >= .7f)
        {
            CardIntroduce_UI.instance.Show();
            cardIntroduce_UI.SetIntroduce(this, cardName, cardType, cardIntrocude);
            introduceTimer = 0;
        }
    }
    #endregion

    #region 鼠标退出的时候隐藏详细UI
    // 鼠标退出
    private void OnMouseExit()
    {
        CardIntroduce_UI.instance.Hide();
    }
    #endregion
}
