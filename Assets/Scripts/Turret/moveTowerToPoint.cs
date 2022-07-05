//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class moveTowerToPoint : MonoBehaviour
//{

//    //a script that iterates a series of points
//    //then moves an object randomly into some of them


//    //TO-DO 
//    //START-PAUSE TRAVERSING
//    //END TRAVERSING
//    //LOOP TRAVERSING

//    //MAYBE USE DO-TWEEN?
//    Transform transform;

//    [SerializeField]
//    List<Transform> pointsAvailableToMove;

//    private List<Transform> pointsToTraverse;
//    [HideInInspector]
//    public bool canTraverse = false;
//    private int currentPointIndex = 0;
//    public float distanceOffset=0.0f;

//    public float moveStep=0.005f;

//    // Start is called before the first frame update
//    void Start()
//    {
//        pointsToTraverse = new List<Transform>();
//        transform = gameObject.GetComponent<Transform>();

//        moveToMultiplePoints(1);

//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        if (canTraverse) {
//            if (Vector2.Distance(new Vector2(pointsToTraverse[currentPointIndex].position.x, pointsToTraverse[currentPointIndex].position.y), transform.position) > distanceOffset)
//            {
//                transform.position=Vector2.MoveTowards(gameObject.transform.position, pointsToTraverse[currentPointIndex].position, moveStep);
//            }
//            else {
//                currentPointIndex++;
//                if (currentPointIndex >= pointsToTraverse.Count) {
//                    //finished traversing
//                    canTraverse = false;
//                    Debug.Log("Finished Traversing");
//                    moveToMultiplePoints(Random.Range(1,5));
//                }
//            }
        
//        }
//    }

//    //public void moveToSinglePoint() {
//    //    pointsToTraverse.Clear();
//    //    pointsToTraverse.Add(pointsAvailableToMove[Random.Range(0, pointsAvailableToMove.Count)]);
//    //    currentPointIndex = 0;
//    //    canTraverse = true;
//    //}


//    public void moveToMultiplePoints(int amount)
//    {
//        pointsToTraverse.Clear();
//        int rand = Random.Range(1, amount + 1);
//        for (int i = 0; i < rand; i++) {
//            pointsToTraverse.Add(pointsAvailableToMove[Random.Range(0, pointsAvailableToMove.Count)]);
//        }
//        currentPointIndex = 0;
//        canTraverse = true;
//    }

    

//}
