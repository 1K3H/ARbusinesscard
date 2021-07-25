using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEventManager : MonoBehaviour
{
    private WebViewObject webViewObject;

    void Update()
    {
        TouchEvent();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(webViewObject);
                return;
            }
        }
    }

    private void TouchEvent()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        // ȭ���� ��ġ�ϸ�
        if (touch.phase == TouchPhase.Began)
        {
            // ��ġ�� ��ġ���� 3D����� ���ϴ� Ray�� �����
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hitInfo;
            // int layer = 1 << LayerMask.NameToLayer("Github");
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue))
            {
                if(hitInfo.transform.name == "Github")
                {
                string strUrl = "https://github.com/1K3H";

                webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
                webViewObject.Init((msg) =>
                {
                    Debug.Log(string.Format("CallFromJS[{0}]", msg));
                });

                webViewObject.LoadURL(strUrl);
                webViewObject.SetVisibility(true);
                webViewObject.SetMargins(50, 50, 50, 50);
                }

                if (hitInfo.transform.name == "Velog")
                {
                    string strUrl = "https://velog.io/@home_2201";

                    webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
                    webViewObject.Init((msg) =>
                    {
                        Debug.Log(string.Format("CallFromJS[{0}]", msg));
                    });

                    webViewObject.LoadURL(strUrl);
                    webViewObject.SetVisibility(true);
                    webViewObject.SetMargins(50, 50, 50, 50);
                }
            }
        }
    }
}
