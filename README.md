# WPFControls.Example
An example of a WPFControls library written in a backend agnostic manner
An interface in defined for a backend, then the backend may be implemented with a dependency injection downstream of the controls library

# Controls
The Controls library implements a ViewModel.IBackend and a View.Contacts control.
- the library has no external dependencies (NuGet packages)

# Controls.Demo
The ViewModel.IBackend that is defined in the Control library has concrete implementations injected
by the Controls.Demo application, this way dependencies incurred by specific backends do not need 
to constrain the Controls library
