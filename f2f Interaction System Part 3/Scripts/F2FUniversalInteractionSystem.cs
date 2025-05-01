using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.UI;

public class F2FUniversalInteractionSystem : MonoBehaviour
{

    bool CanInteract = true;

    public Transform HeldPoint;

    private Transform PlacePoint;

    private GameObject HeldObject;

    public Text InteractionText;

    public AudioSource Source;

    public AudioClip TakeClip;
    public AudioClip PlaceClip;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(CanInteract == true)
        {



            if(HeldObject == null)
            {


                Ray ray1 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit1;

                if(Physics.Raycast(ray1, out hit1, 5f))
                {


                    if (hit1.collider.CompareTag("Pickable"))
                    {


                        InteractionText.text = "Take";


                        if (Input.GetMouseButtonDown(0))
                        {


                            Source.PlayOneShot(TakeClip);

                            InteractionText.text = "";

                            // pick up

                            HeldObject = hit1.collider.gameObject;

                            HeldObject.transform.SetParent(HeldPoint);
                            HeldObject.transform.localPosition = Vector3.zero;
                            HeldObject.transform.localRotation = Quaternion.identity;






                        }



                    }
                    else
                    {


                        InteractionText.text = "";

                    }



                }
                else
                {


                    InteractionText.text = "";

                }



            }
            else
            {


                Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit2;

                if(Physics.Raycast(ray2, out hit2, 5f))
                {


                    if (hit2.collider.CompareTag("PlacedOn"))
                    {


                        InteractionText.text = "Place";


                        if (Input.GetMouseButtonDown(0))
                        {


                            Source.PlayOneShot(PlaceClip);

                            InteractionText.text = "";

                            // place

                            PlacePoint = hit2.collider.transform;

                            HeldObject.transform.SetParent(PlacePoint);
                            HeldObject.transform.localPosition = new Vector3(0, 0.762f, 0);
                            HeldObject.transform.localRotation = Quaternion.identity;

                            HeldObject = null;
                            PlacePoint = null;




                        }



                    }
                    else
                    {


                        InteractionText.text = "";

                    }



                }
                else
                {


                    InteractionText.text = "";

                }



            }



        }



        
    }
}
