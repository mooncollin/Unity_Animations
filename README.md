# Unity Short Animation Guide
This guide goes over how to make simple animations and transitions using the Animator components on objects.

## Creating a simple rotation animation
We will start off by making an animation that will
rotate an object on its Y axis continously.

Start by making an Animations folder in the Assets folder.

Then what you'll want to do is drag any game object into the world. In my example, I'm going to use a ring from the Standard Assets store. You do not need this, but it makes the rotation animation look much cooler.

Put an Animator component on the game object. You'll notice that the Animator component requires a controller piece. To create a controller, right-click and create an Animator Controller in the Animations folder. I've named mine "SpinningAnimator". This animation controller allows you to create states of animation that the object will be in, as well as make transitions to other states of animation, or exit animation altogether. Drag the new Animator Controller into the Animator component of the object.

In order to start making an animation, right-click and create an Animation in the Animations folder. I've named mine "SpinningAnimation".

In order for the Animator Controller to do anything, it needs a default starting state. Open up the animator controller that you've made by double-clicking it. It will bring up the Animator window. Your Animator Controller comes with several states already. Let's make a default state by right-clicking and selecting Create State->Empty. You'll see that there is now an arrow pointing from the Entry state to your new state. This denotes that upon starting the game, it will transition automatically to that default state. For now this is what we want, the object to start spinning when the game begins.

To attach your animation file you made to this state, click on the state and drag your animation file onto the "Motion" slot.

To start editing our animation, we need to open up the Animation window. This window can be opened by going to Window->Animation->Animation. Then click on the object you wish to start animating. Clicking on a valid object (one with an Animator Controller) should allow you to add properties.

Properties that can be added are immense. Any property from other components can be used here. This allows you to change properties on components as time goes on in any speed/acceleration you want.

To start changing the Y rotation of the object, click Add Property->Transform->Rotation->+. Click the drop down on the left to reveal the x, y, and z rotation properties. Click the Y rotation property. Near the bottom of the Animation window, there is a "Curves" button, I suggest switching to that, as it is much easier to make animations this way. You will see a line and several points indicated as diamonds. These points are markers of time where values should be at. If there is not already a marker at the end, right-click and select "Add Key". Change the value of the key to be 360. This will fully rotate the object. You will see the point go way up, as it tries to transition to 360 through the time allowed. Click the play button to see what it would do on your object. You can change the end time by changing the Time on the end marker.

To make it look like the animation loops better, try setting the end marker to Auto, by right-clicking and clicking "Auto". This will change the curve a bit. The delay you see in the animation window when it loops will not be apparent in the game.

You may have noticed that when you have an initial rotation, this will reset it to how the animation is. In order to have the animation base itself off of the current object's properties, select the "Apply Root Motion" box in the Animator Controller component.

Now run the game and see your object spin!... Oh no, it stops right away? There is another setting to make the animation continously run. To do this, click your animation file and check the "Loop Time" box. Also check "Loop Pose" as it promises to make the loop look seamless. You might run into an issue where it slows down during part of the spin. This can be fixed by making the curve as straight as a line as possible. This can be done by adding "Auto" to the beginning marker in the animation curve.

Now you have a spinning object!!

## Creating an on touch animation
For this exercise, we will create an animation that will trigger when we touch an object. This animation will change the color from its default to a deep red, and then will transition back to normal.

Make a cube game object and add an Animator to it. This needs to be a cube, or some other 3d object, since it comes with a collider and a mesh renderer. Make an Animator Controller file and add it to the Animator. Create an Animation file.

We will create two states in the Animator Controller. One will be the default starting state, and the other will be where our animation plays in. Add the new Animation file onto the non-default state. We will then create a transition from the starting state to the changing color state. To do this, right-click on the starting state and click "Make Transition" and then click the other state.

We want this transition to happen when the object gets touched. You can find a way to make this object get touched. I will use Standard Assets and have a character touch it. In order for the transition to happen, we need to make a trigger. Once the animation gets the trigger, it will make the transition. To create a trigger, go to the parameter pane in the Animator window. Click the plus, and add a trigger. Name this trigger "Touch". After this, click the transition that you have made and add a condition onto the condition list. Add a trigger condition and select the "Touch" trigger. After this create a transition coming from the changing color state to the default state. This will allow it to go back to the normal state, and then will need to wait for the trigger again.

Make a script like the one below and add it to the game object:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("Touch");
    }
}

```

The above script will set the "Touch" trigger on the Animator component when the object collides with something.

Now we need to actually make the animation. Go to the Animation window and select the game object to use. If the game object as a mesh renderer component, then go ahead and add the Material._Color property. This will allow us to change the red, green, or blue color of the game object. I will allow you to change the color curve any way you like, but I'm going to have the object go from normal to dark red. The curves will be the following:
* Red: Start: 1 End: 2 Time: 2 seconds
* Green: Start: 1 End: 0 Time: 2 seconds
* Blue: Start: 1 End: 0 Time: 2 seconds

By clicking play in the Animation window, you can see that it will transition from white to red. Now when you play the game, every time you hit it, it should change color, and then go back to normal.

## Combining the two
Now you have a changing color animation and a spinning animation. Let's make our spinning object also behave like the changing color object. This will require making another state in the spinning object's Animator window and adding a transition from the spinning state to that new state. We will also have this transition happen on touch. So make sure to make the "Touch" parameter on this one. Also, add a transition to go back to the spinning state.

You can change how the transition will fade from one to another by clicking the transition. Add the script from above to this game object and play!