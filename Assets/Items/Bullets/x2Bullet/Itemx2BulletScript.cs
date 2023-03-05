using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Itemx2BulletScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startPoint = transform.position;
        moveToward = new Vector2(transform.position.x, startPoint.y + radius);
    }

    float startY;
    float speed = 0.01f;
    float radius = 04f;
    bool isUp = true;
    Vector3 moveToward;
    // Update is called once per frame
    void Update()
    {
        if (isUp && transform.position == moveToward)
        {
            isUp = false;
        }else if (!isUp && transform.position == startPoint)
        {
            isUp = true;
        }

        if(isUp) FloatingUp(); else FloatingDown();
    }

    Vector3 startPoint;
    float stepPerFrame = 0;
    void FloatingUp()
    {
       
        stepPerFrame += 5 * Time.deltaTime;
        Vector2.MoveTowards(transform.position, moveToward, stepPerFrame);
    }

    void FloatingDown()
    {
        stepPerFrame += 5 * Time.deltaTime;
        Vector2.MoveTowards(transform.position, startPoint, stepPerFrame);
    }
}
