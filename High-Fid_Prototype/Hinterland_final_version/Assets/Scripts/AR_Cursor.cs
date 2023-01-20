using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AR_Cursor : MonoBehaviour
{

    public GameObject cursorChildObject;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public GameObject gun;


    public bool useCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        cursorChildObject.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            if (useCursor)
            {
                if (transform.rotation.z < -0.45f || transform.rotation.x > 0.45f) {
                // true if the tree is asked to be placed on a wall.
                return;
                }
                GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                gun.GetComponent<gunm>().ShootInit();
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                // raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                raycastManager.Raycast(Input.mousePosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
                if(hits.Count > 0)
                {
                    if (hits[0].pose.rotation.z < -0.45f || hits[0].pose.rotation.x > 0.45f)
                    {
                        // true if the tree is asked to be placed on a wall.
                        return;
                    }
                    GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                    gun.GetComponent<gunm>().ShootInit();
                }
            }
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
