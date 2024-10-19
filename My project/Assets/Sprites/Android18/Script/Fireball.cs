using UnityEngine;

public class Fireball : MonoBehaviour
{
	[SerializeField] private float speed = 500f;
	private float direction;
	private bool hit;
	private float lifetime;

	private BoxCollider2D boxCollider;

	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		float movementSpeed = speed * Time.deltaTime * direction;
		Debug.Log("Movement Speed: " + movementSpeed);

		transform.Translate(movementSpeed, 0, 0);

		lifetime += Time.deltaTime;

		if (lifetime > 10f) // Chỉnh lại thời gian sống để fireball tồn tại lâu hơn
		{
			Destroy(gameObject);
		}

		// Kiểm tra nếu Fireball ra khỏi giới hạn màn hình
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPos.x > Screen.width || screenPos.x < 0)
		{
			Destroy(gameObject);  // Xóa fireball khi ra khỏi giới hạn màn hình
			Debug.Log("Fireball went off screen");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		hit = true;
		boxCollider.enabled = false;
	
	}
	
	public void SetDirection(float _direction)
	{
		Debug.Log("Fireball Direction: " + _direction);
		lifetime = 0;
		direction = _direction;
		gameObject.SetActive(true);
		hit = false;
		boxCollider.enabled = true;

		float localScaleX = transform.localScale.x;
		if (Mathf.Sign(localScaleX) != _direction)
			localScaleX = -localScaleX;

		transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
	}

	private void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
