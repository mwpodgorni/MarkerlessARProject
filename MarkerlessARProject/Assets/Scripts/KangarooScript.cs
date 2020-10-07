using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class KangarooScript : MonoBehaviour
{
    public GameObject kangaroo;
    public GameObject board;
    
    private GameObject spawnedObject1;
    private GameObject spawnedObject2;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public AudioSource kangarooSound;
    
    private void Awake()
    {
        _arRaycastManager = GetComponent < ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject1 == null && spawnedObject2 == null)
            {
                
                spawnedObject1 = Instantiate(kangaroo, hitPose.position, Quaternion.Euler(-90f,-90f,0));
                spawnedObject2 = Instantiate(board, hitPose.position+new Vector3(0.6f, 0,0), Quaternion.Euler(0,-90,0));
            }
            else
            {
                spawnedObject1.transform.position = hitPose.position;
                spawnedObject2.transform.position = hitPose.position+new Vector3(0.6f, 0,0);
            }
        }
    }
    public void playSoundEffect()
    {
        kangarooSound.Play();
    }
}