using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Cop Near?")]
[Help("Checks whether Cop is near the Treasure.")]
public class IsCopNear : ConditionBase
{
    [InParam("Cop")]
    [Help("Target to check the distance")]
    public GameObject cop;

    [InParam("Tresure")]
    [Help("Target to check the distance")]
    public GameObject treasure;

    [InParam("target distance")]
    [Help("Target to check the distance")]
    public float targetDistance = 10;

    public override bool Check()
    {
        
        return Vector3.Distance(cop.transform.position, treasure.transform.position) < targetDistance;
    }
} 
