using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float minDistance = 0.1f;
    [SerializeField] LayerMask layerMask;
    
    private Rigidbody2D rb;
    private Camera cam;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        HandleInput();
        MoveCharacter();
    }

    void HandleInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetTargetPosition(Input.mousePosition);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //if (hit.collider != null)
            //{
            //    Debug.Log("Hit: " + hit.collider.name);
            //    targetPosition = hit.point;
            //    isMoving = true;
            //}
            //else
            //{
            //    Debug.Log("No hit detected");
            //}
        }
    }

    private void SetTargetPosition(Vector3 position)
    {
        targetPosition = cam.ScreenToWorldPoint(position);
        targetPosition.z = transform.position.z;
        isMoving = true;
    }

    void MoveCharacter()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                     targetPosition, 
                                                     moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < minDistance)
            {
                isMoving = false;
            }
        }
    }
}
