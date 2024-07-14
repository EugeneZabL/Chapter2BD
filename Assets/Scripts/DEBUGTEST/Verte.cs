using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verte : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        for (int i = 0; i < vertices.Length; i++)
        {
            // –исуем линию, представл€ющую нормаль дл€ каждого вершины
            Debug.DrawLine(transform.TransformPoint(vertices[i]), transform.TransformPoint(vertices[i] + normals[i]), Color.red, 999.0f);
        }
    }
}
