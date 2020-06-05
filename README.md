
### Blur and Vibrancy effects for iOS and iPadOS with Xamarin.Forms

![Vibrancy.Forms animation](https://raw.githubusercontent.com/awaescher/Vibrancy.Forms/master/docs/Vibrancy.Forms.gif)

# Installation

- Install the NuGet package `Vibrancy.Forms` to your projects: The shared project and the platform projects.
- Head over to your `AppDelegate.cs` in your iOS project and initialize Vibrancy.Forms in the method `FinishedLaunching()`.

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

- Once this is done, you can use the BlurView like any other view.

```
<vf:BlurView>
    <StackLayout>
        ...
    </StackLayout>
</vf:BlurView>
```
 > ⚠️ The BlurView needs to have exactly one child view.

- Customize the BlurStyle and the Vibrancy effect as you like.

```
<vf:BlurView
    BlurStyle="Light"
    EnableVibrancy="True">
    ...
</vf:BlurView>
```

Note that the BlurStyles `Regular` and `Prominent` will automatically adapt to the system theme (light or dark) - this is true for the Vibrancy effect as well. If you choose another BlurStyle like `ExtraLight` or `ExtraDark`, you'll have to adjust these manually.

# iOS / iPadOS only

Despite being a Xamarin.Forms plugin, Vibrancy.Forms is not cross-platform. It is designed for iOS and iPadOS only.

### Why?
While blur effects can be achieved on all major platforms, vibrancy effects are "Apple-only". I started this project because I wanted to have both, blur and vibrancy effects in my iOS and iPadOS apps. However, vibrancy was not provided by any existing plugin. 

This means I am done at this point. I do not plan to implement other platforms. I won't reinvent existing cross-platform plugins.

So if you want to have beautiful cross-platform blurs, I highly recommend using [Sharpnado.MaterialFrame](https://github.com/roubachof/Sharpnado.MaterialFrame) by [Jean-Marie Alfonsi](https://github.com/roubachof). But you'll have to live without vibrancy effects then.

### Why Xamarin.Forms for "Apple-only"?
Xamarin.Forms really is an awesome cross-platform solution. But even if you're lucky enough to skip Android and UWP and go for iOS and iPadOS only, Xamarin.Forms is still a very attractive option, becaue you can make use of high level abstractions like the ListView or the Shell navigation without going too deep into UIKit and friends. 

---

Special thanks once again to our friends at <a href="http://www.freepik.com/" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> for the awesome package icon.
