using UnityEngine;

public class LicensingCards : MonoBehaviour
{
    private Animator animator;
    private Animation anim;

    private AnimationLoopCounter loopCounter;

    private void Start()
    {
        animator = GetComponent<Animator>();

        anim = GetComponent<Animation>();

        loopCounter = animator.GetBehaviour<AnimationLoopCounter>();
    }

    private void Update()
    {
        LicensingCardsAnimation();
    }

    public void LicensingCardsAnimation()
    {
        if (loopCounter != null && animator.enabled != false)
        {
            Debug.Log("发了: " + loopCounter.loopCount + "张");
            if (loopCounter.loopCount == 7)
            {
                animator.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
