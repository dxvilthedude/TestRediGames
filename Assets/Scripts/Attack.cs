using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private Enemy target;
    [SerializeField] private PlayerController enemyPlayerController;
    [SerializeField] private PlayerScore pScore;
    [SerializeField] private Weapon weapon;

    private bool isAttacking;
    private float attackRate = 1f;
    private float nextAttack;
    private bool canAttack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            target = other.GetComponent<Enemy>();
        
        if (other.tag == "Player")
            enemyPlayerController = other.GetComponent<PlayerController>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (target == other.GetComponent<Enemy>())
            target = null;

        if (other.tag == "Player")
            enemyPlayerController = null;
    }

    private void AttackEnemy()
    {
        if (Time.time > nextAttack)
        {
            weapon.AttackAnim();
            nextAttack = Time.time + attackRate;

            if(target != null)
            target.TakeDamage(pScore);

            if (enemyPlayerController != null)
            {
                enemyPlayerController.StunPlayer();
            }
;
        }
        isAttacking = false;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        isAttacking = context.action.triggered;
    }

    public void LockAttack(bool value)
    {
        canAttack = !value;
    }
    private void Update()
    {         
        if (isAttacking && canAttack)
            AttackEnemy();
    }
}
