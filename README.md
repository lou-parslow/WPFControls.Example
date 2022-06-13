# WPFControls.Example
An example of a WPFControls library using the MVVM architechural pattern, where the ViewModel and Model layers are defined by interfaces,
thereby allowing custom viewmodel and model implementations to be dependency injected by a client.

The purpose of the example is to demonstrate how to write an independent controls library, that allows client applications
to inject whatever ViewModel or Model implementations are desired. This allow a great deal of flexiblity for clients, and
allows the Controls to be written independently of any specific ViewModel or Model implementations.

# Models - the Model layer
The Models library implements the Model layer
- interface(s) are specified that allow custom implementations by client applications

# Controls - The View and ViewModel layers
The Controls library implements a View amd ViewModel layers
- the library has no external dependencies (NuGet packages), not even the Models library
- the ViewModel is define by an interface, as such may be implemented by a client application (dependency injected)
- the View(s) bind only to the ViewModel interface(s), as such, any custom implementations of the interface will work with the control

# Controls.Demo
The Adapters are used to inject custom models,viewmodels into the Controls ViewModel using adapter classes

# Benefits of this pattern
- Controls may be developed independently of any Model
- By developing controls independently of a Model, Leaky abstractions are less likely to occur
- By developing controls independently of a Model, Development is never blocked by a particular model
- The unit tests for the Model fall out of the Controls ViewModel interface tests
- Models may be developed independenly of any ViewModel or View

# Links
- https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern
- https://stackify.com/dependency-injection/#:~:text=Dependency%20injection%20is%20a%20programming,inversion%20and%20single%20responsibility%20principles.