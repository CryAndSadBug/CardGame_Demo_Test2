using UnityEngine;

public class AnimationLoopCounter : StateMachineBehaviour
{
    // ���ڴ洢ÿ������״̬��ѭ������
    public int loopCount = 0;

    // ������״̬�������״̬ʱ����
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // ������״̬������ʱ����
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.loop && stateInfo.normalizedTime >= 1.0f)
        {
            loopCount++;

            // ���� normalizedTime �Է�ֹ�ظ�����
            animator.Play(stateInfo.shortNameHash, layerIndex, 0f);
        }
    }
}
