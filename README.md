# Ludum Dare 42 (Working Title)

### Required Setup

#### 1. Configure Unity For Version Control
With your project open in the Unity editor:

###### Open the editor settings window
* Edit > Project Settings > Editor
###### Ensure the following settings are set
* Make .meta files visible to avoid broken object references.
* Version Control / Mode: “Visible Meta Files”
* Use plain text serialization to avoid unresolvable merge conflicts.
* Asset Serialization / Mode: “Force Text”

  Save your changes. (File > Save Project)

If you’re curious, you can read more about Unity’s YAML scene format [here.](https://robots.thoughtbot.com/how-to-git-with-unity)

### Version Control

`.gitattributes` has been set up to enforce the proper line endings on certain file types and enables Unity's *Smart Merge* tool to be used on merge conflicts surrounding unity specific files. 

Additional clarification on this topic [here](https://gist.github.com/djcsdy/1f9cc264dc56c16bf2d9d228a1db78a5) and [here.](https://www.edwardthomson.com/blog/git_with_unity.html)



