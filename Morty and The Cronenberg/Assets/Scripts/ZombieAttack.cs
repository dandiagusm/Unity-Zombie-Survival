using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player") || col.gameObject.name.Equals("Player(Clone)"))
        {
            ZombieController.isAttacking = true;
            SoundManager.PlaySound("ZombieHit");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player") || col.gameObject.name.Equals("Player(Clone)"))
        {
            ZombieController.isAttacking = false;
        }
    }
}
