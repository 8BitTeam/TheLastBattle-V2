using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenHelper
{
    public static GameConfigModel LoadConfig()
    {
        string configString = File.ReadAllText(Application.dataPath + "/gameConfig.json");
        GameConfigModel model = JsonConvert.DeserializeObject<GameConfigModel>(configString);
        return model;
    }

    public static void Facing(Vector2 facingDirection, bool isFacingRight, GameObject gameObject)
    {
        if (gameObject != null)
        {
            if (facingDirection.x > 0)
            {
                isFacingRight = true;
            }
            else if (facingDirection.x < 0)
            {
                isFacingRight = false;
            }

            if (isFacingRight && gameObject.transform.localScale.x < 0)
            {
                Flip(gameObject.transform);
            }
            else if (!isFacingRight && gameObject.transform.localScale.x > 0)
            {
                Flip(gameObject.transform);
            }
        }
    }

    private static void Flip(Transform transform)
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public static GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }


    public static Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    public static bool CompareCurrentAnimationName(Animator animator, string name)
    {
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals(name);
    }
}
