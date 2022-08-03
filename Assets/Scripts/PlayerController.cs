using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private bool canMove = true;
    [SerializeField] private Attack attack;

    private Vector2 movementInput = Vector2.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();       
    }

    void Update()
    {
        if (canMove)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
    public void StunPlayer()
    {
        StopAllCoroutines();
        StartCoroutine(Stun());
    }
    IEnumerator Stun()
    {
        attack.LockAttack(true);
        canMove = false;
        
        yield return new WaitForSeconds(3f);

        attack.LockAttack(false);
        canMove = true;
    }

    public void OnGameEnd()
    {
        Destroy(this.gameObject);
    }
}
