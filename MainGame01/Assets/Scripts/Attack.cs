using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator anim;
    public static bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            anim.SetTrigger("Attack1");
            isAttacking = true;
        }
    }

    void isAttackingFalse()
    {
        isAttacking = false;
    }
}
