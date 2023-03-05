using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private GameObject Dialuogue1;
    Timer timer;
    public int k = 0;
    //int index;
    private Chest2 Chest2;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        Dialuogue1 = GameObject.Find("Dialuogue1");
     //   Dialuogue2 = GameObject.Find("Dialuogue2");
        Dialuogue1.SetActive(false);
        timer.Duration = 1f;
      //  index = Chest2.GetComponent<Chest2>().k;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Dialuogue1.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            if (k == 0)
            {
                //if(index == 0)
                //{
                    Dialuogue1.SetActive(true);
                    k++;
                    timer.Run();
                //}

            }
           
        }
    }
}
