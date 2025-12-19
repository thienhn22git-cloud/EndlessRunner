using UnityEngine;

public partial class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Player"
        if (collision.CompareTag("Player"))
        {
            // Gọi hàm tăng điểm (chúng ta sẽ tạo ở bước 2)
            GameManager.instance.AddCoin();
            
            // Xóa đồng xu sau khi ăn
            Destroy(gameObject);
        }
    }
}