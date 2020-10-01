# Where to find different features of C\# in the project

* classes and objects with member e.g.: Program
* immutable object e.g.: DraughtsInputKickRequest
* enum e.g.: StoneColors
* constructor e.g.: Stone
* auto-properties e.g.: Stone
* initialized auto-properties e.g.: Stone
* auto-properties with different access-modifiers e.g.: Stone
* private static fields (class variables) e.g.: Program (_reader)
* protected const e.g.: DraughtsInput (NoMoveText)
* public static Property e.g.: Program (Board)
* Disposable object e.g.: Program Board (calling Dispose())
* event e.g.: Board - BoardHasChanged
* eventHandler / delegate e.g.: Program Program ... BoardOnBoardHasChanged
* out-Parameter e.g.: InputReader (ParsePosition)
* Exceptions e.g.: InputReader (ParsePosition)
* interfaces e.g.: IRequestHasPositionInformation
* type check e.g.: ExecuteRequest(DraughtsInput) "is"-Operator
* abstract base class DraughtsInput
* virtual method e.g.: DraughtsInput (PrintMyMove)
* overridden method e.g.: DraughtsInputMoveRequest (PrintMyMove)
* overloaded method e.g.: DraughtsInputMoveRequest (PrintMyMove(int,int))
* overlapped method e.g.: DraughtsInputMoveRequest (PrintMyMove(int,int))
* Namespaces (UML: packages) e.g.: SWA.Draughts.Final.Input (see classes in "folder" Input)
* polymorphism sample: DraughtsInputKickRequest has method to PrintMyMove \
  (which is there for demonstration and in geneal a bad design decision to put this in the base class)
* generics: see InitializableReadonlyCollection
* collections: see InitializableReadonlyCollection
* string interpolation: see PrintMyMove(int,int)
* normal string: e.g.: DraughtsInput (NoMoveText)
* null: ExecuteRequest(DraughtsInput)

## Concetps all over the place

* OOP approach (with C# Naming Conventions)
* encapsulation
* inheritance
* polymorphism