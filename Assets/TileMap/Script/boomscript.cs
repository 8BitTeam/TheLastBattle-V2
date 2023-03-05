using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomscript : MonoBehaviour
{

    public float duration = 3;
    public float fieldImpact;

    public LayerMask LayerToHit;
    public GameObject explosionEffect;

    private Timer timer;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = duration;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Explode();
        }
    }
    public void Explode()
    {
        //Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldImpact,LayerToHit);
        //foreach(Collider2D obj in objects)
        //{
        //    Destroy(obj.gameObject);
        //}
        GameObject ExpEff = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        ExpEff.GetComponent<ExplosionScript>().layerToHit = LayerToHit;
        ExpEff.GetComponent<ExplosionScript>().fieldImpact = fieldImpact;
        //Destroy(ExpEff, 1f);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldImpact);
    }

}
