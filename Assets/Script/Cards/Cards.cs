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

    #region ��갴��ѡ�п��Ƶ�ƫ�� �� ��ɫ
    // ��갴��
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

    #region ���ͣ��������ʱ�ü�ʱ��ȥ�ж��Ƿ���ʾ��ϸ
    // ���ͣ���ڵ�ÿ֡������
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

    #region ����˳���ʱ��������ϸUI
    // ����˳�
    private void OnMouseExit()
    {
        CardIntroduce_UI.instance.Hide();
    }
    #endregion
}
