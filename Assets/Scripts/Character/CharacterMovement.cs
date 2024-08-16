using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float minDistance = 0.1f;
    [SerializeField] LayerMask layerMask;

    private Rigidbody2D rb;
    private Animator animator;
    private Camera cam;

    private Vector3 targetPosition;
    private bool isMoving = false;

    public bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = Camera.main;
    } 

    public void SetNPC(NPC npc)
    {
        npc.OnDialogueStart.AddListener(DisableMovement);
        npc.OnDialogueEnd.AddListener(EnableMovement);
    }

    private void OnDisable()
    {
        NPC npc = FindObjectOfType<NPC>();
        if (npc != null)
        {
            npc.OnDialogueStart.RemoveListener(DisableMovement);
            npc.OnDialogueEnd.RemoveListener(EnableMovement);
        }
    }

    private void DisableMovement()
    {
        canMove = false;
    }

    private void EnableMovement()
    {
        canMove = true;
    }

    void Update()
    {
        if (!canMove) return;
        //if (canMove)
        //{
        //}

        HandleInput();        
        MoveCharacter();
        UpdateAnimation();
    }

    void HandleInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetTargetPosition(Input.mousePosition);
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

    private void UpdateAnimation()
    {
        Vector3 direction = targetPosition - transform.position;

        if(isMoving)
        {
            if(direction.x > 0)
            {
                animator.SetBool("isMovingRight", true);
                animator.SetBool("isMovingLeft", false);
            }
            else
            {
                animator.SetBool("isMovingLeft", true);
                animator.SetBool("isMovingRight", false);
            }
        }
        else
        {
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        targetPosition = transform.position;
        isMoving = false;
    }
}