# WPFControls.Example
An example of a WPFControls library written in a backend agnostic manner

# Controls
The Controls library implements a ViewModel.IBackend and a View.Contacts control.
- the library has no external dependencies (NuGet packages)
- the IBackend interface may be implemented by any external package

# Controls.Demo
The ViewModel.IBackend that is defined in the Control library has concrete implementations injected
by the Controls.Demo application, this way dependencies incurred by specific backends do not need 
to constrain the Controls library
