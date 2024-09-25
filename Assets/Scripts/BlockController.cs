using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float rotSpeed = 100f;
    public GameObject Block;
    public Vector3 cubeSize = new Vector3(2f, 2f, 5f);
    public Quaternion cubeRotation = new Quaternion(0f, 90f, 90f, 0);
    private Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>(); // 생성된 오브젝트를 저장할 Dictionary
 
    void Update()
    {
        float rotationSpeed = 200f;
        float cameraRotation = Input.GetAxis("Mouse X");
        Vector3 currentRotation = Camera.main.transform.eulerAngles;
        currentRotation.y += cameraRotation * rotationSpeed;  // 입력 값을 회전 속도에 곱하여 업데이트

        Camera.main.transform.eulerAngles = currentRotation;

        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 > 블록 생성
        {
            Vector3 mousePosition = Input.mousePosition;

            // 화면 좌표를 월드 좌표로 변환
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // 충돌 지점의 좌표에 큐브 생성
                GameObject cube = Instantiate(Block, hit.point, Quaternion.identity);

                Renderer cubeRenderer = cube.GetComponent<Renderer>();
                if (cubeRenderer != null)
                {
                    cubeRenderer.material.color = Random.ColorHSV(); //블록 색 랜덤
                }

                float randomSize = Random.Range(2, 5);
                Vector3 cubeSize = new Vector3(randomSize, 0.5f, 2f);
                cube.transform.localScale = cubeSize; 

                // 큐브의 y 방향 위치를 0 이상으로 조정
                float newY = Mathf.Max(cube.transform.position.y, 1f);
                cube.transform.position = new Vector3(cube.transform.position.x, newY, cube.transform.position.z);
                //화면 경계
                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(cube.transform.position);
                viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
                viewportPosition.y = Mathf.Clamp01(viewportPosition.y);
                cube.transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
                // 큐브의 회전을 조정
                cube.transform.rotation = Quaternion.Euler(0f, currentRotation.y, 90f); 
                
            }
        }


        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 > 블록 삭제
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition); // 마우스 휠 위에 위치한 블록 삭제
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject collidedObject = hit.collider.gameObject;
                if (collidedObject.gameObject.CompareTag("cube"))
                {
                    Destroy(collidedObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(2)) // 마우스 훨 > 블록 넘어뜨리기
        {

            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //마우스 휠 위에 있는 블록을 말함.
            {
                Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    Vector3 forceDirection = ray.direction; // 뒤로 넘어지는 힘의 방향을 레이 방향의 반대로 설정합니다
                    rigidbody.AddForce(forceDirection * 5000f); // 힘을 가하는데 적절한 크기를 설정합니다
                }
            }
        }


    }
    public void InstantiateObject()
    {
        GameObject newObject = Instantiate(Block, Vector3.zero, Quaternion.identity);
        int objectId = newObject.GetInstanceID(); // 오브젝트의 고유 식별자(ID)를 얻음
        instantiatedObjects.Add(objectId, newObject);
    }
    private void PositionOnFloor(GameObject obj)// 블록이 생성될때 바닥을 인식하기 위함.
    {
        RaycastHit hit;
        if (Physics.Raycast(obj.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Floor"))
            {
                // y 방향 위치를 0 이상으로 조정
                float newY = Mathf.Max(obj.transform.position.y, 2f);
                obj.transform.position = new Vector3(obj.transform.position.x, newY, obj.transform.position.z);
            }
        }
    }
    

}



