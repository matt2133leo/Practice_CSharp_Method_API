using UnityEngine;

public class Fox : MonoBehaviour
{
    [Header("移動速度"),Range(0f , 100f),Tooltip("調整移動速度")]
    public float move_speed = 10f;

    [Header("狐狸的剛體"),Tooltip("賦予推力用")]
    public Rigidbody2D fox_thrust ;

    [Header("面向"),Tooltip("狐狸的方向")]
    public SpriteRenderer fox_direction ;

    float fox_speed; //控制狐狸移動的速度


    private void Update()
    {
        fox_speed = Input.GetAxisRaw("Horizontal") * move_speed * Time.deltaTime; //按方向鍵 , WD 的速度
        fox_move();

    }
    #region 狐狸移動方法
    /// <summary>
    /// 狐狸移動方法
    /// </summary>
    public void fox_move()
    {
        if (fox_speed < 0)
        {
            fox_thrust.AddForce(transform.right * fox_speed, ForceMode2D.Impulse); //往左
            fox_direction.flipX = true; //人物向左
        }
        else if (fox_speed > 0)
        {
            fox_thrust.AddForce(transform.right * fox_speed, ForceMode2D.Impulse); //往右
            fox_direction.flipX = false; //人物向右
        }
    }
    #endregion
}
