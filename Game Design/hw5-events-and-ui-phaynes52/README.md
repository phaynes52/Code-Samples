# Events and UI

## Resources
- https://www.youtube.com/watch?v=zc8ac_qUXQY
- https://docs.unity3d.com/Manual/UIToolkits.html
- https://docs.unity3d.com/Manual/UnityEvents.html
- https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
- https://docs.unity3d.com/ScriptReference/Coroutine.html


## Required (5 points)
- Main Menu (2 points)
  - Open the `MainMenu` scene and create a menu around the template Canvas
    - Title Text (anything you want!)
    - Play Button (opens the `Game` scene when pressed)
      - Use the `SceneLoader` object's `SceneLoader.cs` script to load a new scene.
      - Note: Scenes needed to be added to the build settings to be able to switch to them (Ctrl+Shift+B)
    - Volume Slider (adjust music volume)
    - Credits Button (opens new UI panel showing credits for the game. That's you!)
      - Should have a back button to go back to the Main UI
- Opening Door (2 point)
  - Open the `Door` scene. In it, a box is suspended above a button and there is a door on the right. When you press play, the box will fall on the button. Modify the `PressurePlate.cs` script on the Button and add a UnityEvent to trigger when the plate is pressed down and when it stops being pressed down. 
  - Modify the `Open()` and `Close()` functions in the `Door.cs` script on the door GameObject to open and close the door respectively in any manner you wish.
  - Set the `Open()` and `Close()` functions as subscribers to the PressurePlate `Down` and `Up` events respectively.
  - Note: public void UnityEvents (ones with no parameters) will appear in the Inspector window, and you can subscribe events directly there instead of in code.
- Counting Jumps (1 point)
  - Open the `JumpCounting` scene. In it, a box jumps every time you press space.
  - Modify the `JumpBox.cs` script on the Box GameObject 
    - Add a `UnityEvent<int>` to be trigger On Jump and an `int` to count the number of jumps.
    - Every time the player pressed space, the On Jump event should fire, passing in the jump count
    - Subscribe the UI to the event to update its text every time a jump occurs.
  - Add a text UI element for indicating the number of jumps.
    - Give it the `JumpUI.cs` script component, and create a function with the signature `void UpdateJumpUI (int count)`. This function should update the text to count.
    - Get a reference to the JumpBox script and subscribe UpdateJumpUI to the On Jump event.
  - Subscribe something else to the On Jump event. This can be anything you want, and will likely involve creating your own script to subscribe it to the event.
    - Note: Must be obvious for the purposes of grading. Some ideas include: confetti explosion, sound effect, post processing effect, camera shake, etc. Get creative!


## Optional (7 points)
- Custom Event System (2 points)
  - Instead of using UnityEvents, create your own event system using C# events and delegates
- Custom UI (2 points)
  - After a while, the default Unity UI gets really boring and lame, but luckily you can replace the sprites on all UI elements in Unity. Find some cool UI assets online or make your own and replace all the default UI in the `MainMenu` scene.
  - (UI is the first thing people see in your game, so make sure its good!)
- Audio Mixing (1 point)
  - AudioMixers are a really useful asset that are used to adjust an entire channel/group of audio sources at once (i.e. master volume). They can even add effects!
  - Create a new `AudioMixer` asset and adjust its volume instead of directly changing the volume of the music.
  - Check out the documentation on AudioMixers for more details as to how they work.
- Scene Transitions (2 points)
  - Modify the `SceneLoader` GameObject
    - Add a child `Image` UI component, set its sprite to a basic square, set the color to black, and have it [fill the entire screen](https://answers.unity.com/questions/1250052/set-the-ui-image-to-fit-screen-size.html).
  - Modify the `SceneLoader.cs` script
    - Instead of just setting the new scene, setup a coroutine to fade the screen out, then switch scenes, then fade the screen in. 
- Text Mesh Pro (1 point)
  - For all applicable UI elements, use TextMeshPro (TMP) instead of the standard UI.
  - The difference is that TMP converts UI to a mesh, allowing it to scale infinitely without getting blurry.
  - This should be trivial. If a UI element has two variants, use the one that says TextMeshPro.