using UnityEngine;

public class LicensingCards : MonoBehaviour
{
    private Animator animator;
    private Animation anim;

    private AnimationLoopCounter loopCounter;
    private MyCard_Box myCard;

    private void Start()
    {
        animator = GetComponent<Animator>();

        anim = GetComponent<Animation>();

        loopCounter = animator.GetBehaviour<AnimationLoopCounter>();

        myCard = MyCard_Box.instance;
    }

    private void Update()
    {
        LicensingCardsAnimation();

        if (myCard.canLicensingCards)
            myCard.GetCards();
    }

    public void LicensingCardsAnimation()
    {
        if (loopCounter != null && animator.enabled != false)
        {
            Debug.Log("发了: " + loopCounter.loopCount + "张");
            if (loopCounter.loopCount == 8)
            {
                animator.enabled = false;
                Destroy(gameObject);

                myCard.canLicensingCards = true;
            }
        }
    }
}
