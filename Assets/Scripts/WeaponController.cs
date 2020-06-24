using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private IInputSource input;
    private Vector2? attackVector;

    public Weapon attachedWeapon;
    public Transform weaponOrbit;
    public GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5.0f;

    private Vector3 north = Vector3.zero;
    private Vector3 south = new Vector3(0, 0, 180);
    private Vector3 west = new Vector3(0, 0, 90);
    private Vector3 east = new Vector3(0, 0, 270);

    private Vector2 northVel = Vector2.up;
    private Vector2 southVel = Vector2.down;
    private Vector2 eastVel = Vector2.right;
    private Vector2 westVel = Vector2.left;


    [SerializeField] private float attackDuration = 0.2f;
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponentInParent<IInputSource>();
        attackTimer = attackDuration; // don't start timer until first attack
    }

    // Update is called once per frame
    void Update()
    {
        attackVector = input.OnAttack();
        if (attackVector != null)
        {
            attackTimer = 0.0f;
            OrientWeapon(attackVector.GetValueOrDefault()); // even if we check if attackVector is not null, we have to pass it with a null-safe expression
            if (gameObject.CompareTag("Player") && GetComponentInParent<IAvatar>().GetElement().type == Type.Paper)
            {
                ShootProjectile();
            }
            attachedWeapon.gameObject.SetActive(true);
        }
        else
        {
            if (attackTimer >= attackDuration)
            {
                attachedWeapon.gameObject.SetActive(false);
            }
            else
            {
                attackTimer += Time.deltaTime;
            }
        }
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, attachedWeapon.transform.position, Quaternion.Euler(0, 0, weaponOrbit.localEulerAngles.z + 90));
        
        projectile.GetComponent<Rigidbody2D>().velocity = OrientProjectile() * projectileSpeed;
    }

    private Vector2 OrientProjectile()
    {
        Vector3 weaponOrientation = weaponOrbit.localEulerAngles;
        if (weaponOrientation == south)
            return southVel;
        else if (weaponOrientation == west)
            return westVel;
        else if (weaponOrientation == east)
            return eastVel;
        else if (weaponOrientation == north)
            return northVel;
        else
            return Vector2.zero;

    }

    private void OrientWeapon(Vector2 direction)
    {
        float X = direction.x;
        float Y = direction.y;

        if (Y > X && Y > -X)
            weaponOrbit.localEulerAngles = north;
        else if (Y < X && Y < -X)
            weaponOrbit.localEulerAngles = south;
        else if (Y < X && Y > -X)
            weaponOrbit.localEulerAngles = east;
        else if (Y > X && Y < -X)
            weaponOrbit.localEulerAngles = west;
    }
}
