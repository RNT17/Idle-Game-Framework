# Idle Framework Conventions

# C#

### Variables  and Constants

### Functions

**Functions** Functions should have all its initials uppercase and its curly brackets starting in the next line and must start with a verb.
eg.:
function ApplySettings()
{

}

## Files

**fw/** this folder holds files related to the tiny framework that powers the idle game.
    **/assets** bootstrap, jquery, images and css related to the framework.
    **/config** configuration related to ui, save, etc.
    **app.cs** GameRunner, file that gets info from other files and make all the magic happen.
**game/**
    **/assets** images and css related to the specific game.
    **/settings** custom settings for the game