using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjManager : MonoBehaviour
{
    Vector3 dest;
    public Transform board1;
    public Transform board2;
    public Transform circle1;
    public Transform circle2;

    public List<Transform> list = new List<Transform>();

    Button btn;
    private void Awake()
    {
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(ReAnimate);
    }

    public IEnumerator Start()
    {
        float time = Time.deltaTime;
        // Board1 move
        board1.gameObject.SetActive(true);
        for (float t = 0; t <= 1; t += time)
        {
            dest = transform.position + transform.right * 1.7f;
            board1.position = Vector3.Lerp(board1.position, dest, t);
            yield return new WaitForSeconds(time);
        }
        // Board2 move
        board2.gameObject.SetActive(true);
        for (float t = 0; t <= 1; t += time)
        {
            dest = transform.position + -transform.forward * 1.2f;
            board2.position = Vector3.Lerp(board2.position, dest, t);
            circle1.position = Vector3.Lerp(board2.position, dest, t);
            circle2.position = Vector3.Lerp(board2.position, dest, t);
            yield return new WaitForSeconds(time);
        }
        // Circle1 move
        circle1.gameObject.SetActive(true);
        for (float t = 0; t <= 1; t += time)
        {
            dest = board2.position + board2.right * 1.2f;
            circle1.position = Vector3.Lerp(circle1.position, dest, t);
            circle2.position = Vector3.Lerp(circle1.position, dest, t);
            yield return new WaitForSeconds(time);
        }
        // Circle2 move
        circle2.gameObject.SetActive(true);
        for (float t = 0; t <= 1; t += time)
        {
            dest = circle1.position + circle1.right * 1;
            circle2.position = Vector3.Lerp(circle2.position, dest, t);
            yield return new WaitForSeconds(time);
        }
    }

    public void ReAnimate()
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i].position = new Vector3(transform.position.x, list[i].position.y, transform.position.z);
            list[i].gameObject.SetActive(false);
        }
        StartCoroutine("Start");
    }
}
