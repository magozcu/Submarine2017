using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFishScript : MonoBehaviour {

    public Transform MarineTransform;
    [Range(0.01f, 0.05f)]
    public float FishVelocity;

    private List<Transform> _MarineTrackingList = new List<Transform>();
    private Transform TargetTransform;
    public bool IsMarineFunctionWaiting = false;

    private void Start()
    {
        FishVelocity = 0.01f;
    }

    private void FixedUpdate()
    {
        StartCoroutine(AddMarineTransformToList(0.2f));
        SetTargetPoint();

        TrackingMarine();
    }

    private IEnumerator AddMarineTransformToList(float trackingTimeGap)
    {
       
        if (!IsMarineFunctionWaiting)
        {
            IsMarineFunctionWaiting = true;
            _MarineTrackingList.Add(MarineTransform);
            yield return new WaitForSeconds(trackingTimeGap);
            IsMarineFunctionWaiting = false;        
        }
      
    }
    private void SetTargetPoint()
    {
        if (_MarineTrackingList.Count == 0) return;
        else
        {          
            TargetTransform = _MarineTrackingList[0];
            _MarineTrackingList.RemoveAt(0);
        }
    }

    public void TrackingMarine()
    {

        if (TargetTransform != null)
        {

            if ((this.transform.position.x == TargetTransform.transform.position.x)
            && (this.transform.position.y == TargetTransform.transform.position.y))
            {
                TargetTransform = null;
            }
            else
            {      
                      
                if (this.transform.position.y < TargetTransform.position.y)
                {
                    this.transform.position += new Vector3(0f, FishVelocity, 0f);                    
                }
                                  
                if (this.transform.position.x < TargetTransform.position.x)
                {
                    this.transform.position += new Vector3(FishVelocity, 0f, 0f);     
                }

               
            }
        }
    }
    

}
