using UnityEngine;

public class Cards : MonoBehaviour 
{
    [TextArea(1, 1)]
    [SerializeField] public string cardName;
    [TextArea(1, 1)]
    [SerializeField] public string cardType;
    [TextArea(1, 10)]
    [SerializeField] public string cardIntrocude;

    protected CardIntroduce_UI cardIntroduce_UI;
    private MyCard myCard;

    private SpriteRenderer sp;

    [SerializeField] private float yOffset;
    [SerializeField] private bool isCheck;

    [SerializeField] private Color checkColor;

    private float introduceTimer;

    protected virtual void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();

        CardIntroduce_UI.instance.Hide();

        cardIntroduce_UI = CardIntroduce_UI.instance;

        myCard = MyCard.instance;
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
            return;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yOffset);
        sp.color = checkColor;
        isCheck = true;

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

        DeleteCard(this);
        Debug.Log(this);
    }
    #endregion

    #region 鼠标退出的时候隐藏详细UI
    // 鼠标退出
    private void OnMouseExit()
    {
        CardIntroduce_UI.instance.Hide();
    }
    #endregion

    private void DeleteCard(Cards _target)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CardIntroduce_UI.instance.Hide();

            Destroy(_target.gameObject);
            myCard.myCards.Remove(_target.transform);
        }
    }
}
