using UnityEngine;

public class EnemyFast : EnemyBase
{
    void Move()
    {
        Vector3 moveDir = (playerTransform.position - transform.position).normalized;
        Vector3 desiredMove = moveDir * moveSpeed * Time.fixedDeltaTime;

        if (!Physics.SphereCast(transform.position, 0.5f, moveDir, out RaycastHit hit, desiredMove.magnitude))
        {
            rb.MovePosition(rb.position + desiredMove);
        }
        else
        {
            Vector3 slideDirection = Vector3.ProjectOnPlane(desiredMove, hit.normal);
            if (!Physics.SphereCast(transform.position, 0.5f, slideDirection.normalized, out _, slideDirection.magnitude))
            {
                rb.MovePosition(rb.position + slideDirection);
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }
}
