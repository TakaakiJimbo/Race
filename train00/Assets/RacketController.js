var Accel = 1000.0;
function Update () {
  rigidbody.AddForce(
    transform.right * Input.GetAxisRaw( "Horizontal" ) * Accel,
    ForceMode.Impulse
  );
}