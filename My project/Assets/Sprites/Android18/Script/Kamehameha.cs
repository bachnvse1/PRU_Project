using UnityEngine;

public class Kamehameha : MonoBehaviour
{
	[SerializeField] private float lifetime = 2f; // Thời gian tồn tại của Kamehameha
	[SerializeField]
	public Transform player;
	[SerializeField]
	public float distanceFromPlayer = 1f;
	private BoxCollider2D boxCollider;
	private float spawnTime;

	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void OnEnable()
	{
		spawnTime = Time.time;
		// Kích hoạt Kamehameha
		gameObject.SetActive(true);
		// Gọi hàm để biến mất sau thời gian đã định
		Debug.Log("lifetime: " + lifetime);
		Invoke("Deactivate", lifetime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Xử lý va chạm nếu cần
		boxCollider.enabled = false; // Vô hiệu hóa collider sau khi va chạm
									 // Có thể thêm logic xử lý va chạm ở đây
	}

	public void SetDirection(float direction)
	{
		// Kích hoạt Kamehameha
		gameObject.SetActive(true);
		boxCollider.enabled = true;

		// Đảo hướng Kamehameha dựa trên hướng di chuyển của nhân vật
		float localScaleX = transform.localScale.x;
		if (Mathf.Sign(localScaleX) != direction)
			localScaleX = -localScaleX;

		transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

		// Đặt vị trí Kamehameha dựa trên firePoint
		Vector3 offset = new Vector3(localScaleX > 0 ? distanceFromPlayer : -distanceFromPlayer, 0, 0); // Điều chỉnh vị trí cho đúng đầu
		transform.position = player.position + offset; // Di chuyển Kamehameha đến vị trí mong muốn
	}

	private void Update()
	{
		// Cập nhật vị trí Kamehameha theo nhân vật nếu nó đang hoạt động
		if (gameObject.activeSelf)
		{
			Vector3 offset = new Vector3(transform.localScale.x > 0 ? distanceFromPlayer : -distanceFromPlayer, 0, 0);
			transform.position = player.position + offset; // Cập nhật vị trí Kamehameha
		}
	}

	private void Deactivate()
	{
		// Kiểm tra xem thời gian tồn tại có lớn hơn 2 giây hay không

		if (Time.time - spawnTime > lifetime)
		{
			gameObject.SetActive(false); // Ẩn Kamehameha sau khi hết thời gian tồn tại nếu > 2 giây
		}
		else
		{
			// Nếu không, có thể làm gì đó khác, như ghi log
			Debug.Log("Kamehameha không biến mất vì chưa đủ 2 giây.");
		}
	}
}
