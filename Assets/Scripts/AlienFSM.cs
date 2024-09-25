using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienFSM : MonoBehaviour
{
    enum AlienState
    {
        Idle,//대기
        Move, //움직임
        Damaged //공격을 받음
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
        m_State = AlienState.Idle;// 기본은 대기상태
        boy = GameObject.Find("Boy").transform;//'소년'을 찾으면 움직인다.

        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        Sc.SetActive(false); //성공시 나오는 이미지UI 비활성화
        Fa.SetActive(false); //실패시 나오는 이미지UI 비활성화
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
            print("움직임으로 변경");
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
