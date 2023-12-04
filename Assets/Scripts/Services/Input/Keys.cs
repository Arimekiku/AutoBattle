using UnityEngine;

public static class Keys
{
    public static bool UpPressed => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    public static bool DownPressed => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
    public static bool LeftPressed => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
    public static bool RightPressed => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
    public static bool BackPressed => Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace);
    public static bool EnterPressed => Input.GetKeyDown(KeyCode.Return);

    public static float HorizontalInput => Input.GetAxisRaw("Horizontal");
    public static float VerticalInput => Input.GetAxisRaw("Vertical");
}