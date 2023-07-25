# 2D-template-project
An example of the architecture of a simple 2d game.
This is not a ready-to-work project, but only an example of architectures implementation.

Includes examples:
- Example of the implementation of the Bootstrapper part (without Bootstrapper.cs).
- Single entry point of the project.
- Working with components through containers (exclude editing of one Unity component by multiple modules).
- A simple hierarchy of dependencies that is suitable for any PVP shooters, with different types of weapons.
- Working with C# extensions.
- The single responsibility of modules, and the presence of the correct contracts, presented in interfaces and abstract classes.
- Antipattern 'Game Manager' (due to the lack of DI, as well as a bunch of other related modules), writing a complete architecture would be time-consuming, but you will find something new for yourself in the approaches described above.
