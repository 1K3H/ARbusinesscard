using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImage : MonoBehaviour
{
    static public TrackedImage TI;
    public GameObject boards;

    ARTrackedImageManager aRTrackedImageManager;
    public Vector3 markerPos;

    void Awake()
    {
        TI = this;
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OntrackedImagesChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OntrackedImagesChanged;
    }

    private void OntrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {

        // 추적된 이미지 목록을 전체 검사하고 싶다.
        for (int i = 0; i < obj.updated.Count; i++)
        {
            // 각 항목하나
            ARTrackedImage marker = obj.updated[i];
            // 추적중이라면
            if (marker.trackingState == TrackingState.Tracking)
            {
                boards.transform.position = marker.transform.position;
                boards.SetActive(true);
            }
        }
    }
}
