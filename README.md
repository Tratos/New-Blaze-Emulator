# New-Blaze-Emulator
Successfully compiled with Visual Studio 2017.
# Setup
Edit: YAML file load adjusted.
Copy the "data" folder with the "Blaze.Server.yml" into the release folder.

The required files are in the 'data' directory. The server must be compiled manually.

Make sure you edit the personaref value (_StartGame.bat) so that it matches the user ID of the user you want to authenticate with 
(Blaze.Server.yml).

You can add more users by editing BlazeServer.yml.

The provided bf3_lan.exe is a dumped executable of the 1.6.0.0 version (latest as of 2016).
SSL certificate verification is patched in the executable.

Before playing, make sure to edit your hosts file and redirect the following hosts:

gosredirector.ea.com
373244-gosprapp357.ea.com
