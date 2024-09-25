using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float rotSpeed = 100f;
    public GameObject Block;
    public Vector3 cubeSize = new Vector3(2f, 2f, 5f);
    public Quaternion cubeRotation = new Quaternion(0f, 90f, 90f, 0);
    private Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>(); // ������ ������Ʈ�� ������ Dictionary
 
    void Update()
    {
        float rotationSpeed = 200f;
        float cameraRotation = Input.GetAxis("Mouse X");
        Vector3 currentRotation = Camera.main.transform.eulerAngles;
        currentRotation.y += cameraRotation * rotationSpeed;  // �Է� ���� ȸ�� �ӵ��� ���Ͽ� ������Ʈ

        Camera.main.transform.eulerAngles = currentRotation;

        if (Input.GetMouseButtonDown(0)) //���콺 ���� > ��� ����
        {
            Vector3 mousePosition = Input.mousePosition;

            // ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // �浹 ������ ��ǥ�� ť�� ����
                GameObject cube = Instantiate(Block, hit.point, Quaternion.identity);

                Renderer cubeRenderer = cube.GetComponent<Renderer>();
                if (cubeRenderer != null)
                {
                    cubeRenderer.material.color = Random.ColorHSV(); //��� �� ����
                }

                float randomSize = Random.Range(2, 5);
                Vector3 cubeSize = new Vector3(randomSize, 0.5f, 2f);
                cube.transform.localScale = cubeSize; 

                // ť���� y ���� ��ġ�� 0 �̻����� ����
                float newY = Mathf.Max(cube.transform.position.y, 1f);
                cube.transform.position = new Vector3(cube.transform.position.x, newY, cube.transform.position.z);
                //ȭ�� ���
                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(cube.transform.position);
                viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
                viewportPosition.y = Mathf.Clamp01(viewportPosition.y);
                cube.transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
                // ť���� ȸ���� ����
                cube.transform.rotation = Quaternion.Euler(0f, currentRotation.y, 90f); 
                
            }
        }


        if (Input.GetMouseButtonDown(1)) // ���콺 ������ > ��� ����
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition); // ���콺 �� ���� ��ġ�� ��� ����
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
        if (Input.GetMouseButtonDown(2)) // ���콺 �� > ��� �Ѿ�߸���
        {

            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //���콺 �� ���� �ִ� ����� ����.
            {
                Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    Vector3 forceDirection = ray.direction; // �ڷ� �Ѿ����� ���� ������ ���� ������ �ݴ�� �����մϴ�
                    rigidbody.AddForce(forceDirection * 5000f); // ���� ���ϴµ� ������ ũ�⸦ �����մϴ�
                }
            }
        }


    }
    public void InstantiateObject()
    {
        GameObject newObject = Instantiate(Block, Vector3.zero, Quaternion.identity);
        int objectId = newObject.GetInstanceID(); // ������Ʈ�� ���� �ĺ���(ID)�� ����
        instantiatedObjects.Add(objectId, newObject);
    }
    private void PositionOnFloor(GameObject obj)// ����� �����ɶ� �ٴ��� �ν��ϱ� ����.
    {
        RaycastHit hit;
        if (Physics.Raycast(obj.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Floor"))
            {
                // y ���� ��ġ�� 0 �̻����� ����
                float newY = Mathf.Max(obj.transform.position.y, 2f);
                obj.transform.position = new Vector3(obj.transform.position.x, newY, obj.transform.position.z);
            }
        }
    }
    

}



