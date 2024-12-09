using UnityEngine;

public class CustomThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    private Animator animator;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the character
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // Rotate the character to face the movement direction
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        // Play animations (if you have any) based on movement
        animator.SetFloat("Speed", moveDirection.magnitude);
    }
}