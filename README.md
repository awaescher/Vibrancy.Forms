
### Blur and Vibrancy effects for iOS and iPadOS with Xamarin.Forms

![Vibrancy.Forms animation](https://raw.githubusercontent.com/awaescher/Vibrancy.Forms/master/docs/Vibrancy.Forms.gif)

# Installation

- Install the NuGet package `Vibrancy.Forms` to your projects: The shared project and the platform projects.
- Head over to your `AppDelegate.cs` in your iOS project and initiaize Vibrancy.Forms in the method `FinishedLaunching()`.

```
...

global::Xamarin.Forms.Forms.Init();

Vibrancy.Forms.iOS.VibrancyForms.Init();    <--

LoadApplication(new App());

...
```

- In your XAML UI, add the Vibrancy.Forms namespace.

```
xmlns:vf="clr-namespace:Vibrancy.Forms;assembly=Vibrancy.Forms"
```

- Now, you can use the BlurView like any other view.

```
<vf:BlurView>
    <StackLayout>
        ...
    </StackLayout>
</vf:BlurView>
```
 > The BlurView needs to have exactly one content view.

- Customize the BlurStyle and the Vibrancy effect as you like.

```
<vf:BlurView
    BlurStyle="Light"
    EnableVibrancy="True">
    ...
</vf:BlurView>
```

Note that the BlurStyles `Regular` and `Prominent` will automatically adapt to the system theme (light or dark) - this is true for the Vibrancy effect as well. If you choose another BlurStyle like `ExtraLight` or `ExtraDark`, you'll have to adjust these manually.


![Banner](https://raw.githubusercontent.com/awaescher/Vibrancy.Forms/master/docs/Vibrancy.Forms.png)
