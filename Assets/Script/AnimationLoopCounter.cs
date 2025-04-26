using UnityEngine;

public class AnimationLoopCounter : StateMachineBehaviour
{
    // 用于存储每个动画状态的循环次数
    public int loopCount = 0;

    // 当动画状态机进入该状态时调用
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // 当动画状态机更新时调用
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.loop && stateInfo.normalizedTime >= 1.0f)
        {
            loopCount++;

            // 重置 normalizedTime 以防止重复计数
            animator.Play(stateInfo.shortNameHash, layerIndex, 0f);
        }
    }
}
