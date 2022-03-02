# HOI4 UMT

HOI4 UMT (Unified Mod Tool) is a highly extendable and modifiable modding tool for the popular grand strategy game Hearts of Iron 4. With HOI4 UMT, you can do literally anything - provided that a plugin exists for it. In development, no release yet.

## Table of contents

- [HOI4 UMT](#hoi4-umt)
    - [Table of contents](#table-of-contents)
    - [Setting up the application](#setting-up-the-application)
        - [Pre-requisites](#pre-requisites)
        - [Installation of pre-requisites](#installation-of-pre-requisites)
        - [Configuring Visual Studio 2022](#configuring-visual-studio-2022)
    - [Running the application](#running-the-application)
        - [Debugging the application with Visual Studio 2022](#debugging-the-application-with-visual-studio-2022)
        - [Running the release version](#running-the-release-version)
    - [Running tests](#running-tests)
    - [Code standards](#code-standards)
    - [Development guidelines](#development-guidelines)
        - [Committing and pull requests](#committing-and-pull-requests)
            - [Commit messages](#commit-messages)
        - [Adding new dependencies](#adding-new-dependencies)
    - [If you decide to contribute, THANK YOU!](#if-you-decide-to-contribute-thank-you)

## Setting up the application

### Pre-requisites

Windows 10 is preferred, as it's the operating system this project was made on. It should also work on other Windows versions, if you meet all the other requirements.

Requirements:

- Windows operating system
- Latest Visual Studio 2022
- .NET 6 SDK and runtime

### Installation of pre-requisites

Visual Studio 2022 Community Edition installer can be found from: https://visualstudio.microsoft.com/vs/community/

**The provided installer also contains options for downloading software development kits, such as the .NET 6 SDK and runtime**. *Nevertheless*, you can download .NET 6 from here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

### Configuring Visual Studio 2022

The included .editorconfig file sets the visual style of code in this solution. Do not modify the .editorconfig file, and do not overwrite it with your own editor's config. All code must look the same in this solution.

If you wish to edit markdown files (.md), I would recommend Markdown Editor v2, which can be found here: https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2

## Running the application

### Debugging the application with Visual Studio 2022

Open the solution in Visual Studio 2022. After that, select the configuration in the Configuration Manager (You can open the Configuration Manager by right clicking the solution in the Solution Explorer and selecting "Properties"). In Properties, navigate to "Configuration Properties", and then press "Configuration Manager...". After that, select the Active solution configuration and platform (recommended for debugging is **Debug (x64)**), and exit out of the properties. **DO NOT MODIFY ANYTHING ELSE IN THE CONFIGURATION MANAGER!**

Next, clean and rebuild the solution. You can do this by right clicking the solution in the Solution Explorer, and then clicking "Clean Solution" and "Rebuild Solution".

Next, navigate to HOI4UMT/HOI4UMT.UI/bin/(Active solution platform)/(Active solution configuration)/Plugins/. Make sure that all the plugins exist in the folder (there should be .dll and .md files in every subfolder).

Now you can debug the application. In Visual Studio 2022, just press the debug button or F5.

### Running the release version

Open up the solution Configuration Manager (explained in detail in the section above), and select "Release" as the Active solution configuration and preferably "x64" as the Active solution platform. Exit out of the configuration manager, and clean and rebuild the solution. Check that the Plugins exist in HOI4UMT/HOI4UMT.UI/bin/(Active solution platform)/(Active solution configuration)/Plugins, and run **HOI4UMT.UI.exe**.

## Running tests

Unit and system tests will be added in a future release. Of course, if you have unit and/or system testing experience and would like to contribute, email me at intragalactical@protonmail.com and we can start adding them right now!

## Code standards

Though the code before the full release can look messy and frankly, bad in some cases, this is not meant to be the case forever. This project is set to follow very strict code standards, **which I also expect every outside contributor to follow even before full release**.

1. **Minimal mutation**

    Avoiding mutation is not always possible in C# development, especially UI development, which is why I won't fully forbid mutation. **But**, mutation should still be avoided at all costs, when ever possible. Mutation leads to countless amounts of bugs, and frankly, unreadable and unmaintainable code, which is why I won't allow unnecessary mutation. 

    **This rule also concerns collection mutation**. Strive to use only the readonly versions of the collections.

2. **Split large functions into smaller functions**

    Your function should never be longer than about 40 - 60 lines. If it is, it's time to split it into multiple smaller, descriptive, pure functions.

3. **Use pure functions**

    Though not always possible, all of your functions should be pure functions, roughly meaning they do not mutate anything outside of their scope, adn that they always return the exact same value for the exact same arguments.

4. **No unnecessary comments**

    When code changes, old comments almost always become unnecessary, and usually even misleading. Therefore, you should avoid using comments to document your code. Instead, you should aim to make your code as readable as possible, so it documents itself. **Obviously, public API documentation with comments is allowed** (for example function descriptions visible in IDE).

5. **Code self-documenting code**

    Your code has to be readable by maintainers. This means that if you have a function, the maintainer should be able to know what the function does without having to look at the function code itself.

    Your variables also have to be self-documenting.

6. **No magic numbers or strings**

    Every number or string has to have a reason to be there. Therefore, you should either create a descriptive variable for it, and use the variable, or make a constant of it if it's universally used.

    For example, this:

    ```csharp
    int allApples = 6 + 4;
    ```

    should be:

    ```csharp
    int jeremysApples = 6;
    int ronsApples = 4;
    int allApples = jeremysApples + ronsApples;
    ```

7. **Avoid for, while, for each**

    If you are coding immutable code, there is no reason to use these. Use LINQ methods instead when ever possible. **In some cases, using these is unavoidable**, for example when creating parallelized code, and in some cases when creating UI code.

8. **Always use newest C# syntax and features available**

    C# is constantly being updated, and you should strive to use the newest available features to their fullest.

9. **Avoid if**

    Avoid ifs. Always use ternaries for expressions if possible. With **STATEMENTS** you should prefer ifs over ternaries.

10. **Avoid statements**

    Adding to the last rule, avoid using statements. Always use expressions instead.

    For example, instead of this:

    ```csharp
    private int DoX(int x, int y) {
        switch (SomeEnum) {
            case SomeEnum.Two:
                return y;
            case SomeEnum.One:
            default:
                return x;
        }
    }
    ```

    do this:

    ```csharp
    private int DoX(int x, int y)
        => SomeEnum switch {
            SomeEnum.Two => y,
            SomeEnum.One => x,
            _ => x
        };
    ```

    In some cases, using statements is unavoidable, especially if doing UI code. So don't feel too restricted by this rule.

11. **Avoid multiple returns in functions**

    Your function should be like a tree, with the return being the root. If you build your functions this way, there is no reason to use multiple returns, and they impair your function's readability.

    For example, instead of this:

    ```csharp
    private int DoX(int x, int y, int z) {
        if (x == z) {
            if (x == y)
                return x;

            return x + z;
        }

        return x + y;
    }
    ```

    do this:

    ```csharp
    private int DoX(int x, int y, int z) {
        static int doY(int x, int y, int z)
            => x == y ?
                x :
                x + z;

        return x == z ?
            doY(x, y, z) :
            x + y;
    }
    ```

12. **Avoid void and try/catch**

    HOI4 UMT uses [C# functional language extensions](https://github.com/louthy/language-ext), which adds in multiple functional programming features, such as Option, Either and Unit. 
    
    Instead of having a void method, have a function that returns *Unit*. For example, instead of this:

    ```csharp
    private void DoX() {
        // do something
    }
    ```

    do this:

    ```csharp
    private Unit DoX() {
        // do something
        return Unit.Default;
    }
    ```

    Instead of try/catch, return an Either and handle the exception with the Either. For example, instead of this:

    ```csharp
    private int MultiplyByTwo(int n) {
        int y;
        try {
            y = n * 2; // throws error when n * 2 is more than int.MaxValue
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
        return y;
    }
    ```

    do this:

    ```csharp
    private Either<Exception, int> MultiplyByTwo(int n)
        => n * 2 < int.MaxValue ?
            n * 2 :
            new Exception("n * 2 is larger than the maximum allowed value!");
    ```

    and handle the exception in the calling function.

    Instead of using *null* or *Nullable*, use ``Option<T>`` instead. For example, instead of this:

    ```csharp
    public class X {
        public Y? InstanceOfY { get; }

        public X() {
            InstanceOfY = null;
        }

        public int GetValue()
            => Y?.GetValue();
    }
    ```

    do this:

    ```csharp
    public class X {
        public Option<Y> InstanceOfY { get; }

        public X() {
            InstanceOfY = Option<Y>.None;
        }

        public Either<Exception, int> GetValue()
            => Y.Match(
                y => y.GetValue(),
                () => new Exception("Y has not been initialized!")
            );
    }
    ```

13. **Always test your code before creating a merge request**

    This will become more relevant when unit tests will get added in a future full release.

14. **Don't be afraid to not adhere to some of the code standards when coding**

    *(Within reason)*

    When you are coding HOI4 UMT, there will be cases where you have to decide between code that adheres to all the code standards, or code that will perform well. In those cases, you should primarily choose the latter - code that will perform well. For example, if you have a case where using mutation would result in an action taking less than 10 seconds where as using immutable code would result in the same action taking more than a minute, you should of course use the mutable method.

## Development guidelines

### Committing and pull requests

You should aspire to have only one commit for one feature, and one pull request for one feature. Use rebasing to achieve this.

To keep the project development unified, you should use the in-built Git tools of Visual Studio 2022.

#### Commit messages

Your commit messages should be short, imperative and clear. For example, instead of:

``Added feature A which only works in case X and did this and that and so on!``

do this:

``Add feature A, B, C, D``

### Adding new dependencies

A simple rule of thumb: do not do it. If you think we need a new dependency then at least consider the following:

- How much do you need to use it?
  - If it's just oneliner in one file then maybe implement the functionality yourself?
- How many dependencies does it have?
  - Pulling in 100 new packages as transitive dependencies for something other than a huge new feature we absolutely
    need to have isn't going to pass the review.

When in doubt contact me first (intragalactical@protonmail.com).

## If you decide to contribute, THANK YOU!

No, seriously, thank you. If you decide to contribute even after all these tough standards I've set up, you're awesome! This project is huge as hell, and every bit of help is needed!
