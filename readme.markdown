Mancala
=======
I've had this nice wooden [Mancala](http://en.wikipedia.org/wiki/Mancala) set for years but only recently started playing it -- a lot. I like the game because its small and simple. It is no coincidence that these tend to be favorable qualities for software as well. I couldn't resist trying my hand at writing a GUI implementation of this game, especially since I've been studying Object-Oriented GUI Best Practices ([MVC](http://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller), [MVP](http://en.wikipedia.org/wiki/Model_View_Presenter), [SoC](http://en.wikipedia.org/wiki/Separation_of_concerns), [Mocking](http://en.wikipedia.org/wiki/Mock_object), etc.)

Mancala Rules
-------------
Much like a deck of cards has no canonical set of rules of play, a Mancala board is simply a medium for any one of hundreds of various
[games](http://en.wikipedia.org/wiki/List_of_mancala_games). Though there are many games, most games have the following features in common:

* There are two sides to the board, each player gets six cups and a goal cup. Some have more or less than six, but I think six is typical.
* At the start of the game all of the regular cups are filled with seeds (rocks, game pieces, whatever you want to call them). I think it is typical to start with four seeds in each cup, but I've read of games starting with fewer.
* A move is made by choosing a cup, picking up the seeds and "sowing" the seeds by redistributing them to the next consecutive cups in a counter-clockwise direction.
* The objective typically involves one or both of the following
  * Getting more seeds in your goal cup than your opponent does.
  * Getting rid of your seeds faster than your opponent does.

**So, how do I play?** My game is influenced by my observation of games I've seen on YouTube. Until more recently, I'd never actually seen anyone play, so when I wanted to learn, I just searched for a videos of gameplay and evolved my own game from there. My game has the following rules in addition to the ones mentioned above:

* If, upon sowing your last seed, you should land in *your* goal cup, you get to go again.
* If, upon sowing your last seed, you land in a cup on your side that has only one seed, thus resulting in two seeds, you get to go again.
* If you are the first to clear out your side, the game is over and you get to take all of your opponent's remaining seeds. "To the victor goes the spoils."
* The winner is the player with more seeds at the end -- not necessarily the player that ended the game.

MVP and Mocking
---------------
I first learned about MVC in school, but I never used it until I tried my hand at Cocoa development, and later Rails. You kinda can't avoid something that's forced upon you by a framework. Prior to working with these frameworks, my GUI experience was limited to Visual Basic, excluding some earlier work in C and Pascal that used hand-rolled graphics libraries with inline assembly. There was no best-practices-enforcing framework to keep me from creating a unmaintainable mess of my code.

When I later came to develop winforms applications in C#, I noticed that, like my first GUI experiences, it's very easy to start writing very bad GUI applications very fast. Just lay a control on a form, double click it, and then start mingling lots of business logic into your form to your heart's content. Having tasted MVC, however, I realized that, even though it wasn't being forced upon me, I should probably be doing it.

I've recently been fortunate enough to have been handed a fairly green-field GUI project at work which has provided the context for all of these musings. My manager, noticing my internal struggle between C#'s apparent lack of "guard rails" and my desire for separation of concerns, directed me to Jeremy Miller's 25-Part [Build Your Own CAB Series](http://codebetter.com/blogs/jeremy.miller/archive/2007/07/25/the-build-your-own-cab-series-table-of-contents.aspx). Although I haven't yet read all of it, I've read enough to lead me down the right path and even learn a little bit about [Mocking](http://ayende.com/projects/rhino-mocks.aspx). I'm still struggling to understand what makes MVP different from MVC (Martin Fowler does address this in [one of his papers](http://www.martinfowler.com/eaaDev/uiArchs.html)). And maybe I haven't yet mastered the pattern in its proper form, but I still feel that I'm far better off than I was before. And, yes, I do realize that add-on frameworks exist for C# to facilitate this architecture, but the big take-away from Miller's articles is that you can, in fact, pull it off by yourself without getting entangled in a new framework if you simply follow some simple guidelines.

So what does Mocking have to do with any of this and why would I want to use it? One of the nice benefits of a loosely-coupled architecture is the ability to test components in isolation. This means that we can test business logic without worrying about the headache of "jeez, how do I simulate that call to the web service that my code depends on" or "that call to the database" or "that code that requires interaction from a human." All of these scenarios represent a huge headache for a developer trying to write dependable, repeatable unit tests. Why? Because unit tests demand deterministic behavior. This is not achievable when you interface with a non-deterministic system like those mentioned above. Humans are especially non-deterministic. In fact, Miller found through estimation experiments that "interfacing with a human was more complex than interfacing with other code."

Mocking frameworks allows us the freedom to abstract away all but that which we are immediately concerned with testing at the moment. The supervising controller never directly talks to the user, it merely manipulates the model and responds to changes to it that the user has indireclty made through the view. So, when its time to test the supervising controller, we can substitute a mock version of the view that behaves in a pre-recorded, deterministic way.