using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScript : MonoBehaviour
{
    Vector3[] vertices;
    Vector3[] normals;
    Vector2[] uv;
    int[] triangles;
    public Material material;

    int xSize = 40;
    int zSize = 40;
    int totalTiles;

    int xVert;
    int zVert;
    int totalVerts;

    void Start()
    {
        xVert = xSize + 1;
        zVert = zSize + 1;
        totalVerts = xVert * zVert;
        totalTiles = xSize * zSize;

        vertices = new Vector3[totalVerts];
        normals = new Vector3[totalVerts];
        uv = new Vector2[totalVerts];
        triangles = new int[totalTiles * 6];

/*      vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 0, 1);
        vertices[3] = new Vector3(1, 0, 1);

        uv[0] = new Vector2(0, 0);
        uv[0] = new Vector2(1, 0);
        uv[0] = new Vector2(0, 1);
        uv[0] = new Vector2(1, 1);

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 3;
        triangles[3] = 0;
        triangles[4] = 3;
        triangles[5] = 1;*/

        for(int z = 0; z < zVert; z++)
        {
            for(int x = 0; x < xVert; x++)
            {
                vertices[z * xVert + x] = new Vector3(x, 0, z);
                normals[z * xVert + x] = Vector3.up;
            }
        }

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        gameObject.transform.localScale = new Vector3(4, 0, 4);
        //gameObject.transform.localRotation = Quaternion.Euler(180, 0, 0);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;



    }
}
