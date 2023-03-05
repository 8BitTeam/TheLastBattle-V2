using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffects
{
    public float speed;
    
    private void Awake()
    {
      
    }

    public override void Apply(GameObject target)
    {
        if (target.gameObject.CompareTag("main"))
        {
           target.GetComponent<MainMovingScript>().timer.Run();
           
                target.GetComponent<MainMovingScript>().speed += speed;
                target.GetComponent<SpriteRenderer>().color = Color.yellow;
            
        }
      
    }
    
}
