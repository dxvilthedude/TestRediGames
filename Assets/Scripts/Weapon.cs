using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Animation anim;
    public void AttackAnim()
    {
        anim.Play();
    }
}
