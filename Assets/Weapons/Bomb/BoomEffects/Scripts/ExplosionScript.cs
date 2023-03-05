using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]
    public float fieldImpact;
    public LayerMask layerToHit;

    void Start()
    {     
        GetComponent<AudioSource>().Play();
        Explode();
    }

    public void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldImpact, layerToHit);
        foreach (Collider2D obj in objects)
        {
            var creep = obj.GetComponent<Creep>();

            if(creep != null)
            {
                creep.health = 0;
            }
 
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldImpact);
    }

    void EndAnimation()
    {
        Destroy(gameObject);
    }
}
