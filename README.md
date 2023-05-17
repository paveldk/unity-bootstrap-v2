After Unity's best practices for code architecture didn't convince me to be of any real use I decided to try and fix as many problems Unity have as possible with a couple of simple steps.
You can try and implement those in any existing projects. 

### Steps for better Unity3D

1. Have Separate Projects
In my case I've created 3 separate projects - one for interfaces, one for the core of the game and one for the Unity layer.
The goal here is to use Unity only as a UI layer, so you should be able to run your game only with your core project and your game should be able to execute even in console.
This way you really really improve the testability of your code.

2. Use Dependency Injection
I am using [Adic](https://github.com/intentor/adic) for DI. It is really easy to use and let you easily separate and modulize you game.

3. Use Controllers working with Context
The main problem I got with Unity was the MonoBehaviours and the way they could interact with each other which is a total anti-pattern in any normal dev environment.
So try to reduce the usage of those and much as possible. 
I am trying to do that with so called `Controllers` or name those any way that suits you. Those should be small bits of code that add functionality to ANY 3D Game object. So they should be reusable. 
And how can those be independent? Well with the last step:

4. Add Context concept
That should be simple class with two main properties - `View` and `Data`. The `View` will be your 3d object and the `Data` will be the game data that you want to attach to that game object.
So basically any Controller should be able to work with Context<D, V> where D : Data, and V : View

5. Use UniRx
It is a whole other topic how amazing [reactive programming](http://reactivex.io/) is and how it helps you improve your unity project. 
In short - in our case we use it to have the communication between the different controllers and the core and unity layer. 

Following those steps you should end up having really independent and easy to maintain and test modules.

### Some explanations on this sample project
So the goal of this project was to present the steps described above.
We have some Hero (presented as red cube :D) which you can click on and it will move. (amazing)
What happens under the hood is that you have `ClickController` that listens for clicks on its Context (in our case - the Cube) then sends request to the `HeroService` which is part of the core project. 
The `HeroService` then updates some properties of the `HeroData`. 
We have another controller `MoveController` that is subscribed to some `HeroData` changes (using UniRx) and then move the Cube on the scene.
And this is possible because we are creating Controllers that are set to work with `IContext<IHeroData, IUIObject>`

The other important part is how things bootstrap:
After the DI has completed, we create our Hero context (which creates the 3D Cube and adds the HeroData) [here](https://github.com/paveldk/unity-bootstrap-v2/blob/master/UnityBootstrapV2/Assets/Scripts/Utils/EntityGenerator.cs).
Then we create new ControllersGenerator for that Context (same file) which internally adds all controllers for that Context.
This generation process should be dynamic and you should be able to instanciate new ControllerGenerators for your contexts at any given moment.

### Any suggestions for improvements of the so - called mini framework are welcomed
