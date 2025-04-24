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

    #region 鼠标退出的时候隐藏详细UI
    // 鼠标退出
    private void OnMouseExit()
    {
        introduceBox.gameObject.SetActive(false);
    }
    #endregion

    #region 鼠标停留在上面时用计时器去判断是否显示详细
    // 鼠标停留在的每帧都调用
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
