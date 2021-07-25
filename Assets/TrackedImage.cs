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

        // ������ �̹��� ����� ��ü �˻��ϰ� �ʹ�.
        for (int i = 0; i < obj.updated.Count; i++)
        {
            // �� �׸��ϳ�
            ARTrackedImage marker = obj.updated[i];
            // �������̶��
            if (marker.trackingState == TrackingState.Tracking)
            {
                boards.transform.position = marker.transform.position;
                boards.SetActive(true);
            }
        }
    }
}
