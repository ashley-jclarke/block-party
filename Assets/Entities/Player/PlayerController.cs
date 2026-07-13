using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera activeCamera;

    private InputAction moveAction;
    private bool isWalking = false;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 15f;

    [SerializeField] private GameInput gameInput;


    private float interactDistance = 4f;
    private CapsuleCollider collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteraction;
        collider = GetComponent<CapsuleCollider>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void GameInput_OnInteraction(object sender, EventArgs e)
    {
        HandleInteraction();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void HandleInteraction()
    {

        RaycastHit raycastHit;
        bool hit = Physics.Raycast(transform.position, transform.forward, out raycastHit, interactDistance);

        if (hit)
        {
            if (raycastHit.transform.TryGetComponent(out Crate crate))
            {
                crate.Interact();
            }
        }

    }

    private void Move()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new(inputVector.x, 0f, inputVector.y);

        moveDirection = Quaternion.AngleAxis(activeCamera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; 

        float moveDistance = moveSpeed*Time.deltaTime;


        // Collision Check
        Vector3 topOfPlayer = transform.position + collider.height * Vector3.up;
        bool obstructed = Physics.CapsuleCast(
            transform.position,
            topOfPlayer,
            collider.radius,
            transform.forward,
            moveDistance);
        

        isWalking = inputVector != Vector2.zero;

        if (isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            if (!obstructed)
            {
                Vector3 moveVelocity = transform.forward * moveDistance;
                transform.position += moveVelocity;
            }
            else
            {
                isWalking = false;
            }
        }

    }

    public bool IsWalking() { return isWalking; }
}
