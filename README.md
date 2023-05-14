# Timers

The Timers class is a utility class for managing timed events and callbacks in Unity projects. It provides a simple way to set timers and execute callback functions when the timers expire.

## Features
- Set timers with specified durations.
- Execute callback functions when timers expire.
- Handles multiple timers simultaneously.
- Easy integration into Unity projects.

## Installation
1. Clone or download the `Timers.cs` script from this repository.
2. Copy the `Timers.cs` script into your Unity project's scripts folder (`Assets/Scripts`).

## Usage
1. Attach the `Timers` script to a GameObject in your scene. This object will act as the timer manager.
2. Access the `Timers` class via its singleton instance: `Timers.Instance`.
3. Use the following methods to set timers and define callback functions:

   - `SetTimer(float duration, Action callback)`: Set a timer with a given duration and a callback function to execute when the timer expires. The `duration` parameter specifies the time in seconds for the timer to run, and the `callback` parameter is an `Action` representing the function to execute when the timer expires.

     ```csharp
     // Set a timer for 3 seconds and define a callback function
     Timers.Instance.SetTimer(3f, () =>
     {
         // Code to execute when the timer expires
     });
     ```

## Examples
1. Simple Timer:
   ```csharp
   // Set a timer for 5 seconds and print a message when it expires
   Timers.Instance.SetTimer(5f, () =>
   {
       Debug.Log("Timer expired!");
   });

2. Multiple Timers:
    ```csharp
    // Set multiple timers with different durations and callbacks
    Timers.Instance.SetTimer(2f, () =>
                             {
                                Debug.Log("Timer 1 expired!");
                             });
Timers.Instance.SetTimer(3f, () =>
                         {
                            Debug.Log("Timer 2 expired!");
                         });
