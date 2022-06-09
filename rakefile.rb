require "raykit"

task :default do
  Raykit::DotNet::init_new "Controls", "classlib"
  Raykit::DotNet::init_new "Controls.Test", "nunit"
  Raykit::DotNet::init_new "Controls.Demo", "wpf"
  run("dotnet build Controls.Demo.sln")
end
