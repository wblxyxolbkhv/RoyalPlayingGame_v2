using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingUnit : MonoBehaviour {

    public float moveTime = 0.1f;
    public LayerMask blockingLayer;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    private float inverseMoveTime;




    // Use this for initialization
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;

        
    }

    protected bool Move(int dx, int dy, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(dx, dy);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            StartCoroutine(SmoothMoment(end));
            return true;
        }
        return false;
    }

    protected virtual void AttemptMove<T>(int dx, int dy)
        where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(dx, dy, out hit);

        if (hit.transform == null)
            return;
        T hitComponent = GetComponent<T>();

        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);

    }

    protected IEnumerator SmoothMoment(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance < float.Epsilon)
        {
            Vector3 newPos = Vector3.MoveTowards(rigidbody.position, end, inverseMoveTime * Time.deltaTime);
            rigidbody.MovePosition(newPos);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    protected abstract void OnCantMove<T>(T component)
        where T : Component;

}
    

