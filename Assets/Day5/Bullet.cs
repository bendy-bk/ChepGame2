using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject pointA;  // Điểm bắt đầu (spawn)
    [SerializeField] private GameObject pointB;  // Điểm đích
    public float speed = 3f;

    private void Start()
    {
        if (pointA == null)
            pointA = GameObject.FindGameObjectWithTag("PointA");

        if (pointB == null)
            pointB = GameObject.FindGameObjectWithTag("PointB");

        if (pointA != null && pointB != null)
        {
            StartCoroutine(MoveLoop());
        }
        else
        {
            Debug.LogError("Chưa tìm thấy PointA hoặc PointB trong scene!");
        }
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToPoint(pointB.transform.position));
            yield return new WaitForSeconds(1f);  // Delay 1 giây


            yield return StartCoroutine(MoveToPoint(pointA.transform.position));
            yield return new WaitForSeconds(1f);  // Delay 1 giây
        }
    }

    IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}
