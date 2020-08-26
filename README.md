# BOBCheats - Unity plugin ![GeekBox Logo](https://github.com/wanakubwa/GeekBox-Unity-Game.Area51/blob/master/Game_Images/48x48_Logo.png)
### BOB is a smart cheats system for unity games. The idea to create this plugin was one thing, to create a system that would make creating cheats for your game a pleasure. You can create cheats and use it in game by writing just one single method.

#### If you like this plugin, you can pin a star :star: on it, and like our facebook fanpage :thumbsup: (and left a comment with your opinion) so that you don't miss any more plugins.

<p align="center"> <a href="https://www.buymeacoffee.com/wanakubwa" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
    <br />
  You can also support me by buying a coffe! :coffee:
</p>

## :floppy_disk: How do I cheat? (Installation)
To start working with BOB, just follow a few simple steps.
1. Download and unpack latest release version of plugin (.unitypackage) from [**Here!**](https://github.com/wanakubwa/BOBCheats/releases)
2. Open BOBCheats settings from *Window/BOBCheats* and click **Create BOBManager**. Then it should spawn a GameObject in Your scene.
<p align="center">
  <img width="460" height="300" src="https://github.com/wanakubwa/BOBCheats/blob/master/Graphic/BOB_Settings_spawn.png">
  <br />
  BOBCheats settings editor window preview.
</p>

3. Now create a folder i.e. *Cheats* in your project (We will use it for storing game cheats).
4. Create a cheats container class inside folder from step **3**. Cheats container must be a class **inherited** from class `CheatBase`.
```csharp
using BOBCheats;

// Example of class to store cheats. You can create more than one class.
public class GameCheats : CheatBase
{

}
```
5. Inside class defined in previous step write cheats methods, each cheat must be an `public static void` method with `[Cheat]` attribute.
6. Now You can show cheats menu in game by presing **f12 button** in keyboard or **double tap** on screen (mobile device).

#### Example of a correctly created class with cheats methods.
```csharp
using BOBCheats;

// Example of class to store cheats with one simple cheat method.
public class GameCheats : CheatBase
{
    [Cheat]
    public static void PauseGameCheat()
    {
        // Do stuff...
    }
    
    [Cheat]
    public static void AddCoinsCheat(int coins)
    {
        // Do stuff with parameter...
    }
}
```

## :bar_chart: BOB settings

Settings window can be open from *Window/BOBCheats*.
<p align="center">
  <img width="460" height="300" src="https://github.com/wanakubwa/BOBCheats/blob/master/Graphic/BOB_Settings_show.png">
</p>

- **Activate key short** - Set key to show BOB menu in game (default f12).
- **Reload cheats collection** - Manual download of all created cheats.
- **Create BOBManager** - Spawn BOBManager in scene hierarchy, can be saved as .prefab.

## Attributes

### [Cheat] Attribute
Each cheat method must have the `[Cheat]` attribute. Using an attribute without parameters will display the cheat name in the menu as a function name with spaces between lower case and upper case letters. The attribute can be defined using a `string` type parameter that defines the name to be displayed in the menu.

Example of using `[Cheat]` attribute with and without parameters.
```csharp

    [Cheat]
    public static void PauseGameCheat()
    {
        // This cheat will be displayed in cheat game menu as "Pause Game Cheat".
    }
    
    [Cheat("Change Weather - Rain")]
    public static void MakeItRain()
    {
        // This cheat will be displayed in cheat game menu as "Change Weather - Rain".
    }
```

## :exclamation: Limitations

- Only prymitive types can be used as an cheat parameters (string, int, float).

<br></br>
<p align="center"><strong> If you found a bug in the plugin or have an idea for additional functionality, open <a href="https://github.com/wanakubwa/BOBCheats/issues">Issue</a> and post your opinion in it.</strong>
</p>

## License

[MIT][mit] © [wanakubwa][author]

[mit]:      http://opensource.org/licenses/MIT
[author]:   http://github.com/wanakubwa
[issue-link]: https://github.com/wanakubwa/BOBCheats/issues
