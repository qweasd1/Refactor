### META-INF/MANIFEST.MF
The **OSGI manifest** describes the plug-in's:
* **dependencies**: any plug-in's dependencies should be declared here. This file setup the project' classpath
  * Require-Bundle: ```Require-Bundle: org.eclipse.ui, org.eclipse.core.runtime```
* version
* name
* singleton: ```singleton:=true``` 
* [TODO] see more properties in this file

* some tips:
  * For plug-ins which add dependencies to the UI, there is a restriction that they must be singletons.  (This constraint is one of the main reasons why installing a new plug-requires the IDE to restart.)

### plugin.xml
* extensions export to Eclipse existing extension points
* You can define label, action, menus for commands in this file. (a benefits, we can create button or menu for it on eclipse without create the underlying code)
* core elements:
  * extension@point=id
  * extension point-specific sub elements(like _<category>_ or _<view>_ for ```org.eclipse.ui.views``` extension points)
  * some common attr: id,name,category[, icon, class]

### build.properties(like ant, **we will replace it with Maven Tycho**)
* add resources that needed by plug-in. resources can be images, properties files, HTML contents.
* [tips] use Build tab of build.properties file to view it
