using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public float speed = 10f;                     //�̵��ӵ� ��������

    //���� �Լ� : �̵�

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   //������ �ش� �ӵ���ŭ �̵�
    }

    //�߻��Լ� : ����
    public abstract void Horn();               //�����Լ�����
}