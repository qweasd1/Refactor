### META-INF/MANIFEST.MF
The **OSGI manifest** describes the plug-in's:
* dependencies
* version
* name
* 

### plugin.xml
* extensions export to Eclipse existing extension points
* You can define label, action, menus for commands in this file. (a benefits, we can create button or menu for it on eclipse without create the underlying code)
* 

### build.properties(like ant, **we will replace it with Maven Tycho**)
* add resources that needed by plug-in. resources can be images, properties files, HTML contents.
* [tips] use Build tab of build.properties file to view it
