using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaneMapper", menuName = "PlaneMapper", order = 1)]
public class PlaneMapper : ScriptableObject
{
    public GameObject plane;

    public void createSlope(Vector3 origin, int length)
    {
        List<Vector3> points = generateGraph(length);
        for (int i = 0; i < points.Count; i++)
        {
            GameObject newPlane = Instantiate(plane, inbetween(points[i], points[i+1]) , Quaternion.identity);
            //have the plane look at the point at point[i+1]
            newPlane.transform.LookAt(points[(i + 1)]);
            newPlane.transform.localScale = new Vector3(1, 1, Vector3.Distance(points[i], points[i + 1])/10);
            //debug distance
            Debug.Log(Vector3.Distance(points[i], points[i + 1]));
        }
    }

    private List<Vector3> generateGraph(int graphLength)
    {
        List<Vector3> graph = new List<Vector3>();

        for(float i = 0; i < graphLength; i+=0.25f)
        {
            float fx;
            //set fx to \sin\left(\frac{x+8}{4}\right)-\frac{x}{5}
            fx = Mathf.Sin(Mathf.PI * (i + 8) / 4) - (i / 2);
            graph.Add(new Vector3(0, fx, i));

            //Debug.Log(new Vector3(0, Mathf.Sin(i), i));

        }
        
        return graph;
    }

    private Vector3 inbetween(Vector3 a, Vector3 b)
    {
        //point between a and b
        return a + (b - a) / 2;
    }

}
