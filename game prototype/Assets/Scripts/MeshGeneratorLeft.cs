using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorLeft : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    public int xSize = 20;
    public int zSize = 5; 
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape(){
        vertices = new Vector3[(xSize+1) * (zSize+1)];

        for(int i = 0, z = 0; z <= zSize; z++){
            for(int x = 0; x <= xSize; x++){
                float y = 0;
                if(i < 100) {
                    y = Mathf.PerlinNoise(x * .3f, z * .3f) * 0.2f;
                }

                if((i > 40 && i < 61)) {
                    y = Mathf.PerlinNoise(x * .3f, z * .3f) * 1f;
                }

                if((i > 20 && i < 41)) {
                    y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                }

                if((i > 0 && i < 21)) {
                    y = Mathf.PerlinNoise(x * .3f, z * .3f) * 4f;
                }
                
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int currentVertex = 0;
        int triangleCount = 0;

        for(int z = 0; z < zSize; z++){
            for(int x = 0; x < xSize; x++){

                triangles[triangleCount] = currentVertex + 0;
                triangles[triangleCount + 1] = currentVertex + xSize + 1;
                triangles[triangleCount + 2] = currentVertex + 1; 
                triangles[triangleCount + 3] = currentVertex + 1;
                triangles[triangleCount + 4] = currentVertex + xSize + 1;
                triangles[triangleCount + 5] = currentVertex + xSize + 2;

                currentVertex++;
                triangleCount += 6;
            }
            currentVertex++;
        }

        uvs = new Vector2[vertices.Length];

        for(int i = 0, z = 0; z <= zSize; z++){
            for(int x = 0; x <= xSize; x++){
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }

    }
    void UpdateMesh(){
         mesh.Clear();

         mesh.vertices = vertices;
         mesh.triangles = triangles;
         mesh.uv = uvs;

         mesh.RecalculateNormals();
    }
}
