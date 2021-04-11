# Technical Assessment

This is your chance to shine and show off all your `ski11z`. You have **60 minutes** to go
through as much as you can, followed by a **30 minute** debrief where you can explain
your actions and add more thoughts to your work. It is up to you to manage your time.
The answers will be assessed against the role you habe applied for so ensure you demonstrate
the key objectives expected by the role.

## Getting started

You will need [git](https://git-scm.com/) and a code editor of your choice.
We recomend [Visual Studio Code](https://code.visualstudio.com/) or
[Visual Studio](https://visualstudio.microsoft.com/).
If you are hopeing to cut code you will need to follow your nose to setup a development enviroment,
or you can use the [Remote development container](https://code.visualstudio.com/docs/remote/containers-tutorial).
Once this has re-opened in the remote container run the following commands to ensure you are setup and ready to go.

```bash
dotnet restore
dotnet build
dotnet test
```

### Testing remotely

If you are testing off site please ensure you **commit** to the local git repo **often** to show progress and workflow. Ensure the comments explain **why** you did the change.
To submit your solution:

1.  Ensure you have commited all your changes
2.  Run `git clean -xdf`
3.  Compress the solution source into a single archive
    i. Ensure the .git folder is included in the archive
4.  Send on through!

### Excersise 1: Working with legacy code

This will asses your ability to critique legacy code and improve it.
Feel free to provide:

-   `/* inline comments */`
-   `() => "actual code changes"` \*
-   unit tests \*

or all of the above, remember you will have to explain yourself later,
so make sure we can see any of the before and after changes you make.
Open the [CodingAssessment solution](.\CodingAssessment.sln)

### Excersise 2: Clean green fields project

> As an enthusiastic card player and developer</br>
> I want to create a program to play cards against the computer</br>
> So that when I am bored I can play some card games against an intelligent opponent.

At this stage I am unsure of what UI to build for,
web, native, console or what card game I should code for (I'll figure that out later).

At this stage I know I need a concept of a Deck, Cards and a Shuffle function.

-   How would you setup your new solution and why?
    Show me your initial to do list with some reasoning, for example
    -   Create solution x
    -   Create projects y and z for blah and of type v because ...
    -   ... all the other important things, what are they? \*
-   Scaffold your solution
    -   See how much you can scaffold out to hand to another team member to continue with
    -   Bonus points if you have something working \*

(\*) Stared items earn bonus points
