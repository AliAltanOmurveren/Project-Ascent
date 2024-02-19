using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TargetsInView : MonoBehaviour
{
    struct BoundingSphere{
        internal Vector3 center;
        internal float radius;
    }

    public HashSet<ITarget> visibleTargets;
    List<ITarget> rocketTargets;

    public Image crosshairImage;

    void Awake()
    {
        visibleTargets = new HashSet<ITarget>();
        rocketTargets = new List<ITarget>();
    }


    void Update()
    {
        
    }

    public GameObject GetRocketTarget(){
        float closestDistance = float.MaxValue;
        
        GameObject closestTarget = null;

        foreach(ITarget target in rocketTargets){
            float distanceFromCamera = Vector3.Distance(transform.position, target.GetGameObject().transform.position);

            if(distanceFromCamera < closestDistance){
                closestTarget = target.GetGameObject();
                closestDistance = distanceFromCamera;
            }
        }

        return closestTarget;
    }

    public void FindRocketTargets(){
        rocketTargets = new List<ITarget>();

        foreach(ITarget target in visibleTargets){
            float distanceFromCamera = Vector3.Distance(transform.position, target.GetGameObject().transform.position);

            if(distanceFromCamera > Constants.ROCKET_TARGET_MAX_DISTANCE){
                continue;
            }

            BoundingSphere boundingSphere = CalculateBoundingSphere(target);

            Vector3 boundingSphereScreenPosition = Camera.main.WorldToScreenPoint(boundingSphere.center) * (Screen.width / Constants.RENDER_TEXTURE_WIDTH);
            boundingSphereScreenPosition.z = 0;

            Vector3 crosshairScreenPosition = crosshairImage.GetComponent<RectTransform>().position;
            crosshairScreenPosition.z = 0;

            float distance = Vector3.Distance(boundingSphereScreenPosition, crosshairScreenPosition);
            
            if(distance < crosshairImage.rectTransform.rect.width / 2){
                rocketTargets.Add(target);
            }

        }
    }

    BoundingSphere CalculateBoundingSphere(ITarget target){
        BoundingSphere boundingSphere;

        boundingSphere.center = target.GetGameObject().transform.position;

        Vector3 boundExtents = target.GetGameObject().GetComponent<Collider>().bounds.extents;

        boundingSphere.radius = new float[] {boundExtents.x, boundExtents.y, boundExtents.z}.Max();

        return boundingSphere;
    }
}
