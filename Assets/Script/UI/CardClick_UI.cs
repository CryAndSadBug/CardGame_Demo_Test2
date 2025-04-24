using UnityEngine;

public class CardClick_UI : MonoBehaviour 
{
    private SpriteRenderer sp;

    [SerializeField] private float yOffset;
    [SerializeField] private bool isCheck;

    [SerializeField] private Color checkColor;

    private float introduceTimer;

    private void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();

        CardIntroduce_UI.Instance.Hide();
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
            return;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yOffset);
        sp.color = checkColor;
        isCheck = true;

    }
    #endregion

    #region ���ͣ��������ʱ�ü�ʱ��ȥ�ж��Ƿ���ʾ��ϸ
    // ���ͣ���ڵ�ÿ֡������
    private void OnMouseOver()
    {
        introduceTimer += 1 * Time.deltaTime;

        if (introduceTimer >= .7f)
        {
            CardIntroduce_UI.Instance.Show();
            introduceTimer = 0;
        }
    }
    #endregion

    #region ����˳���ʱ��������ϸUI
    // ����˳�
    private void OnMouseExit()
    {
        CardIntroduce_UI.Instance.Hide();
    }
    #endregion
}
