using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienFSM : MonoBehaviour
{
    enum AlienState
    {
        Idle,//���
        Move, //������
        Damaged //������ ����
    }

    AlienState m_State;

    public GameObject Fa;
    public GameObject Sc;
    public float findDistance = 5f;
    Transform boy;
    public float moveSpeed = 3f;
    CharacterController cc;
    public GameObject Block;

    Vector3 originPos;

    void Start()
    {
        m_State = AlienState.Idle;// �⺻�� ������
        boy = GameObject.Find("Boy").transform;//'�ҳ�'�� ã���� �����δ�.

        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        Sc.SetActive(false); //������ ������ �̹���UI ��Ȱ��ȭ
        Fa.SetActive(false); //���н� ������ �̹���UI ��Ȱ��ȭ
    }
    void Update()
    {
        switch (m_State)
        {
            case AlienState.Idle:
                Idle();
                break;
            case AlienState.Move:
                Move();
                break;
            case AlienState.Damaged:
                Damaged();
                break;
        }
    }
    void Idle()
    {
        if (Vector3.Distance(transform.position, boy.position) < findDistance)
        {
            m_State = AlienState.Move;
            print("���������� ����");
        }
    }
    void Move()
    {
        Vector3 dir = (boy.position - transform.position).normalized;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
    void Damaged()
    {
         StopAllCoroutines();
    }
}
