using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currenState;
    public PlayerController playerController;        //PlayerController�� ����

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();   //���� ������Ʈ�� �پ��ִ� PlayerController�� ����
    }

    void Start()
    {
        //�ʱ� ���¸� idleState �� ����
        TransitionToState(new IdleState(this));
    }

    void Update()
    {
        //���� ���°� �����Ѵٸ� �ش� ������ Update �޼��� ȣ��
        if (currenState != null)
        {
            currenState.Update();
        }
    }
    void FixedUpdate()
    {
        //���� ���°� �����Ѵٸ� �ش� ������ FixedUpdate �޼��� ȣ��
        if (currenState != null)
        {
            currenState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newState)
    {
        //���� ���°� �����Ѵٸ� Exit �޼��带 ȣ��
        currenState?.Exit();   //�˻��ؼ� ȣ�� ����(?)�� IF����

        //���ο� ���·� ��ȯ
        currenState = newState;

        //���ο� ������ Enter �޼��� ȣ�� (���� ����)
        currenState.Enter();

        //�α׿� ���� ��ȯ ������ ���
        Debug.Log($"���� ��ȯ �Ǵ� ������Ʈ : {newState.GetType().Name}");
    }
}
