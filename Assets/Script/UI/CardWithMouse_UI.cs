using UnityEngine;

public class ClickCard_UI : MonoBehaviour
{

    private SpriteRenderer sp;
    private GameObject introduceBox;
    public float introduceTimer;

    [SerializeField] private float yOffset;
    [SerializeField] private bool isCheck;

    [SerializeField] private Color checkColor;

    private void Awake()
    {
        introduceBox = GameObject.Find("Introduce_ Box");
    }

    private void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();

        introduceBox.gameObject.SetActive(false);
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

    #region ����˳���ʱ��������ϸUI
    // ����˳�
    private void OnMouseExit()
    {
        introduceBox.gameObject.SetActive(false);
    }
    #endregion

    #region ���ͣ��������ʱ�ü�ʱ��ȥ�ж��Ƿ���ʾ��ϸ
    // ���ͣ���ڵ�ÿ֡������
    private void OnMouseOver()
    {
        introduceTimer += 1 * Time.deltaTime;

        // Debug.Log(introduceTimer);

        if (introduceTimer >= .7f)
        {
            introduceBox.gameObject.SetActive(true);
            introduceTimer = 0;
        }
    }
    #endregion
}
