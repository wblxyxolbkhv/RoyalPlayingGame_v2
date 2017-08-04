using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        public Transform leftEdge;
        public Transform rightEdge;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        private float RectWidth;
        private float RectHeight;

        BoxCollider2D b;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;

            Camera c = GetComponent<Camera>();
            b = c.GetComponent<BoxCollider2D>();

            RectWidth = b.bounds.size.x / 2.0f;
            RectHeight = b.bounds.size.y / 2.0f;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
            

            if (newPos.x - RectWidth < leftEdge.position.x)
                newPos = new Vector3(leftEdge.position.x + RectWidth, newPos.y, newPos.z);

            if (newPos.y - RectHeight < leftEdge.position.y)
                newPos = new Vector3(newPos.x, leftEdge.position.y + RectHeight, newPos.z);

            if (newPos.x + RectWidth > rightEdge.position.x)
                newPos = new Vector3(rightEdge.position.x - RectWidth, newPos.y, newPos.z);

            if (newPos.y + RectHeight > rightEdge.position.y)
                newPos = new Vector3(newPos.x, rightEdge.position.y - RectHeight, newPos.z);


            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}
