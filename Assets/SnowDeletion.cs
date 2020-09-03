using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDeletion : MonoBehaviour
{
    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    private static readonly int DrawAngle = Shader.PropertyToID("_DrawAngle");
   public CustomRenderTexture SnowHeightMap;
   public Material HeightMapUpdate;
   private Camera mainCamera;

   public GameObject Tires;
   void Start()
   {
       SnowHeightMap.Initialize();
       mainCamera = Camera.main;
   }

    void Update()
    {
        DrawPath();
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2 hitTextureCoord = hit.textureCoord;

                HeightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
                HeightMapUpdate.SetFloat(DrawAngle, 45 * Mathf.Deg2Rad);
            }
        }
    }
    void DrawPath()
    {
        GameObject tire = Tires;

        Ray ray = new Ray(tire.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2 hitTextureCoord = hit.textureCoord;
            float angle = tire.transform.rotation.eulerAngles.y;

            HeightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
            HeightMapUpdate.SetFloat(DrawAngle, angle * Mathf.Deg2Rad);
        }
    }

}
