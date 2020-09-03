using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDeletion : MonoBehaviour
{
   public CustomRenderTexture SnowHeightMap;
   public Material HeightMapUpdate;
   private Camera mainCamera;
   void Start()
   {
       SnowHeightMap.Initialize();
       mainCamera = Camera.main;
   }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                Vector2 hitTextureCoord = hit.textureCoord;
                HeightMapUpdate.SetVector("_DrawPosition",hitTextureCoord);
            }
        }
    }

}
