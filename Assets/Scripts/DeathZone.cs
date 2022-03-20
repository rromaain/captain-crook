using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour
{
    // // Uncomment for autosetup on a new gameobject
    // void Awake()
    // {
    //    BoxCollider2D boxCollider2D = this.GetComponent<BoxCollider2D>();
    //    if (boxCollider2D != null)
    //        boxCollider2D.isTrigger = true;
    // }
    void OnTriggerEnter2D(Collider2D other){
        PlayerCharacterHealth playerCharacterHealth = other.GetComponentInParent<PlayerCharacterHealth>();
        if (playerCharacterHealth != null){
            Debug.Log("Here");
            playerCharacterHealth.Kill();
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
