using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;
public class EquiController : MonoBehaviour
{   [SerializeField]
    public Transform grabPoint;
    [SerializeField]
    public Transform itemHolder;
    int k = 1;
    public Transform rayPoint;
    [SerializeField]
    private float rayDistance;
    
    Timer timer;
    GameObject grabbedObject;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.Duration = 3;
        timer.Run();
        layerIndex = LayerMask.NameToLayer("gun");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(rayPoint.position, Vector2.right * transform.localScale, rayDistance);
        
            if (grabCheck.collider != null && grabCheck.collider.gameObject.layer==layerIndex)
            {
            //    //cam sung
            //    if(Input.GetKey(KeyCode.C) && grabbedObject == null)
            //{
            //    grabbedObject = grabCheck.collider.gameObject;
            //    grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //    grabbedObject.transform.position = grabPoint.position;
            //    grabbedObject.transform.SetParent(transform);
                
            //}else if (Input.GetKey(KeyCode.T))
            //{
            //    grabbedObject.SetActive(false);
                
            //    grabbedObject.transform.SetParent(null);
            //    grabbedObject = null;
            //}
            //    //tha sung
            if(grabbedObject == null && !timer.Finished)
            {
                grabbedObject = grabCheck.collider.gameObject;
               // grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            if (timer.Finished)
            {
                ScreenHelper.FindChildWithTag(gameObject,"gun").SetActive(false);
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    grabCheck.collider.gameObject.transform.parent = null;


        //}
        //if(grabCheck.collider != null && grabCheck.collider.tag != "gun" && grabCheck.collider.tag == "sword")
        //{
        //    grabCheck.collider.gameObject.transform.parent = itemHolder;
        //    grabCheck.collider.gameObject.transform.position = itemHolder.position;
        //    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        //}
        //else
        //{
        //    grabCheck.collider.gameObject.transform.parent = null;
        //    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //}
        
    }
}
